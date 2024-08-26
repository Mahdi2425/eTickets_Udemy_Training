using eTickets.Data;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View("NotFound");
            }
            if (loginVM != null)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.Emailadrress);
                if (user != null)
                {
                    var passwordcheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordcheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Movies");
                        }
                    }
                    TempData["Error"] = "Wrong creadintials. please try again!";
                    return View(loginVM);
                }
                TempData["Error"] = "Wrong creadintials. please try again!";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong creadintials. please try again!";
            return View(loginVM);
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var user = await _userManager.FindByEmailAsync(registerVM.Emailadrress);
            if (user != null)
            {
                TempData["Error"] = "The email address is already in use";
                return View(registerVM);
            }
            var NewUser = new ApplicationUser()
            {
                FullName = registerVM.Fullname,
                Email = registerVM.Emailadrress,
                UserName = registerVM.Emailadrress
            };
            var adduser = await _userManager.CreateAsync(NewUser, registerVM.Password);
            if (adduser.Succeeded)
                await _userManager.AddToRoleAsync(NewUser, UserRoles.User);
            return View("RegisterCompleted");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public IActionResult AccessDenied(string RetunUrl)
        {
            return View();
        }
    }
}
