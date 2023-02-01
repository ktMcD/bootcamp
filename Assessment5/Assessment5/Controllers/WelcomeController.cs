using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assessment5.Models;

namespace Assessment5.Controllers
{
    public class WelcomeController : Controller
    {
        // POST: WelcomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Login(int id, IFormCollection collection)
        {

            Models.Welcome visitorLogin = new Models.Welcome()
            {
                Name = collection["Name"],
                Password = collection["Password"],
                Length = collection["Name"].ToString().Length,
            };

            Welcome(visitorLogin);
        }

        public ActionResult Welcome(Welcome visitorLogin)
        {
            if (visitorLogin.Password != "open sesame")
            {
                return RedirectToAction(nameof(WrongPassword));
            }
            else
            {
                return View(visitorLogin.Name);
            }
            
        }

        // GET: WelcomeController/Create
        public ActionResult WrongPassword()
        {
            return View();
        }
    }
}
