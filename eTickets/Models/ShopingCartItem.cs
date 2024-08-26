using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class ShopingCartItem
    {
        [Key]
        public int Id { get; set; }
        public string ShopingcartId { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
    }
}
