using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        public Task<Movie> GetMoviebyIdAsync(int id);
        public Task<NewMovieDropdownsVM> GetNewMovieDropdownsVMValues();
        public Task AddNewMovieAsync(NewMovieVM Data);
        public Task UpdateAsync(NewMovieVM Data);
        public Task DeleteAsync(NewMovieVM Data);
    }
}
