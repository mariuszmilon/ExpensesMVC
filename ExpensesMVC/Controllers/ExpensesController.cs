using ExpensesMVC.Data;
using ExpensesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesMVC.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpensesContext _context;

        public ExpensesController(ExpensesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, startDate.Month, 1);
            var endDate = startDate.AddMonths(1);

            var currentUser = HttpContext?.User;
            var currentUserName = currentUser.Identity.Name;

            var expenses = _context.Expenses.Where(x => x.DateOfPurchase >= startDate && x.DateOfPurchase < endDate && x.Author == currentUserName);
            var expensesVM = new ExpenseVM();
            var currentMonth = DateTime.Now.Month;
            expensesVM.CurrentMonth = Enum.GetName(typeof(Months), currentMonth);
            expensesVM.TotalPrice = 0;
            foreach (var item in expenses)
            {
                expensesVM.Expenses.Add(item);
                expensesVM.TotalPrice += item.Price;
            }

            return View(expensesVM);
        }

        public IActionResult Index2(string MonthToDisplay)
        {
            var monthToDisplayInt = int.Parse(MonthToDisplay);
            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, monthToDisplayInt, 1);
            var endDate = startDate.AddMonths(1);

            var currentUser = HttpContext?.User;
            var currentUserName = currentUser.Identity.Name;

            var expenses = _context.Expenses.Where(x => x.DateOfPurchase >= startDate && x.DateOfPurchase < endDate && x.Author == currentUserName);
            var expensesVM = new ExpenseVM();
            expensesVM.MonthToDisplayIntString = MonthToDisplay;
            var currentMonth = DateTime.Now.Month;
            expensesVM.CurrentMonth = Enum.GetName(typeof(Months), currentMonth);
            expensesVM.MonthToDisplay = Enum.GetName(typeof(Months), monthToDisplayInt);
            expensesVM.TotalPrice = 0;
            foreach (var item in expenses)
            {
                expensesVM.Expenses.Add(item);
                expensesVM.TotalPrice += item.Price;
            }

            return View(expensesVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            if (!ModelState.IsValid)
                return View(expense);

            Expense newExpense = new Expense();
            newExpense.Title = expense.Title;
            newExpense.Description = expense.Description;
            newExpense.Price = expense.Price;
            newExpense.DateOfPurchase = DateTime.Now;
            var currentUser = HttpContext?.User;
            var currentUserName = currentUser.Identity.Name;
            newExpense.Author = currentUserName;

            _context.Add(newExpense);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.Expenses.FirstOrDefault(e => e.Id == id);
            _context.Expenses.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(b => b.Id == id);
            return View(expense);
        }

        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            if (!ModelState.IsValid)
                return View(expense);


            expense.DateOfPurchase = DateTime.Now;
            _context.Update(expense);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}
