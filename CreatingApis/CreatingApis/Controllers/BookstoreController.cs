using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreatingApis.Models;

namespace CreatingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreController : ControllerBase
    {
        [HttpPost("add")]
        public Bookstore AddStore(string name, string category, string location)
        {
            return Bookstore.AddBookstore(name, category, location);
        }

        [HttpPost("get")]
        public Bookstore FindById(int id)
        {
            return Bookstore.FindById(id);
        }

        [HttpPost("get")]
        public List<Bookstore> FindByLocation(string location)
        {
            return Bookstore.FindbyLocation(location);
        }

        [HttpPost("get")]
        public List<Bookstore> FindByName(string name)
        {
            return Bookstore.FindbyName(name);
        }
    }
}
