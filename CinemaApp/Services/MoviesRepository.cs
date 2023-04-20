using CinemaApp.Models;
using System.Collections;

namespace CinemaApp.Services
{
    public class MoviesRepository : IMoviesRepository
    {
        public readonly DBContext _context;
        public MoviesRepository(DBContext context)
        {
            _context = context;
        }
        public MovieModel GetMovieById(int id)
        {
            return _context.Movies.SingleOrDefault(m => m.ID == id);
        }
        public IEnumerable<MovieModel> GetAllMovies()

        {
            return _context.Movies.ToList();
        }
        public IEnumerable<MovieModel> GetMoviesByCategory(Enums.Category category)
        {

            return _context.Movies.Where(c => c.Category.Equals(category)).ToList();
        }
        public IEnumerable<MovieModel> GetMoviesByAgeCategory(Enums.AgeCategory category)
        {

            return _context.Movies.Where(c => c.AgeCategory.Equals(category)).ToList();
        }
        public void AddMovie(MovieModel movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public void UpdateMovie(MovieModel movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
        public void DeleteMovie(int id)
        {
            var movie = GetMovieById(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
