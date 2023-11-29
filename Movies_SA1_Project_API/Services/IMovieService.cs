using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Models;

namespace Movies_SA1_Project_API.Services
{
    public interface IMovieService
    {
        Task<bool> AddMovie(MovieDto movie);
        Task<bool> DeleteMovie(int movieID);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int movieID);
        Task<Movie> GetMovieByName(string movieTitle);
    }
}
