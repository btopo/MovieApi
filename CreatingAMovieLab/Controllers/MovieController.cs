using CreatingAMovieLab.DAL;
using CreatingAMovieLab.Models;
using Microsoft.AspNetCore.Mvc;


namespace CreatingAMovieLab.Controllers
{
    [Route("api/[controller]/[action]")]// by adding the [action] I no longer have to use the Route attribute in the URL use the HttpGet or other CRUD operations
    [ApiController]
    public class MovieController : ControllerBase
    {
        public MoviesContext _moviesContext;


        public MovieController(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }


        [HttpGet()]
        public Movies[] GetMovies()
        {
            return _moviesContext.Movies.ToArray();
        }

        [HttpGet("{Category}")]
        public Movies[] GetMoviesByCategory(string Category)
        {
            Movies[] moviesByCategory = _moviesContext.Movies.Where(m => m.Category.Equals(Category)).ToArray();
            if (moviesByCategory == null)
            {
                throw new Exception($"no movies found for {Category}");
            }
            return moviesByCategory;
        }

        [HttpGet]
        public Movies GetRandomMovie()
        {
            var upperBound = _moviesContext.Movies.Count();
            var randomNumber = new Random().Next(0, upperBound);
            Movies randomMovie = _moviesContext.Movies.ToArray()[randomNumber];
            if (randomMovie == null)
            {
                throw new Exception("no movie found ");
            }
            return randomMovie;
        }


        [HttpGet("{Category}")]
        public Movies GetRandomMovieByCategory(string Category)
        {
            // filter out movies from database by category
            Movies[] moviesByCategory = _moviesContext.Movies.Where(m => m.Category.Equals(Category)).ToArray();
            if (moviesByCategory == null)
            {
                throw new Exception($"no movies found for {Category}");
            }
            // get a random number from the movies database length range
            var randomNumber = new Random().Next(0, moviesByCategory.Length);

            // using the random number to get a random movie from the list by Category
            return moviesByCategory[randomNumber];
        }

        [HttpGet("{Quantity}")]
        public Movies[] GetRandomMovieByQuantity(int quantity)
        {

            Random rnd = new Random();
            List<int> randomInts = new List<int>();
            for (int i = 0; i < quantity; i++)
            {
                randomInts.Add(GenerateRandomNumber());
            }

            Movies[] randomMoviesByQuantity = _moviesContext.Movies
                .Where(x => randomInts.Contains(x.Id))
                .ToArray();
            if (randomMoviesByQuantity == null)
            {
                throw new Exception("no movie found ");
            }
            return randomMoviesByQuantity;
        }

        private int GenerateRandomNumber()
        {
            var upperBound = _moviesContext.Movies.Count();
            return new Random().Next(0, upperBound);
        }

        [HttpGet]
        public List<string> GetAllCategories()
        {
            List<string> listOfAllCategories = _moviesContext.Movies.Select(m => m.Category).ToList();
            if (listOfAllCategories == null)
            {
                throw new Exception("no categories found");
            }
            return listOfAllCategories;
        }

        [HttpGet("{title}")]
        public Movies GetMovieInfo(string title)
        {
           if (string.IsNullOrEmpty(title))
            {
                throw new Exception("must input a title, title was empty or null ");

            } 
            Movies movieInfo = _moviesContext.Movies.FirstOrDefault(m => m.Title.Equals(title));
            if (movieInfo == null)
            {
                throw new Exception("no movie found under that title. ");
            }
            return movieInfo;
        }

        [HttpGet("{keyword}")]
        public Movies[] GetMoviesByKeyword (string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                throw new Exception("must input a keyword, keyword was empty or null ");

            }
            Movies[] movieTitlesByKeyword = _moviesContext.Movies.Where(m => m.Title.Contains(keyword)).ToArray();
            if (movieTitlesByKeyword == null)
            {
                throw new Exception("no movie found under that keyword. ");
            }
            return movieTitlesByKeyword;
        }

    }
}
