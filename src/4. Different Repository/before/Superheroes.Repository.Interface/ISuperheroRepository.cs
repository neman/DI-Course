using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superheroes.DataModel;

namespace Superheroes.Repository.Interface
{
    public interface ISuperheroRepository
    {
        IEnumerable<Superhero> GetAll();
        Superhero Get(string name);
        void Add(Superhero superhero);
        void Update(string name, Superhero superhero);
        void Delete(string name);
        void UpdateAll(IEnumerable<Superhero> updatedSuperhero);
    }
}
