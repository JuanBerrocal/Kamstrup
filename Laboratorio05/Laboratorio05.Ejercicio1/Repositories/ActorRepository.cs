using Laboratorio05.Ejercicio1.Contracts;
using Laboratorio05.Ejercicio1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Laboratorio05.Ejercicio1.Repositories
{
    public class ActorRepository : IActorRepository
    {
        const string JSON_PATH = @"C:\Development\.net\kamstrup\Laboratorio05\Laboratorio05.Ejercicio1\Resources\Actores.json";

        private string ReadActorsFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }
        private void UpdateActorsInFile(List<Actor> actors)
        {
            var actorsJson = JsonConvert.SerializeObject(actors, Formatting.Indented); ;
            File.WriteAllText(JSON_PATH, actorsJson);
        }
        public void AddActor(Actor actor)
        {
            try
            {
                var actors = GetActors();
                var actorExists = actors.Exists(a => a.Id == actor.Id);
                if (actorExists)
                {
                    throw new Exception("Ese actor ya existe");
                }
                actors.Add(actor);
                UpdateActorsInFile(actors);
            }
            catch
            {
                throw;
            }

        }

        public void DeleteActor(int id)
        {
            //throw new NotImplementedException();
            try
            {
                List<Actor> actors = GetActors();
                int removed = actors.RemoveAll(actor => actor.Id == id);
                if (removed == 0) 
                { 
                    throw new Exception("Ese actor no existe"); 
                }
                UpdateActorsInFile(actors);
            }
            catch
            {
                throw;
            }
        }

        public Actor GetActorById(int id)
        {
            try
            {
                List<Actor> actors = GetActors();
                var actor = actors.FirstOrDefault(actor => actor.Id == id);
                if (actor == null) { throw new Exception("Ese actor no existe"); }
                return actor;
            }
            catch 
            {
                throw;
            }
        }

        public List<Actor> GetActors()
        {
            try
            { 
                var actorsFromFile = ReadActorsFromFile();
                List<Actor> actors = JsonConvert.DeserializeObject<List<Actor>>(actorsFromFile);
                return actors;
            }
            catch
            {
                throw;
            }

        }

        public void UpdateActor(Actor actorP)
        {
            try
            {
                List<Actor> actors = GetActors();
                
                int index = actors.FindIndex(actor => actor.Id == actorP.Id);
                if (index != -1)
                {
                    actors[index] = actorP;
                    UpdateActorsInFile(actors);
                }
                else 
                { 
                    throw new Exception("Ese actor no existe"); 
                }
            }
            catch
            {
                throw;
            }

        }
    }
}
