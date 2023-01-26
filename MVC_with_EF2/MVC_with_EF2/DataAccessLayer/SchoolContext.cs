using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace MVC_with_EF2.DataAccessLayer
{
    public class SchoolContext : DbContext
    { 

        // empty constructor required - must be first method
        public SchoolContext()
        {

        }
        public SchoolContext(DbContextOptions options) : base(options)
        {

        }

        private static IConfigurationRoot _configuration;
        // <Student> is the model class name, "Students" is the database name
        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                // "SchoolDb" matches the left side of the connection string assignment in appsettings.json
                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("SchoolDb");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
    }

}
