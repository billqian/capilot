namespace Pilot.Application.Features.Identities.Commands.CreateUser;

public record class CreateUserCommand(string loginName, string password, string description, bool isSuper = false)
    : IRequest<Guid>;
