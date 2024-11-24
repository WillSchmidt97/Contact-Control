using ContactControl.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactControl.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionUser = HttpContext.Session.GetString("SessionLogedUser");

            if (string.IsNullOrEmpty(sessionUser)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);

            return View(user);
        }
    }
}
