using ContactControl.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    [LoggedUser]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
