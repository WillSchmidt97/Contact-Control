using ContactControl.Models;
using ContactControl.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactControl.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepo _contactRepo;
        public ContactsController(IContactRepo contactRepo) 
        {
            _contactRepo = contactRepo;
        }
        public IActionResult Index()
        {
            List<ContactsModel> contacts = _contactRepo.SearchAll();
            return View(contacts);
        }

        public IActionResult AddCont()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactsModel contact = _contactRepo.ListEachId(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            ContactsModel contact = _contactRepo.ListEachId(id);
            return View(contact);
        }
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool deleted = _contactRepo.DeleteConfirmed(id);
                if (!deleted) 
                {
                    TempData["SuccessMessage"] = "It was not possible deleting this contact.";
                }
                else
                {
                    TempData["SuccessMessage"] = "Contact deleted successfully!";
                }
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult AddCont(ContactsModel contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepo.Adicionar(contacts);
                    TempData["SuccessMessage"] = "Contact added successfully!";
                    return RedirectToAction("Index");
                }
                return (View(contacts));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Change(ContactsModel contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepo.Att(contacts);
                    TempData["SuccessMessage"] = "Contact edited successfully!";
                    return RedirectToAction("Index");
                }

                return (View("Edit", contacts));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
