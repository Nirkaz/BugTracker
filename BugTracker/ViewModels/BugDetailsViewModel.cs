using BugTracker.Models;
using System.Collections;

namespace BugTracker.ViewModels
{
    public class BugDetailsViewModel
    {
        public Bug Bug { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
