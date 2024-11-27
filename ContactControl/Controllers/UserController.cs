using ContactControl.Filters;
using ContactControl.Models;
using ContactControl.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    [RestrictToAdmin]
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

        public IActionResult Edit(int id)
        {
            UserModel user = _userRepo.ListEachId(id);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            UserModel user = _userRepo.ListEachId(id);
            return View(user);
        }

        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool deleted = _userRepo.DeleteConfirmed(id);
                if (!deleted)
                {
                    TempData["SuccessMessage"] = "It was not possible deleting this user.";
                }
                else
                {
                    TempData["SuccessMessage"] = "User deleted successfully!";
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Change(NoPasswordUserModel noPasswordUser)
        {
            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = noPasswordUser.Id,
                        Name = noPasswordUser.Name,
                        Login = noPasswordUser.Login,
                        Email = noPasswordUser.Email,
                        Profile = noPasswordUser.Profile
                    };

                    user = _userRepo.Att(user);
                    TempData["SuccessMessage"] = "User edited successfully!";
                    return RedirectToAction("Index");
                }

                return (View("Edit", user));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
