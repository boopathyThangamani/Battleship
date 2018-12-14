using Battleship.Services;
using Battleship.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Battleship.Services;
using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;


namespace Battleship.Tests
{
    public class ValidatePlacementOfShipsTests
    {
        [Fact]
        public void Validate_IsCoordinateValidForRow_ThrowsArgumentException()
        {
            var board = TestData.TestData.GetBoard(10,10);
            var coordinate = new Coordinate(0,2,2,Services.Enums.Alignment.Horizantal);
            var squares = board.FindSquares(coordinate);
            var validatePlacementOfShips = new ValidatePlacementOfShip();
            var result = Assert.Throws<ArgumentException>(() => validatePlacementOfShips.Validate(coordinate , board, squares));
            result.Message.Should().Be(BattleshipConstants.CoordinatesAreInvalid);
        }

        [Fact]
        public void Validate_IsCoordinateValidForColumn_ThrowsArgumentException()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = new Coordinate(1, 0, 2, Services.Enums.Alignment.Horizantal);
            var squares = board.FindSquares(coordinate);
            var validatePlacementOfShips = new ValidatePlacementOfShip();
            var result = Assert.Throws<ArgumentException>(() => validatePlacementOfShips.Validate(coordinate, board, squares));
            result.Message.Should().Be(BattleshipConstants.CoordinatesAreInvalid);
        }

        [Fact]
        public void Validate_IsValidLengthForLengthIsZero_ThrowsArgumentException()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = new Coordinate(10, 10, 0, Services.Enums.Alignment.Horizantal);
            var squares = board.FindSquares(coordinate);
            var validatePlacementOfShips = new ValidatePlacementOfShip();
            var result = Assert.Throws<ArgumentException>(() => validatePlacementOfShips.Validate(coordinate, board, squares));
            result.Message.Should().Be(BattleshipConstants.InvalidShipLength);
        }

        [Fact]
        public void Validate_IsValidLengthForRows_ThrowsArgumentException()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = new Coordinate(10, 10, 2, Services.Enums.Alignment.Vertical);
            var squares = board.FindSquares(coordinate);
            var validatePlacementOfShips = new ValidatePlacementOfShip();
            var result = Assert.Throws<ArgumentException>(() => validatePlacementOfShips.Validate(coordinate, board, squares));
            result.Message.Should().Be(BattleshipConstants.InvalidShipLength);
        }

        [Fact]
        public void Validate_IsValidLengthForColumns_ThrowsArgumentException()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = new Coordinate(10, 10, 2, Services.Enums.Alignment.Horizantal);
            var squares = board.FindSquares(coordinate);
            var validatePlacementOfShips = new ValidatePlacementOfShip();
            var result = Assert.Throws<ArgumentException>(() => validatePlacementOfShips.Validate(coordinate, board, squares));
            result.Message.Should().Be(BattleshipConstants.InvalidShipLength);
        }

        [Fact]
        public void Validate_Overlapping_ThrowsInvalidOperationException()
        {
            var board = TestData.TestData.GetBoard(1, 11);
            var coordinate = new Coordinate(1, 1, 1, Services.Enums.Alignment.Horizantal);
            var squares = board.FindSquares(coordinate);
            squares.ForEach(s => s.Status = Services.Enums.SquareStatus.occupied);
            var validatePlacementOfShips = new ValidatePlacementOfShip();
            var result = Assert.Throws<InvalidOperationException>(() => validatePlacementOfShips.Validate(coordinate, board, squares));
            result.Message.Should().Be(BattleshipConstants.ShipOverLaping);
        }

    }
}
