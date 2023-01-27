using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
        [Required]
        public Bug Bug { get; set; }
        [Required]
        public User Author { get; set; }
        // public List<Comment> Replies { get; set;}
        // attachments?
    }
}
