using ContactControl.Models;

namespace ContactControl.Repo
{
    public interface IContactRepo
    {
        ContactsModel ListEachId(int id);
        List<ContactsModel> SearchAll();
        ContactsModel Adicionar(ContactsModel contactsModel);
        ContactsModel Att(ContactsModel contacts);
        bool DeleteConfirmed(int id);
    }
}
