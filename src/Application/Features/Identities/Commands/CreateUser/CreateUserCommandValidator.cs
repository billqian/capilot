namespace Pilot.Application.Features.Identities.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.loginName).MaximumLength(50).MinimumLength(5).NotEmpty();
        RuleFor(v => v.password).MinimumLength(4).NotEmpty();
    }
}