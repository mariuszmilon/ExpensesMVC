using System.ComponentModel.DataAnnotations;

namespace ExpensesMVC.Data
{
    public class Login
    {
        [Required]
        public string Nick { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
