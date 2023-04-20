using CinemaApp.Models;
using System.Collections;

namespace CinemaApp.Services
{
    public class _moviesRepository
    {
        public readonly DBContext _context;
        public _moviesRepository(DBContext context) {
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
        public IEnumerable<MovieModel> GetMoviesByCategory(Enums.Category category) {

            return _context.Movies.Where(c=>c.Category.Equals(category)).ToList();
        }
        public IEnumerable<MovieModel> GetMoviesByAgeCategory(Enums.AgeCategory category)
        {

            return _context.Movies.Where(c => c.AgeCategory.Equals(category)).ToList();
        }
    }
}
