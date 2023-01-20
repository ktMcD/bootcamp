using Microsoft.AspNetCore.Mvc;

namespace DungeonMasterWebApp.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
