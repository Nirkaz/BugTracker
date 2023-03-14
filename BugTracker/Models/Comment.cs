using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models;

public class Comment
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; }
    public required Bug Bug { get; set; }
    public required User Author { get; set; }
}
