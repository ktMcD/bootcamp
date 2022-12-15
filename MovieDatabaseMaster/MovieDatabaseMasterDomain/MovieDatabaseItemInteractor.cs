using MovieDatabaseMasterDTO;
using MovieDatabaseMasterRepository;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

// Domain.interactor calls the repo
namespace MovieDatabaseMasterDomain
{
    public class MovieDatabaseItemInteractor
    {
        public MovieDatabaseItemRepository _respository;

        public MovieDatabaseItemInteractor()
        {
            _respository = new MovieDatabaseItemRepository();
        }

        public bool AddNewItem(MovieDatabaseItem itemToAdd)
        {
            if (string.IsNullOrEmpty(itemToAdd.MovieTitle))
            {
                throw new ArgumentException("Title cannot be empty.");
            }
            return _respository.AddItem(itemToAdd);
        }

        public List<MovieDatabaseItem> GetAllItems()
        {
            return _respository.GetAllItems();
        }

        public bool GetTitlesIfExists(string movieTitle, out List<MovieDatabaseItem> itemToReturn)
        {
            IEnumerable<MovieDatabaseItem> movies = new List<MovieDatabaseItem>();
            movies = _respository.SearchMoviesByTitle(movieTitle, out itemToReturn);
            return itemToReturn != null;
        }

        public bool GetGenresIfExists(string movieGenre, out List<MovieDatabaseItem> itemToReturn)
        {
            IEnumerable<MovieDatabaseItem> movies = new List<MovieDatabaseItem>();
            movies = _respository.SearchMoviesByGenre(movieGenre, out itemToReturn);
            return itemToReturn != null;
        }
    }
}