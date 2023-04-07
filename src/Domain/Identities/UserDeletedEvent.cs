namespace Pilot.Domain.Identities;

public class UserDeletedEvent : BaseEvent
{
    public UserDeletedEvent(User user)
    {
        User = user;
    }

    public User User { get; }
}
