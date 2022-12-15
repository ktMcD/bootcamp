using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MovieDatabaseMasterRepository
{
    public class MovieDatabaseItemRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        public MovieDatabaseItemRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieDbManager"));
        }

    }
}
