using Superheroes.DataModel;
using Superheroes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace SuperheroesRepository.CSV
{
    public class CSVRepository : ISuperheroRepository
    {
        string path;

        public CSVRepository()
        {
            var filename = ConfigurationManager.AppSettings["CSVFileName"];
            path = AppDomain.CurrentDomain.BaseDirectory + filename;
        }

        public IEnumerable<Superhero> GetAll()
        {
            var superhero = new List<Superhero>();

            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var elems = line.Split(',');
                        var per = new Superhero()
                        {
                            Name = elems[0],
                            Publisher = elems[1],
                            FirstPublished = DateTime.Parse(elems[2]),
                            Rating = Int32.Parse(elems[3])
                        };
                        superhero.Add(per);
                    }
                }
            }
            return superhero;
        }

        public Superhero Get(string name)
        {
            Superhero superhero = new Superhero();
            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var elems = line.Split(',');
                    if (elems[1].ToLower() == name.ToLower())
                    {
                        superhero.Name = elems[0];
                        superhero.Publisher = elems[1];
                        superhero.FirstPublished = DateTime.Parse(elems[2]);
                        superhero.Rating = int.Parse(elems[3]);
                    }
                }
            }

            return superhero;
        }

        public void Add(Superhero superhero)
        {
            throw new NotImplementedException();
        }

        public void Update(string name, Superhero superhero)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll(IEnumerable<Superhero> superhero)
        {
            throw new NotImplementedException();
        }
    }
}
