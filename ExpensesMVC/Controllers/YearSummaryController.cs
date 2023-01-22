using Microsoft.AspNetCore.Mvc;
using ExpensesMVC.Data;
using ExpensesMVC.Models;

namespace ExpensesMVC.Controllers
{
    public class YearSummaryController : Controller
    {
        private readonly ExpensesContext _context;

        public YearSummaryController(ExpensesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var currentUser = HttpContext?.User;
            var currentUserName = currentUser.Identity.Name;

            var results = _context.Expenses.Where(e => e.Author == currentUserName);
            var totalMonthCost = new TotalCostYears();

            foreach (var item in results)
            {
                if((item.DateOfPurchase >= AllMonths.January) && (item.DateOfPurchase < AllMonths.February))
                {
                    totalMonthCost.January += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.February) && (item.DateOfPurchase < AllMonths.March))
                {
                    totalMonthCost.February += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.March) && (item.DateOfPurchase < AllMonths.April))
                {
                    totalMonthCost.March += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.April) && (item.DateOfPurchase < AllMonths.May))
                {
                    totalMonthCost.April += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.May) && (item.DateOfPurchase < AllMonths.June))
                {
                    totalMonthCost.May += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.June) && (item.DateOfPurchase < AllMonths.July))
                {
                    totalMonthCost.June += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.July) && (item.DateOfPurchase < AllMonths.August))
                {
                    totalMonthCost.July += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.August) && (item.DateOfPurchase < AllMonths.September))
                {
                    totalMonthCost.August += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.September) && (item.DateOfPurchase < AllMonths.October))
                {
                    totalMonthCost.September += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.October) && (item.DateOfPurchase < AllMonths.November))
                {
                    totalMonthCost.October += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.November) && (item.DateOfPurchase < AllMonths.December))
                {
                    totalMonthCost.November += item.Price;
                }

                if ((item.DateOfPurchase >= AllMonths.December) && (item.DateOfPurchase < AllMonths.January2))
                {
                    totalMonthCost.December += item.Price;
                }
            }

            return View(totalMonthCost);
        }
    }
}
