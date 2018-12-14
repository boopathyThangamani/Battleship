using Battleship.Services;
using Battleship.Services.Enums;
using Battleship.Services.Models;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Battleship.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Ctor_DefaultCtro_BoardOfSize10X10()
        {
            var board = new Board();
            board.NoOfColumns.Should().Be(10);
            board.NoOfColumns.Should().Be(10);
            board.Squares.Count.Should().Be(100);
            board.Squares.Any(squares => squares.Status != Services.Enums.SquareStatus.empty).Should().BeFalse();
        }

        [Fact]
        public void Ctor_ParametrizedCtro_BoardOfGivenSize()
        {
            int r = 3, c = 3;
            var board = new Board(r, c);
            board.NoOfColumns.Should().Be(r);
            board.NoOfColumns.Should().Be(c);
            board.Squares.Count.Should().Be(r * c);
            board.Squares.Any(squares => squares.Status != Services.Enums.SquareStatus.empty).Should().BeFalse();
        }

        [Fact]
        public void FindSquare_ValidRowAndColumn_ReturnsTheFoundRow()
        {
            int r = 3, c = 3;
            int rToFind = 1, cToFind = 2;
            var board = new Board(r, c);
            var square = board.FindSquare(rToFind, cToFind);
            square.Should().NotBeNull();
            square.Row.Should().Be(rToFind);
            square.Column.Should().Be(cToFind);
        }

        [Fact]
        public void FindSquare_InValidRowAndColumn_ReturnsTheFoundRow()
        {
            int r = 3, c = 3;
            int rToFind = 4, cToFind = 1;
            var board = new Board(r, c);
            var square = board.FindSquare(rToFind, cToFind);
            square.Should().BeNull();
        }

        [Fact]
        public void FindSquares_ValidHorizantalCordinates_ReturnsListOFSquares()
        {
            int r = 3, c = 3;
            int startR = 2, startC = 1, length = 2;
            var alignemnt = Alignment.Horizantal;
            var board = new Board(r, c);
            var coordinate = new Coordinate(startR, startC, length, alignemnt);
            var squares = board.FindSquares(coordinate);
            squares.Count.Should().Be(2);
            squares.Any(s => s.Column == 1 && s.Row == 2).Should().Be(true);
            squares.Any(s => s.Column == 2 && s.Row == 2).Should().Be(true);
        }

        [Fact]
        public void FindSquares_ValidVerticalCordinates_ReturnsListOFSquares()
        {
            int r = 3, c = 3;
            int startR = 2, startC = 1, length = 2;
            var alignemnt = Alignment.Vertical;
            var board = new Board(r, c);
            var coordinate = new Coordinate(startR, startC, length, alignemnt);
            var squares = board.FindSquares(coordinate);
            squares.Count.Should().Be(2);
            squares.Any(s => s.Column == 1 && s.Row == 2).Should().Be(true);
            squares.Any(s => s.Column == 1 && s.Row == 3).Should().Be(true);

        }

        [Fact]
        public void FindSquares_InValidCordinates_NoOfSquaresShouldBeZero()
        {
            int r = 3, c = 3;
            int startR = 4, startC = 1, length = 2;
            var alignemnt = Alignment.Horizantal;
            var board = new Board(r, c);
            var coordinate = new Coordinate(startR, startC, length, alignemnt);
            var squares= board.FindSquares(coordinate);
            squares.Count.Should().Be(0);
        }
    }
}
