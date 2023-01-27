using BugTracker.Models;
using System.Collections;

namespace BugTracker.ViewModels
{
    public class BugCreationViewModel
    {
        public Bug Bug { get; set; }
        public List<User> UsersToAssign { get; set; }
    }
}
