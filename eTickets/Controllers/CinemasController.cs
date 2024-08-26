using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemasServices _service;
        public CinemasController(ICinemasServices service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllCinemas = await _service.GetAllAsync();
            return View(AllCinemas);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,CinemaLogoURL,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("NotFound");
            return View(CinemaDetails);
        }

        public async Task<IActionResult> Update(int id)
        {
            var Updatedetail = await _service.GetByIdAsync(id);
            if (Updatedetail == null) return View("NotFound");
            return View(Updatedetail);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("Id,Name,CinemaLogoURL,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            cinema.Id = id;
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var DeleteCinema = await _service.GetByIdAsync(id);
            if (DeleteCinema == null) return View("NotFound");
            return View(DeleteCinema);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
