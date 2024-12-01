using ContactControl.Models;

namespace ContactControl.Repo
{
    public interface IContactRepo
    {
        ContactsModel ListEachId(int id);
        List<ContactsModel> SearchAll();
        List<ContactsModel> SearchUserContacts(int userId);
        ContactsModel Adicionar(ContactsModel contactsModel);
        ContactsModel Att(ContactsModel contacts);
        bool DeleteConfirmed(int id);
    }
}
