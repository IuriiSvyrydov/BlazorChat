using AutoMapper;
using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common;
using BlazorChat.Common.Events.User;
using BlazorChat.Common.Exceptions;
using BlazorChat.Common.Infrastructure;
using BlazorChat.Common.Models.RequestModel;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand,Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await _userRepository.GetByIdAsync(request.Id);
        if (dbUser is null)
            throw new DataBaseValidationException("User not found");
        var dbEmailAddress = dbUser.EmailAddress;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress)!=null;
        _mapper.Map(request,dbUser);
        var rows = await _userRepository.UpdateAsync(dbUser);
        if (emailChanged && rows > 0)
        {
            var @event = new ChangeUserEmailEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = request.EmailAddress,
            };
            QueueFactory.SendMessageToExchange(exchangeName: RabbitMQConstansts.UserExchangeName,
                exchangeType: RabbitMQConstansts.DefaultExchangeType,
                queueName: RabbitMQConstansts.UserEmailChangedQueueName,
                obj: @event);
            dbUser.EmailConfirmed = false;
            await _userRepository.UpdateAsync(dbUser);
        }

        return dbUser.Id;
    }
}