using System;
using System.Collections.Generic;
using System.Linq;
using Superheroes.DataModel;

namespace Superheroes.Service
{
    public class SuperheroService : ISuperheroService
    {

        private List<Superhero> _superheroes = new List<Superhero>()
            {
                new Superhero() { Name = "Batman", Publisher = "DC", FirstPublished = new DateTime(1939, 3, 1), Rating = 10 },
                new Superhero() { Name = "Superman", Publisher = "DC", FirstPublished = new DateTime(1938, 6, 1), Rating = 9 },
                new Superhero() { Name = "Spiderman", Publisher = "Marvel", FirstPublished = new DateTime(1962, 8, 1), Rating = 7 },
                new Superhero() { Name = "Wolverine", Publisher = "Marvel", FirstPublished = new DateTime(1974, 10, 1), Rating = 8 },
                new Superhero() { Name = "Wonder Woman", Publisher = "DC", FirstPublished = new DateTime(1941, 12, 1), Rating = 8 },
                new Superhero() { Name = "Deadpool", Publisher = "Marvel", FirstPublished = new DateTime(1991, 2, 1), Rating = 7 },
                new Superhero() { Name = "Emma Frost", Publisher = "DC", FirstPublished = new DateTime(1980, 1, 1), Rating = 8 },
            };

        public List<Superhero> GetAll()
        {
            return _superheroes;
        }

        public Superhero Get(string name)
        {
            return _superheroes.Where(s => s.Name == name).FirstOrDefault();
        }

        public void Add(Superhero superhero)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(string name, Superhero superhero)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll(List<Superhero> superhero)
        {
            throw new NotImplementedException();
        }
    }
}
