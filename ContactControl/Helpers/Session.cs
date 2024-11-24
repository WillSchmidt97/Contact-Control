using ContactControl.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ContactControl.Helpers
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;
        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void CreateUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("SessionLogedUser", value);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("SessionLogedUser");
        }

        public UserModel SearchUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("SessionLogedUser");

            return string.IsNullOrEmpty(userSession) ? null : JsonConvert.DeserializeObject<UserModel>(userSession);
        }
    }
}
