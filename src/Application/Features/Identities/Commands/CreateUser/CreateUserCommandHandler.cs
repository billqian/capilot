using Application.Shared.Services;
using Pilot.Domain.Identities;

namespace Pilot.Application.Features.Identities.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IRepository<User> _repository;

    public CreateUserCommandHandler(IRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User() {
            LoginName = request.loginName,
            Password = request.password,
            Description = request.description,
            IsSuperAdmin = request.isSuper
        };

        user.AddDomainEvent(new UserCreatedEvent(user));

        await _repository.InsertAsync(user);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}