using BugTracker.Data.JoiningEntities;
using BugTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public Role Role { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FistName { get; set; }
        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
        public DateTime LastLogin { get; set; }

        public List<Bug> CreatedBugs { get; set; } = new();
        public List<Bug> AssignedBugs { get; set; } = new();
        public List<BugWatchers> WatchedBugs { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
    }
}
