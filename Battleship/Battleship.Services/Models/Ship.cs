using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Models
{
    public class Ship
    {
        public string Name { get; set; }

        public Coordinate Coordinate { get; set; }

        // similar to navigational properties in EF
        public IEnumerable<Square> Squares { get; set; }

        public Ship(string name, Coordinate coordinate)
        {
            Squares = new List<Square>();
            Name = name;
            Coordinate = coordinate;
        }
    }
}
