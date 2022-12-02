using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpensesMVC.Data
{
    public class ExpenseVM
    {
        public decimal TotalPrice { get; set; }
        public string CurrentMonth { get; set; }
        public string MonthToDisplay { get; set; }
        public string MonthToDisplayIntString { get; set; }

        public List<Expense> Expenses = new List<Expense>();
    }
}
