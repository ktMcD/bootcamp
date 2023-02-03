using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assessment5.Models;

namespace Assessment5.Controllers
{
    public class WelcomeController : Controller
    {
        Welcome visitorLogin;
        public WelcomeController()
        {
            visitorLogin = new Welcome();
        }

        // POST: WelcomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {
            try
            {
                Models.Welcome visitorLogin = new Models.Welcome()
                {
                    Name = collection["Name"],
                    Password = collection["Password"],
                    Length = collection["Name"].ToString().Length,
                };
                if (collection["Password"] != "open sesame")
                {
                    return View("WrongPassword");
                }
                return RedirectToAction(nameof(Welcome), visitorLogin);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Welcome(Welcome visitorLogin)
        {
            return View(visitorLogin);
        }

        public ActionResult WrongPassword()
        {
            return View();
        }

    }
}
