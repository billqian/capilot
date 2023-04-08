using Application.Shared.Services;
using Pilot.Application.Services;
using Pilot.Domain.Identities;

namespace Pilot.Application.Features.Identities.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User() {
            LoginName = request.loginName,
            Password = request.password,
            Description = request.description,
            IsSuperAdmin = request.isSuper
        };

        

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync(cancellationToken);

        user.AddDomainEvent(new UserCreatedEvent(user));

        return user.Id;
    }
}