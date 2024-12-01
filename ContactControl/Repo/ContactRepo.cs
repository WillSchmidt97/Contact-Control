using ContactControl.Data;
using ContactControl.Helpers;
using ContactControl.Models;

namespace ContactControl.Repo
{
    public class ContactRepo : IContactRepo
    {
        private readonly DataContext _context;
        public ContactRepo(DataContext dataContext) 
        {
            this._context = dataContext;
        }

        public ContactsModel ListEachId(int id)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == id);
        }
        public List<ContactsModel> SearchAll()
        {
            return _context.Contacts.ToList();
        }
        public List<ContactsModel> SearchUserContacts(int userId)
        {
            return _context.Contacts.Where(u => u.UserId== userId).ToList();
        }
        public ContactsModel Adicionar(ContactsModel contacts)
        {
            #region Session
            var httpContextAccessor = new HttpContextAccessor();
            var session = new Session(httpContextAccessor);
            UserModel user = session.SearchUserSession();
            #endregion

            contacts.UserId= user.Id;
            _context.Contacts.Add(contacts);
            _context.SaveChanges();
            return contacts;
        }

        public ContactsModel Att(ContactsModel contacts)
        {
            ContactsModel contactDB = ListEachId(contacts.Id);
            if (contactDB == null) throw new Exception("System failed trying to att your contact.");

            contactDB.Name = contacts.Name;
            contactDB.Email = contacts.Email;
            contactDB.Phone = contacts.Phone;
            contactDB.Postalcode = contacts.Postalcode;
            contactDB.Address = contacts.Address;

            _context.Contacts.Update(contactDB);
            _context.SaveChanges();
            return contactDB;
        }

        public bool DeleteConfirmed(int id)
        {
            ContactsModel contactDB = ListEachId(id);
            if (contactDB == null) throw new Exception("System failed trying to remove your contact.");

            _context.Contacts.Remove(contactDB);
            _context.SaveChanges();
            return true;
        }
    }
}
