using BugTracker.Data.JoiningEntities;
using BugTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models;

public class Bug
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required Severity Severity { get; set; }
    public required Priority Priotity { get; set; }
    public required Status Status { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; }
    public DateTime DueDate { get; set; }

    public required User Reporter { get; set; }
    public required User Assignee { get; set; }

    public List<BugWatchers> BugWatchers { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}
