using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data.External.Movies;
using MovieApp.ExternalServices.OMDB;
using MovieApp.Services.Reviews;

namespace MovieApp.Controllers
{

    public class MovieController : Controller
    {
        private readonly MovieService _movieService;
        private readonly ReviewService _reviewService;

        public MovieController(MovieService movieService,ReviewService reviewService)
        {
            _movieService = movieService;
            _reviewService = reviewService;
        }
        // GET: MovieController
        [Route("movies")]
        public async Task<ActionResult> Index()
        {
            var movieIds = await _reviewService.GetMostRatedNMovieIdsAsync();
            movieIds.Add("tt0371746");
            movieIds.Add("tt0117571");
            movieIds.Add("tt2975976");
            movieIds.Add("tt4332232");
            movieIds.Add("tt0848228");

            
            List<Movie> movies = new List<Movie>();
            foreach(var id in movieIds)
            {
                movies.Add(await _movieService.GetMovieByIdAsync(id));
            }
            return View(movies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
