using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Services
{
    public class PlayerBoard : IPlayerBoard
    {
        private IBoard Board { get; set; }
        public List<Ship> BattleShips { get; set; }
        public PlayerBoard()
        {
            BattleShips = new List<Ship>();
        }
        public void AddBattleShip(Coordinate coordinate, string battleshipName)
        {
            //Should inject
            IValidatePlacementOfShip validatePlacementOfShip = new ValidatePlacementOfShip();
            IBattleship battleship = new BattleShip(validatePlacementOfShip);
            var ship = battleship.AddBattleship(coordinate, Board, battleshipName);
            if (ship != null)
                BattleShips.Add(ship);
        }

        public string Attack(int row, int column)
        {
            ILaunchMissile launchMissile = new LaunchMissile();
            return launchMissile.Attack(row, column, Board);
        }

        public void CreateBoard(int noOfRows, int noOfColumns)
            => Board = new Board(noOfRows, noOfColumns);

        public bool GameStatus()
          => BattleShips.All(ship => ship.Squares.All(sq => sq.Status == Enums.SquareStatus.hit));

    }
}
