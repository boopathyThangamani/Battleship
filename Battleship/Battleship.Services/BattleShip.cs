using Battleship.Services.Interfaces;
using Battleship.Services.Models;

namespace Battleship.Services
{
    public class BattleShip : IBattleship
    {
        private readonly IValidatePlacementOfShip _validatePlacementOfShip;
        public BattleShip(IValidatePlacementOfShip validatePlacementOfShip)
        {
            _validatePlacementOfShip = validatePlacementOfShip;
        }
        public Ship AddBattleship(Coordinate coordinate, IBoard board, string battleshipName)
        {
            
            var squares = board.FindSquares(coordinate);
            if (_validatePlacementOfShip.Validate(coordinate, board, squares))
            {
                Ship ship = new Ship(battleshipName, coordinate);
                ship.Squares = squares;

                squares.ForEach(square => { square.Ship = ship; square.Status = Enums.SquareStatus.occupied; });
                return ship;
            }
            return null;
        }


    }
}
