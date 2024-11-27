using ContactControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ContactControl.Filters
{
    public class RestrictToAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("SessionLogedUser");

            if (!string.IsNullOrEmpty(userSession))
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

                if (user == null)
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });

                if (user.Profile != Enums.ProfileEnum.Admin)
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrict" }, { "action", "Index" } });
            }
            else
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }

            base.OnActionExecuting(context);
        }
    }
}
