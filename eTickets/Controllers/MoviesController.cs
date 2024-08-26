using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllMovies = await _service.GetAllAsync(c => c.Cinema);
            return View(AllMovies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string SearchString)
        {
            var AllMovies = await _service.GetAllAsync(c => c.Cinema);

            if (!string.IsNullOrEmpty(SearchString))
            {
                var FilteredMovie = AllMovies.Where(n => n.Name.Contains(SearchString) || n.Description.Contains(SearchString)).ToList();
                return View("Index", FilteredMovie);
            }
            return View("Index", AllMovies);

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var moviedetail =await _service.GetMoviebyIdAsync(id);
            return View(moviedetail);
        }

        public async Task<IActionResult> Create()
        {
            var MovieDropdownsData = await _service.GetNewMovieDropdownsVMValues();
            ViewBag.Cinemas = new SelectList(MovieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(MovieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(MovieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM Movie)
        {
            if (!ModelState.IsValid)
            {
                var MovieDropdownsData = await _service.GetNewMovieDropdownsVMValues();

                ViewBag.Cinemas = new SelectList(MovieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(MovieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(MovieDropdownsData.Actors, "Id", "FullName");

                return View();
            }
            await _service.AddNewMovieAsync(Movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var MovieDetails = await _service.GetMoviebyIdAsync(id);
            if (MovieDetails == null) return View("NotFound");
            var response = new NewMovieVM()
            {
                Id = MovieDetails.Id,
                ImageMovieURL = MovieDetails.ImageMovieURL,
                EndDate = MovieDetails.EndDate,
                StartDate = MovieDetails.StartDate,
                price = MovieDetails.price,
                Description = MovieDetails.Description,
                CinemaId = MovieDetails.CinemaId,
                ProducerId = MovieDetails.ProducerId,
                movieCategory = MovieDetails.movieCategory,
                ActorsIds = MovieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };
            var MovieDropdownsData = await _service.GetNewMovieDropdownsVMValues();

            ViewBag.Cinemas = new SelectList(MovieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(MovieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(MovieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var MovieDropdownsData = await _service.GetNewMovieDropdownsVMValues();

                ViewBag.Cinemas = new SelectList(MovieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(MovieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(MovieDropdownsData.Actors, "Id", "FullName");

                return View();
            }
            await _service.UpdateAsync(movie);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var MovieDetails = await _service.GetMoviebyIdAsync(id);
            if (MovieDetails == null) return View("NotFound");
            var response = new NewMovieVM()
            {
                Id = MovieDetails.Id,
                Name = MovieDetails.Name,   
                ImageMovieURL = MovieDetails.ImageMovieURL,
                EndDate = MovieDetails.EndDate,
                StartDate = MovieDetails.StartDate,
                price = MovieDetails.price,
                Description = MovieDetails.Description,
                CinemaId = MovieDetails.CinemaId,
                ProducerId = MovieDetails.ProducerId,
                movieCategory = MovieDetails.movieCategory,
                ActorsIds = MovieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };
            var MovieDropdownsData = await _service.GetNewMovieDropdownsVMValues();

            ViewBag.Cinemas = new SelectList(MovieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(MovieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(MovieDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id , NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var MovieDropdownsData = await _service.GetNewMovieDropdownsVMValues();

                ViewBag.Cinemas = new SelectList(MovieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(MovieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(MovieDropdownsData.Actors, "Id", "FullName");

                return View();
            }
            await _service.DeleteAsync(movie);
            return RedirectToAction(nameof(Index));

        }
    }
}
