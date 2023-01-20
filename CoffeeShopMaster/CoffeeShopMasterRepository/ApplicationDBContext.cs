using Microsoft.EntityFrameworkCore;

namespace CoffeeShopMasterRepository
{
    public class ApplicationDBContext : DbContext
    {
        ApplicationDBContext()
        {

        }

        public ApplicationDBContext (DbContextOptions options ) : base(options) 
        {
            
        }
    }
}