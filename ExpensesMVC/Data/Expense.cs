using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpensesMVC.Data
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Precision(5,2)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }

    }
}
