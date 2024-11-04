using ContactControl.Models;

namespace ContactControl.Repo
{
    public interface IUserRepo
    {
        List<UserModel> SearchAll();
        UserModel ListEachId(int id);
        UserModel Adicionar(UserModel user);
        UserModel Att(UserModel user);
        bool DeleteConfirmed(int id);
    }
}
