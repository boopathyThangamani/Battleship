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
            set => noOfRows = value; // TODO:validation negative no
        }
        public int NoOfColumns
        {
            get => (noOfColumns == 0) ? defaultSize : noOfColumns;
            set => noOfColumns = value; // TODO:Validation negative no
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
            NoOfColumns = NoOfColumns;
            Initilize();
        }

        public List<Square> FindSquares(Coordinate coordinate)
        {

            if (coordinate.Alignment == Enums.Alignment.Horizantal)
                return Squares.Where(square => square.Row == coordinate.Start && square.Column >= coordinate.Start && square.Column <= coordinate.End).ToList();
            else
                return Squares.Where(square => square.Row >= coordinate.Start && square.Column == coordinate.Start && square.Row <= coordinate.End).ToList();
        }

        public Square FindSquare(int row, int column)
            => Squares.FirstOrDefault(square => square.Row == row && square.Column == column);
    }
}
