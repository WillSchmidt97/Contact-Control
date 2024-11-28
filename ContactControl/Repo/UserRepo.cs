using ContactControl.Data;
using ContactControl.Models;

namespace ContactControl.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;
        public UserRepo(DataContext dataContext) 
        {
            this._context = dataContext;
        }

        public UserModel SearchLogin(string login)
        {
            return _context.Users.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
        }

        public UserModel ListEachId(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public List<UserModel> SearchAll()
        {
            return _context.Users.ToList();
        }
        public UserModel Adicionar(UserModel user)
        {
            user.RegistrationDate = DateTime.Now;
            user.SetPasswordHash();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserModel Att(UserModel user)
        {
            UserModel userDB = ListEachId(user.Id);
            if (userDB == null) throw new Exception("System failed trying to att the user.");

            userDB.Name = user.Name;
            userDB.Email = user.Email;
            userDB.Login = user.Login;
            userDB.Profile = user.Profile;
            userDB.EditDate = DateTime.Now;

            _context.Users.Update(userDB);
            _context.SaveChanges();
            return userDB;
        }

        public bool DeleteConfirmed(int id)
        {
            UserModel userDB = ListEachId(id);
            if (userDB == null) throw new Exception("System failed trying to remove the user.");

            _context.Users.Remove(userDB);
            _context.SaveChanges();
            return true;
        }
    }
}
