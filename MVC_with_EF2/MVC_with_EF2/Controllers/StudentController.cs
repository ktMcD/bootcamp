using Microsoft.AspNetCore.Mvc;
using MVC_with_EF2.DataAccessLayer;

namespace MVC_with_EF2.Controllers
{

    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public IActionResult Index()
        {
            return View(db.Students.ToList());
        }
    }
}
