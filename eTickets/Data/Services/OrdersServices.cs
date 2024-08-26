using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class OrdersServices : IOrdersService
    {
        private readonly AppDbContext _context;
        public OrdersServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersWithIdAndRoleAsync(string UserId , string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n => n.User).ToListAsync();
            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == UserId).ToList();
            }
            return orders;  
        }

        public async Task StoreOrderAsync(List<ShopingCartItem> items, string UserId, string Email)
        {
            var StoreOrders = new Order()
            {
               Email = Email,
               UserId = UserId
            };
            await _context.Orders.AddAsync(StoreOrders);   
            await _context.SaveChangesAsync();  

        foreach (var item in items)
            {
                var orderitem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    Price = item.Movie.price,
                    OrderId = StoreOrders.Id
                };
                await _context.OrderItems.AddAsync(orderitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
