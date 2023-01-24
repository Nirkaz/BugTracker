namespace BugTracker.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Bug Bug { get; set; }
        public User Author { get; set; }
        public List<Comment> Replies { get; set;}

        // attachments?
    }
}
