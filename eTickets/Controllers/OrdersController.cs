using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _MovieService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _orderservice;
        public OrdersController(IMoviesService MoviesService,ShoppingCart shopingCart,IOrdersService ordersService)
        {
            _MovieService = MoviesService;
            _shoppingCart = shopingCart;
            _orderservice = ordersService;  
        }

        public async Task<IActionResult> Index()
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _orderservice.GetOrdersWithIdAndRoleAsync(UserId , userRole);
            return View(orders);


        }
        public IActionResult ShoppingCart()
        {
            var Items = _shoppingCart.GetShopingCartItems();
            _shoppingCart.shopingCartItems = Items;
            var Response = new NewShoppingCartVM()
            {
                shoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShopingCartTotal(),
            };
            return View(Response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var Item = await _MovieService.GetMoviebyIdAsync(id);

            if (Item != null)
            {
                _shoppingCart.AddItemtoCart(Item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            var Item = await _MovieService.GetMoviebyIdAsync(id);

            if (Item != null)
            {
                _shoppingCart.DeleteItemFromCart(Item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> OrderCompleted() 
        { 
            var item = _shoppingCart.GetShopingCartItems();
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string Email = User.FindFirstValue(ClaimTypes.Email);
            await _orderservice.StoreOrderAsync(item, UserId, Email);
            await _shoppingCart.ClearShoppimgCartAsync();
            return View("OrderCompleted");
        }
    }
}
