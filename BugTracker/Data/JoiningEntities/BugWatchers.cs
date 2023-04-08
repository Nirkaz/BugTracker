using BugTracker.Models;

namespace BugTracker.Data.JoiningEntities;

public class BugWatchers
{
    public int BugId { get; set; }
    public Bug Bug { get; set; } = default!;

    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
