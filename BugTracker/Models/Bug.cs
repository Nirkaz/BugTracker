using BugTracker.Models.Enums;

namespace BugTracker.Models
{
    public class Bug
    {
        int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public Severity Severity { get; set; }
        public Priority Priotity { get; set; }
        public Status Status { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DueDate { get; set; }

        public User Reporter { get; set; }
        public User Assignee { get; set; }

        public List<User> Watchers { get; set; }
        public List<Comment> Comments { get; set; }

        // Labels - Tags?
        // Attachments?
        // Child / linked issues?
        // project?
        // spring?
        // Type?
    }
}
