using CinemaApp.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
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
            return _context.Movies.Include(a => a.Actors).Include(s => s.Schedules).Include(r => r.Reviews).SingleOrDefault(m => m.ID == id);
        }
        public IEnumerable<MovieModel> GetAllMovies()

        {
            return _context.Movies.Include(a=>a.Actors).Include(s=>s.Schedules).Include(r=>r.Reviews).ToList();
        }
        public IEnumerable<MovieModel> GetMoviesByCategory(Enums.Category category)
        {

            return _context.Movies.Include(a => a.Actors).Include(s => s.Schedules).Include(r => r.Reviews).Where(c => c.Category.Equals(category)).ToList();
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
