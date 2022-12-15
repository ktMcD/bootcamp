using Microsoft.EntityFrameworkCore;
using MovieDatabaseMasterDTO;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MovieDatabaseMasterRepository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MovieDatabaseItem> Movies { get; set; }

        // also need an empty constructor here
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        private static IConfigurationRoot _configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("MovieDbManager");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

    }
}