using CinemaApp.Models;
using System.Collections.Generic;

namespace CinemaApp.Services
{
    public interface IActorsRepository
    {
        ActorModel GetActorById(int id);
        IEnumerable<ActorModel> GetAllActors();
        void AddActor(ActorModel actor);
        void UpdateActor(ActorModel actor);
        void DeleteActor(int id);
    }
}
