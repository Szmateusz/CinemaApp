using CinemaApp.Models;
using System.Collections.Generic;

namespace CinemaApp.Services
{
    public interface IMoviesRepository
    {
        MovieModel GetMovieById(int id);
        IEnumerable<MovieModel> GetAllMovies();
        IEnumerable<MovieModel> GetMoviesByCategory(Enums.Category category);
        IEnumerable<MovieModel> GetMoviesByAgeCategory(Enums.AgeCategory category);

        void AddMovie(MovieModel movie);
        void UpdateMovie(MovieModel movie);
        void DeleteMovie(int id);
    }
}
