using MovieDatabaseMasterDTO;
using MovieDatabaseMasterDomain;
using MovieDatabaseMasterRepository;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace MovieDatabaseMaster
{
    internal class Program
    {
        MovieDatabaseItemInteractor _movieItemInteractor = new MovieDatabaseItemInteractor();
        public static void Main(string[] args)
        {
            Program DatabaseConsole = new Program();
            bool viewConsoleMenu = true;
            string consoleResponse;
            // DatabaseConsole.InsertMovieRecords();
            // Console.ReadKey();
            DatabaseConsole.DisplayAllItems();
            Console.ReadKey();
            while (viewConsoleMenu)
            {
                viewConsoleMenu = false;
                consoleResponse = DatabaseConsole.ConsoleMenu(); // Gets response and validates range
                                                                 // we won't get here unless we have a valid response
                DatabaseConsole.InitiateMenuSelection(consoleResponse.ToLower());
                viewConsoleMenu = Navigator.TryAgain("");
                if (!viewConsoleMenu)
                {
                    Navigator.ThankYouAndGoodbye();
                }
            }
        }

        private List<MovieDatabaseItem> BuildItemCollection()
        {
            List<MovieDatabaseItem> initialItems = new List<MovieDatabaseItem>();
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Die Hard", Genre = "Action, Drama", Runtime = 132 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Unforgiven", Genre = "Western, Drama", Runtime = 130 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Heavy Metal", Genre = "Fantasy, Sci-Fi, Animation", Runtime = 90 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Galaxy Quest", Genre = "Comedy, Sci-Fi", Runtime = 102 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Modern Times", Genre = "Comedy, Drama, Romance", Runtime = 87 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Monty Python and the Holy Grail", Genre = "Comedy, Adventure, Fantasy", Runtime = 91 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Monsters, Inc.", Genre = "Comedy, Animation, Adventure", Runtime = 92 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Dr. Strangelove", Genre = "Comedy, War", Runtime = 95 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Finding Nemo", Genre = "Comedy, Animation, Adventure", Runtime = 100 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Groundhog Day", Genre = "Comedy, Drama, Fantasy", Runtime = 101 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Scrooged", Genre = "Comedy, Romance, Holiday", Runtime = 101 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "The Sixth Sense", Genre = "Drama, Mystery, Thriller, Fantasy", Runtime = 107 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Young Frankenstein", Genre = "Comedy, Romance", Runtime = 106 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Bladerunner", Genre = "Action, Sci-Fi", Runtime = 117 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "Joker", Genre = "Crime, Drama, Thriller", Runtime = 122 });
            initialItems.Add(new MovieDatabaseItem() { MovieTitle = "The Shining", Genre = "Drama, Horror", Runtime = 136 });
            return initialItems;
        }
        void InsertMovieRecords()
        {
            foreach (MovieDatabaseItem movie in BuildItemCollection())
            {
                if (_movieItemInteractor.AddNewItem(movie) == true)
                {
                    Communicator.TalkToUser($"{movie.MovieTitle}: Yep!");
                }
                else
                {
                    Communicator.TalkToUser($"{movie.MovieTitle}: It's ok, baby. You tried.");
                }
            }
        }

        void DisplayAllItems()
        {
            Communicator.TalkToUser("");
            Communicator.TalkToUser("The following items are in the database");
            foreach (MovieDatabaseItem movie in _movieItemInteractor.GetAllItems())
            {
                Console.WriteLine($" - {movie.MovieTitle,-31} | {movie.Genre,-33} | Runtime: {movie.Runtime,-3} min.");
            }
        }

        void DisplayTitleInformation(string movieTitle)
        {
            Communicator.TalkToUser("");
            Communicator.TalkToUser($"Searching for {movieTitle}");
            bool doesMovieExist = _movieItemInteractor.GetTitlesIfExists(movieTitle, out List<MovieDatabaseItem> movies);
            if (doesMovieExist)
            {
                foreach (MovieDatabaseItem movie in movies)
                {
                    Console.WriteLine($" - {movie.MovieTitle,-31} | {movie.Genre,-33} | Runtime: {movie.Runtime,-3} min.");
                }
                    
            }
            else
            {
                Communicator.TalkToUser("Nothing with that title exists in the library");
            }
        }

        void DisplayGenreInformation(string movieGenre)
        {
            Communicator.TalkToUser("");
            Communicator.TalkToUser($"Searching for movie genre {movieGenre}");
            Communicator.TalkToUser("");
            bool doesMovieExist = _movieItemInteractor.GetGenresIfExists(movieGenre, out List<MovieDatabaseItem> movies);
            if (doesMovieExist)
            {
                foreach (MovieDatabaseItem movie in movies)
                    Console.WriteLine($" - {movie.MovieTitle,-31} | {movie.Genre,-33} | Runtime: {movie.Runtime,-3} min.");
            }
            else
            {
                Communicator.TalkToUser("Sorry, we don't carry anything in that genre.");
                Communicator.TalkToUser("");
            }
        }

        public string ConsoleMenu()
        {
            string menuSelection;
            Console.WriteLine("  ------------------------------");
            {
                Console.WriteLine($"{" |  ",1}{"A",-1} {"List Movies",-25}{"|",2}");
                Console.WriteLine($"{" |  ",1}{"B",-1} {"Search movies by title",-25}{"|",2}");
                Console.WriteLine($"{" |  ",1}{"C",-1} {"Search movies by genre",-25}{"|",2}");
                Console.WriteLine($"{" |  ",1}{"Q or X to Quit",-26} {"|",2}");
            }
            Console.WriteLine("  ------------------------------");
            Communicator.TalkToUser("What would you like to do today?");
            Communicator.TalkToUser("");
            menuSelection = GetMenuSelection();
            return menuSelection;
        }

        public string GetMenuSelection()
        {
            string userResponse = "";
            bool enterResponseAgain = true;
            while (enterResponseAgain)
            {
                enterResponseAgain = false;
                userResponse = Communicator.ListenToUser();
                Communicator.TalkToUser("Your selection: ", userResponse);
                userResponse = Validator.ValidatePatronResponse(userResponse.ToLower());
                if (userResponse == "?")
                {
                    enterResponseAgain = Navigator.TryAgain("invalid entry");
                    if (!enterResponseAgain)
                    {
                        Navigator.ThankYouAndGoodbye();
                    }
                }

                return userResponse;
            }

            return userResponse;
        }

        public void InitiateMenuSelection(string whatToDo)
        {
            switch (whatToDo)
            {
                case "a":
                    DisplayAllItems();
                    break;
                case "b":
                    GetMovieSearchValue("title");
                    break;
                case "c":
                    GetMovieSearchValue("genre");
                    break;
                case "q":
                case "x":
                    Navigator.ThankYouAndGoodbye();
                    break;
            }
        }

        public void GetMovieSearchValue(string titleOrGenre)
        {
            string userResponse;
            if (titleOrGenre == "title")
            {
                Communicator.TalkToUser("What movie title are you looking for?");
                userResponse = Communicator.ListenToUser();
                DisplayTitleInformation(userResponse);
            }
            else
            {
                Communicator.TalkToUser("What genre are you looking for?");
                userResponse = Communicator.ListenToUser();
                DisplayGenreInformation(userResponse);
            }
        }
    }
}