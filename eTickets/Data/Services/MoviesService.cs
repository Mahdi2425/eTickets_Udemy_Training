using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, IMoviesService 
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM Data)
        {
            var NewMovie = new Movie()
            {
                Name = Data.Name,
                StartDate = Data.StartDate,
                EndDate = Data.EndDate,
                movieCategory = Data.movieCategory,
                price = Data.price,
                ProducerId = Data.ProducerId,
                CinemaId = Data.CinemaId,
                ImageMovieURL = Data.ImageMovieURL, 
                Description = Data.Description
            };
            await _context.Movies.AddAsync(NewMovie);
            await _context.SaveChangesAsync();
            foreach (var actorId in Data.ActorsIds)
            {
                var NewActorMovie = new Actor_Movie()
                {
                    MovieId = NewMovie.Id,
                    ActorId = actorId,
                };
                await _context.Actors_Movies.AddAsync(NewActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(NewMovieVM Data)
        {
            var ExistingMovies = _context.Movies.Where(n => n.Id == Data.Id);
            _context.Movies.RemoveRange(ExistingMovies);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMoviebyIdAsync(int id)
        {
            var moviedetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p=>p.Producer)
                .Include(am=>am.Actors_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n  => n.Id == id);
            return (moviedetails);
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsVMValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(a => a.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(a => a.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateAsync(NewMovieVM Data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == Data.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = Data.Name;
                dbMovie.StartDate = Data.StartDate;
                dbMovie.EndDate = Data.EndDate;
                dbMovie.movieCategory = Data.movieCategory;
                dbMovie.price = Data.price;
                dbMovie.ProducerId = Data.ProducerId;
                dbMovie.CinemaId = Data.CinemaId;
                dbMovie.ImageMovieURL = Data.ImageMovieURL;
                dbMovie.Description = Data.Description;
                await _context.SaveChangesAsync();
            }
                var ExistingActors = _context.Actors_Movies.Where(n => n.MovieId == Data.Id);
                _context.Actors_Movies.RemoveRange(ExistingActors);
                await _context.SaveChangesAsync();
            
            foreach (var actorId in Data.ActorsIds)
            {
                var NewActorMovie = new Actor_Movie()
                {
                    MovieId = Data.Id,
                    ActorId = actorId,
                };
                await _context.Actors_Movies.AddAsync(NewActorMovie);
            }
            await _context.SaveChangesAsync();

        }
    }
}
