using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllActors = await _service.GetAllAsync();
            return View(AllActors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,PictureProfileURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null) return View("NotFound");
            return View(ActorDetails);

        }



        public async Task<IActionResult> Update(int id)
        {
            var Updatedetail = await _service.GetByIdAsync(id);
            if (Updatedetail == null) return View("NotFound");
            return View(Updatedetail);
        }

        [HttpPost]  
        public async Task<IActionResult> Update(int id, [Bind("Id,FullName,PictureProfileURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            actor.Id = id;
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var DeleteActor = await _service.GetByIdAsync(id);
            if (DeleteActor == null) return View("NotFound");
            return View(DeleteActor);
        }
        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
