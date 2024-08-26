using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
namespace eTickets.Data.ViewComponents
{
    public class ShoppingCartSummary :ViewComponent
    {
        private readonly ShoppingCart _shoppingcart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingcart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var Item = _shoppingcart.GetShopingCartItems();
            return View(Item.Count); 
        }
    }
}
