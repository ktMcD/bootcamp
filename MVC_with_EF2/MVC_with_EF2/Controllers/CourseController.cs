using Microsoft.AspNetCore.Mvc;
using MVC_with_EF2.Models;
using MVC_with_EF2.DataAccessLayer;


namespace MVC_with_EF2.Controllers
{
    public class CourseController : Controller
    {
        
        private SchoolContext db = new SchoolContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}
