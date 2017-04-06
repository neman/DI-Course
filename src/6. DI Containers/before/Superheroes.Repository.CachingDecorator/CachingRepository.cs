using Superheroes.DataModel;
using Superheroes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Superheroes.Repository.CachingDecorator
{
    public class CachingRepository : ISuperheroRepository
    {
        private TimeSpan _cacheDuration = TimeSpan.FromSeconds(30);
        private DateTime _dataDateTime;
        private ISuperheroRepository _superheroRepository;
        private IEnumerable<Superhero> _cachedItems;

        private bool IsCacheValid
        {
            get
            {
                var _cacheAge = DateTimeOffset.Now - _dataDateTime;
                return _cacheAge < _cacheDuration;
            }
        }

        private void ValidateCache()
        {
            if (_cachedItems == null || !IsCacheValid)
            {
                try
                {
                    _cachedItems = _superheroRepository.GetAll();
                    _dataDateTime = DateTime.Now;
                }
                catch
                {
                    _cachedItems = new List<Superhero>()
                    {
                        new Superhero(){ Name="No Data Available", Publisher = "", Rating = -1},
                    };
                }
            }
        }

        private void InvalidateCache()
        {
            _cachedItems = null;
        }

        public CachingRepository(ISuperheroRepository superheroRepository)
        {
            _superheroRepository = superheroRepository;
        }

        public IEnumerable<Superhero> GetAll()
        {
            ValidateCache();
            return _cachedItems;
        }

        public Superhero Get(string name)
        {
            ValidateCache();
            return _cachedItems.FirstOrDefault(p => p.Name== name);
        }

        public void Add(Superhero superhero)
        {
            _superheroRepository.Add(superhero);
            InvalidateCache();
        }

        public void Update(string name, Superhero superhero)
        {
            _superheroRepository.Update(name, superhero);
            InvalidateCache();
        }

        public void Delete(string name)
        {
            _superheroRepository.Delete(name);
            InvalidateCache();
        }

        public void UpdateAll(IEnumerable<Superhero> superheroes)
        {
            _superheroRepository.UpdateAll(superheroes);
            InvalidateCache();
        }
    }
}
