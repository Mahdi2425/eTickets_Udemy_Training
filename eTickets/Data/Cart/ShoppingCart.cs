using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context;
        public string ShopingcartId { get; set; }
        public List<ShopingCartItem> shopingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var Context = services.GetService<AppDbContext>();

            string CardId = session.GetString("CardId") ?? Guid.NewGuid().ToString();
            session.SetString("CardId", CardId);
            return new ShoppingCart(Context) { ShopingcartId = CardId };
        }
        
        public void AddItemtoCart(Movie movie)
        {
            var ShopingCartItem = _context.shopingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShopingcartId == ShopingcartId);
            if (ShopingCartItem == null)
            {
                var ShopingcartItem = new ShopingCartItem()
                {
                    Movie = movie,
                    ShopingcartId = ShopingcartId,
                    Amount = 1
                };
                _context.shopingCartItems.Add(ShopingcartItem);
            }
            else
            {
                ShopingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void DeleteItemFromCart(Movie movie)
        {
            var ShopingCartItem = _context.shopingCartItems.FirstOrDefault(n => n.ShopingcartId == ShopingcartId);
            if (ShopingCartItem != null)
            {
                if(ShopingCartItem.Amount > 1)
                {
                    ShopingCartItem.Amount--;
                }
                else
                {
                    _context.shopingCartItems.Remove(ShopingCartItem);
                }
            }
            _context.SaveChanges();
        }
        public List<ShopingCartItem> GetShopingCartItems()
        {
            return shopingCartItems ?? (shopingCartItems = _context.shopingCartItems.Where(n => n.ShopingcartId == ShopingcartId).Include(n => n.Movie).ToList());
        }
         public double GetShopingCartTotal() =>_context.shopingCartItems.Where(n => n.ShopingcartId == ShopingcartId).Select(n => n.Movie.price * n.Amount).Sum();

        public async Task ClearShoppimgCartAsync()
        {
            var item = await _context.shopingCartItems.Where(n => n.ShopingcartId == ShopingcartId).ToListAsync();
            _context.shopingCartItems.RemoveRange(item);
            await _context.SaveChangesAsync();  
        }
    }
}
