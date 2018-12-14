using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Services
{
	public class Board : IBoard
	{
		private const int defaultSize = 10;

		private int noOfRows, noOfColumns;
		public List<Square> Squares { get; set; }

		public int NoOfRows
		{
			get => (noOfRows == 0) ? defaultSize : noOfRows;
			set => noOfRows = value;
		}
		public int NoOfColumns
		{
			get => (noOfColumns == 0) ? defaultSize : noOfColumns;
			set => noOfColumns = value;
		}

		private void Initilize()
		{
			List<Square> squares = new List<Square>();
			for (var row = 1; row <= NoOfRows; row++)
				for (var column = 1; column <= NoOfColumns; column++)
					squares.Add(new Square(row, column));
			Squares = squares;
		}

		public Board()
		{
			Initilize();
		}

		public Board(int noOfRows, int noOfColumns)
		{
			NoOfRows = noOfRows;
			NoOfColumns = noOfColumns;
			Initilize();
		}

		public List<Square> FindSquares(Coordinate coordinate)
			=> Squares.Where(square => square.Row >= coordinate.StartRow && square.Column >= coordinate.StartColumn && square.Column <= coordinate.EndColumn && square.Row <= coordinate.EndRow).ToList();

		public Square FindSquare(int row, int column)
			=> Squares.FirstOrDefault(square => square.Row == row && square.Column == column);
	}
}
