using ContactControl.Models;
using ContactControl.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepo.SearchAll();
            return View(users);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepo.Adicionar(user);
                    TempData["SuccessMessage"] = "User created successfully!";
                    return RedirectToAction("Index");
                }
                return (View(user));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
