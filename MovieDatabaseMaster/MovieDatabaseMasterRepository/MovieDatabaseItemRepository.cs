using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieDatabaseMasterDTO;


namespace MovieDatabaseMasterRepository
{
    public class MovieDatabaseItemRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        public static Microsoft.EntityFrameworkCore.DbFunctions EfFunctions { get; }
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
        public bool AddItem(MovieDatabaseItem itemToAdd)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                //determine if item exists
                MovieDatabaseItem existingItem = db.Movies.FirstOrDefault(x => x.MovieTitle.ToLower() == itemToAdd.MovieTitle.ToLower());
                if (existingItem == null)
                {
                    // doesn't exist, add it
                    db.Movies.Add(itemToAdd);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<MovieDatabaseItem> GetAllItems()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Movies.ToList();
            }
        }

        public List<MovieDatabaseItem> SearchMoviesByTitle (string movieTitle, out List<MovieDatabaseItem> titlesFound)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                titlesFound = db.Movies.Where(x => x.MovieTitle.Contains(movieTitle)).ToList();
            }
            return titlesFound;
        }

        public List<MovieDatabaseItem> SearchMoviesByGenre(string movieGenre, out List<MovieDatabaseItem> genresFound)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                genresFound = db.Movies.Where(x => x.Genre.Contains(movieGenre)).ToList();
            }
            return genresFound;
        }
    }
}
