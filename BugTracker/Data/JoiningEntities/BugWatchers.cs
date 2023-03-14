using BugTracker.Models;

namespace BugTracker.Data.JoiningEntities;

public class BugWatchers
{
    public int BugId { get; set; }
    public Bug Bug { get; set; }


    public string UserId { get; set; }
    public User User { get; set; }
}
