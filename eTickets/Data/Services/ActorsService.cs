using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>,IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
