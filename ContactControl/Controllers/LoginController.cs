﻿using ContactControl.Models;
using ContactControl.Repo;
using ContactControl.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly Helpers.ISession _session;
        public LoginController(IUserRepo userRepo, Helpers.ISession session)
        {
            _userRepo = userRepo;
            _session = session;
        }
        public IActionResult Index()
        {
            return _session.SearchUserSession() != null ? RedirectToAction("Index", "Home") : View();
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
                        {
                            _session.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }
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

        public IActionResult Logout()
        {
            _session.RemoveUserSession();

            return RedirectToAction("Index");
        }
    }
}