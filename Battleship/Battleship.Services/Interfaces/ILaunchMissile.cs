using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Interfaces
{
    public interface ILaunchMissile
    {
        string Attack(int row, int column, IBoard board);
    }
}
