using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Interfaces
{
    public interface IPlayerBoard
    {
        void CreateBoard(int noOfRows, int noOfColumns);
        void AddBattleShip(Coordinate coordinate, string battleshipName);
        string Attack(int row, int column);
        bool GameStatus();
    }
}
