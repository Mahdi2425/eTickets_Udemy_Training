using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IOrdersService 
    {
        Task StoreOrderAsync(List<ShopingCartItem> items , string UserId , string Email);
        Task<List<Order>> GetOrdersWithIdAndRoleAsync(string UserId , string userRole);
    }
}
