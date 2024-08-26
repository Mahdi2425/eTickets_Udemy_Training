using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasServices:EntityBaseRepository<Cinema>,ICinemasServices
    {
        public CinemasServices(AppDbContext context) : base(context) { }
    }
}
