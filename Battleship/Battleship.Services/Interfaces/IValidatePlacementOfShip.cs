using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Interfaces
{
    public interface IValidatePlacementOfShip
    {
        bool Validate(Coordinate coordinate, IBoard board, List<Square> squares);
    }
}
