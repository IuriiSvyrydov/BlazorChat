using AutoMapper;
using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common.Events.User;
using BlazorChat.Common.Exceptions;
using BlazorChat.Common.Infrastructure;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.User.ChangePassword;

public class ChangeUserPasswordHandler: IRequestHandler<ChangeUserPasswordCommand,bool>
{
    private readonly IUserRepository _userRepository;
    private readonly  IMapper _mapper;

    public ChangeUserPasswordHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        if (!request.UserId.HasValue)
        {
            throw new ArgumentNullException(nameof(request.UserId));
        }

        var dbUser = await _userRepository.GetByIdAsync(request.UserId.Value);
        if (dbUser is null)
            throw new DataBaseValidationException("User not found");
        var encPass = PasswordEncryptor.Encrypt(request.OldPassword);
        if (dbUser.Password != encPass)
            throw new DataBaseValidationException("Old password wrong");
        dbUser.Password = PasswordEncryptor.Encrypt(request.NewPassword);
        await _userRepository.UpdateAsync(dbUser);
        return true;


    }
}