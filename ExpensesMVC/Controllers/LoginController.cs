using ExpensesMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var user = await userManager.FindByNameAsync(login.Nick);
            if (user != null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, login.Password);
                if (passwordCheck)
                {
                    var result = await signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Expenses");
                }
                TempData["Error"] = "Wrong email or password!";
                return View(login);
            }
            TempData["Error"] = "Wrong nick or password!";
            return View(login);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration registration)
        {
            if (!ModelState.IsValid)
                return View(registration);

            IdentityUser newUser = new IdentityUser();
            newUser.UserName = registration.Nick;
            var nick = await userManager.FindByNameAsync(registration.Nick);
            if(nick != null)
            {
                TempData["Error"] = "This nick is already taken!";
                return View(registration);
            }

            newUser.Email = registration.Email;
            var email = await userManager.FindByEmailAsync(registration.Email);
            if (email != null)
            {
                TempData["Error"] = "This email is already taken!";
                return View(registration);
            }

            var newUserResponse = await userManager.CreateAsync(newUser, registration.Password);

            if (!newUserResponse.Succeeded)
            {
                TempData["Error"] = "Passwords must have at least one non alphanumeric character, one digit and one uppercase!";
                return View(registration);
            }

            await signInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Expenses");
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
