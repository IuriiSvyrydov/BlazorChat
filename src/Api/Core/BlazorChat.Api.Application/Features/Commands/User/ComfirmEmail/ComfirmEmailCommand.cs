using BlazorChat.Api.Application.Interfaces.Repositories;
using BlazorChat.Common.Exceptions;
using MediatR;

namespace BlazorChat.Api.Application.Features.Commands.User.ComfirmEmail;

public class ComfirmEmailCommand: IRequest<bool>
{
    public Guid ConfirmationId { get; set; }

}
public class ComfirmEmailCommandHandler: IRequestHandler<ComfirmEmailCommand,bool>
{
    private readonly IUserRepository _userRepository;

    public ComfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmRepository emailConfirmRepository)
    {
        _userRepository = userRepository;
        _emailConfirmRepository = emailConfirmRepository;
    }

    private readonly IEmailConfirmRepository _emailConfirmRepository;
    public async Task<bool> Handle(ComfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var confirmation = await _emailConfirmRepository.GetByIdAsync(request.ConfirmationId);
        if (confirmation is null)
            throw new DataBaseValidationException("Confirmation not found");
        var dbUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == confirmation.NewEmailAddress);
        if (dbUser is null)
            throw new DataBaseValidationException("User not found with this email");
        if (dbUser.EmailConfirmed)
            throw new DataBaseValidationException("Email address is already confirmed");
        dbUser.EmailConfirmed = true;
        await _userRepository.UpdateAsync(dbUser);
        return true;

    }
}
