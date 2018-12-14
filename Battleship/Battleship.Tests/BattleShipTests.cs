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
    public class BattleShipTests
    {
        private readonly IFixture _fixture;
        private readonly IValidatePlacementOfShip _validatePlacementOfShip;

        public BattleShipTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _validatePlacementOfShip = _fixture.Freeze<ValidatePlacementOfShip>();
        }

        [Fact]
        public void AddBattleship_PlaceShipsIfValid_ReturnsShipPlaced()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            _validatePlacementOfShip.Validate(Arg.Any<Coordinate>(), Arg.Any<IBoard>(), Arg.Any<List<Square>>()).ReturnsForAnyArgs(true);
            var battleship = new BattleShip(_validatePlacementOfShip);
            var ship = battleship.AddBattleship(coordinate, board, battleshipName);
            ship.Name.Should().Be(battleshipName);
            ship.Squares.Count().Should().Be(2);
            ship.Squares.Any(s => s.Column == 1 && s.Row == 2).Should().BeTrue();
            ship.Squares.Any(s => s.Column == 2 && s.Row == 2).Should().BeTrue();
            ship.Squares.All(s => s.Status == Services.Enums.SquareStatus.occupied).Should().BeTrue();
        }

        [Fact]
        public void AddBattleship_PlaceShipsIfInValid_ReturnsNull()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            _validatePlacementOfShip.Validate(Arg.Any<Coordinate>(), Arg.Any<IBoard>(), Arg.Any<List<Square>>()).ReturnsForAnyArgs(false);
            var battleship = new BattleShip(_validatePlacementOfShip);
            var ship = battleship.AddBattleship(coordinate, board, battleshipName);
            ship.Should().BeNull();
        }

    }
}
