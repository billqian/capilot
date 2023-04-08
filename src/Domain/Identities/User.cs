namespace Pilot.Domain.Identities;

public class User : BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string LoginName { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Password { get; set; } = "";

    public bool IsSuperAdmin { get; set; } = false;
}
