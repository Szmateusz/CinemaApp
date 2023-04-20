using CinemaApp.Models;
using System.Collections;

namespace CinemaApp.Services
{
    public class ActorsRepository : IActorsRepository
    {
        public readonly DBContext _context;
        public ActorsRepository(DBContext context) {
            _context = context;
        }
        public ActorModel GetActorById(int id)
        {
            return _context.Actors.SingleOrDefault(m => m.ID == id);
        }
        public IEnumerable<ActorModel> GetAllActors()

        {
            return _context.Actors.ToList();
        }
        public void AddActor(ActorModel actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
        public void UpdateActor(ActorModel actor)
        {
            _context.Actors.Update(actor);
            _context.SaveChanges();
        }
        public void DeleteActor(int id)
        {
            var actor = GetActorById(id);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }

    }
}
