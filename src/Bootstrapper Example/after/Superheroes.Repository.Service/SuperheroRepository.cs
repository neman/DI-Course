using System.Collections.Generic;
using System.Linq;
using Superheroes.DataModel;
using Superheroes.Repository.WCF;
using Superheroes.Repository.Interface;

namespace Repository.Service
{
    public class SuperheroRepository : ISuperheroRepository
    {
        SuperheroServiceClient _serviceProxy = new SuperheroServiceClient();

        public IEnumerable<Superhero> GetAll()
        {
            return _serviceProxy.GetAll();
        }

        public Superhero Get(string name)
        {
            return _serviceProxy.Get(name);
        }

        public void Add(Superhero superhero)
        {
            _serviceProxy.Add(superhero);
        }

        public void Update(string name, Superhero superhero)
        {
            _serviceProxy.Update(name, superhero);
        }

        public void Delete(string name)
        {
            _serviceProxy.Delete(name);
        }

        public void UpdateAll(IEnumerable<Superhero> updatedSuperhero)
        {
            _serviceProxy.UpdateAll(updatedSuperhero.ToList());
        }
    }
}
