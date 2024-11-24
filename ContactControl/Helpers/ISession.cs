using ContactControl.Models;

namespace ContactControl.Helpers
{
    public interface ISession
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession();
        UserModel SearchUserSession();
    }
}
