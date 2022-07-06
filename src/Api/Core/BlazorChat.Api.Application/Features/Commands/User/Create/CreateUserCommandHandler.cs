using AutoMapper;
using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common;
using BlazorChat.Common.Events.User;
using BlazorChat.Common.Exceptions;
using BlazorChat.Common.Infrastructure;
using BlazorChat.Common.Models.RequestModel;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.User.Create;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand,Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);
        if (existUser != null)
            throw new DataBaseValidationException("User already exist");
        var dbUser = _mapper.Map<Domain.Models.User>(request);
        var rows = await _userRepository.AddAsync(dbUser);
        //Email changed/created
        if (rows>0)
        {
            var @event = new ChangeUserEmailEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = request.EmailAddress,
            };
            QueueFactory.SendMessageToExchange( exchangeName:RabbitMQConstansts.UserExchangeName,
                                                exchangeType:RabbitMQConstansts.DefaultExchangeType,
                                                queueName:RabbitMQConstansts.UserEmailChangedQueueName,
                                                obj:@event);
        }

        return dbUser.Id;
    }
}