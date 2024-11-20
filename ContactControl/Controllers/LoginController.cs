using ContactControl.Models;
using ContactControl.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepo _userRepo;
        public LoginController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepo.SearchLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.IsPasswordCorrect(loginModel.Password))
                            return RedirectToAction("Index", "Home");
                    }

                    TempData["ErrorMessage"] = "Login and/or password incorrect. Please, try again.";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
