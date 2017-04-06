using System.Collections.Generic;
using System.ServiceModel;
using Superheroes.DataModel;

namespace Superheroes.Service
{
    [ServiceContract]
    public interface ISuperheroService
    {
        [OperationContract]
        List<Superhero> GetAll();

        [OperationContract]
        Superhero Get(string name);

        [OperationContract]
        void Add(Superhero superhero);

        [OperationContract]
        void Update(string name, Superhero superhero);

        [OperationContract]
        void Delete(string name);

        [OperationContract]
        void UpdateAll(List<Superhero> superhero);
    }
}
