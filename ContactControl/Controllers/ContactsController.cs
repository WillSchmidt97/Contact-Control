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
            _contactRepo.DeleteConfirmed(id);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult AddCont(ContactsModel contacts)
        {
            _contactRepo.Adicionar(contacts);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Change(ContactsModel contacts)
        {
            _contactRepo.Att(contacts);
            return RedirectToAction("Index");
        }

    }
}
