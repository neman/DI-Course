using System;

namespace Superheroes.DataModel
{
    public class Superhero
    {
        public string Name { get; set; }
        public string Publisher { get; set; }        
        public int Rating { get; set; }
        public DateTime FirstPublished { get; set; }
    }
}
