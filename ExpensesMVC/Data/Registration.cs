using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExpensesMVC.Data
{
    public class Registration
    {
        [Required]
        public string Nick { get; set; }
        [Required]
        [DisplayName("Email address")]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [DisplayName("Confirm password")]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }
    }
}
