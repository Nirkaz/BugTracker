namespace BugTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Nickname { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime ProfileCreated { get; set; }
        public DateTime ProfileUpdated { get; set; }
        public DateTime LastLogin { get; set; }

        public List<Bug> Assigned { get; set; }
        public List<Bug> Created { get; set; }
        public List<Bug> Watching { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
