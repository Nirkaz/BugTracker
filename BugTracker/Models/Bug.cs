using BugTracker.Data.JoiningEntities;
using BugTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Bug
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Severity Severity { get; set; }
        [Required]
        public Priority Priotity { get; set; }
        [Required]
        public Status Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
        public DateTime DueDate { get; set; }

        [Required]
        public User Reporter { get; set; }
        [Required]
        public User Assignee { get; set; }

        public List<BugWatchers> BugWatchers { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();

        // Labels - Tags?
        // Attachments?
        // Child / linked issues?
        // project?
        // spring?
        // Type?
    }
}
