using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services
{
	public class ValidatePlacementOfShip : IValidatePlacementOfShip
	{
		private bool IsCoordinatesWithInBoardCoordinates(Coordinate coordinate, IBoard board)
		{
			if (coordinate.Alignment == Enums.Alignment.Horizantal && (coordinate.StartRow > board.NoOfRows || coordinate.StartColumn > board.NoOfColumns || coordinate.EndRow > board.NoOfRows || coordinate.EndColumn > board.NoOfColumns))
				throw new IndexOutOfRangeException(BattleshipConstants.CoordinatesOutOfIndex);
			if (coordinate.Alignment == Enums.Alignment.Vertical && (coordinate.StartRow > board.NoOfRows || coordinate.StartColumn > board.NoOfRows || coordinate.EndRow > board.NoOfRows || coordinate.EndColumn > board.NoOfColumns))
				throw new IndexOutOfRangeException(BattleshipConstants.CoordinatesOutOfIndex);
			return true;

		}

		private bool IsCoordinateValid(Coordinate coordinate)
		{
			if (coordinate.StartRow <= 0 || coordinate.StartColumn <= 0)
				throw new ArgumentException(BattleshipConstants.CoordinatesAreInvalid);
			return true;
		}

		private bool IsValidLength(Coordinate coordinate, IBoard board)
		{
			if (coordinate.Length <= 0 || board.NoOfRows < coordinate.EndRow || board.NoOfColumns < coordinate.EndColumn)
				throw new ArgumentException(BattleshipConstants.InvalidShipLength);
			return true;
		}

		private bool IsShipOverLaping(List<Square> squares)
		{
			if (squares.Any(square => square.Status == Enums.SquareStatus.occupied))
				throw new InvalidOperationException(BattleshipConstants.ShipOverLaping);
			return true;
		}

		public bool Validate(Coordinate coordinate, IBoard board, List<Square> squares)
		{
			if (IsCoordinateValid(coordinate) && IsValidLength(coordinate, board) && IsCoordinatesWithInBoardCoordinates(coordinate, board) && IsShipOverLaping(squares))
				return true;
			return false;
		}
	}
}
