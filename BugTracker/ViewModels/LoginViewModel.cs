using System.ComponentModel.DataAnnotations;

namespace BugTracker.ViewModels;

public class LoginViewModel
{
    [EmailAddress]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
