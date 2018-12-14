using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Battleship.Services;
using Battleship.Services.Enums;
using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Battleship.Tests
{
    public class LaunchMissileTests
    {
        private readonly IFixture _fixture;
        private readonly IValidatePlacementOfShip _validatePlacementOfShip;

        public LaunchMissileTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _validatePlacementOfShip = _fixture.Freeze<ValidatePlacementOfShip>();
        }

        [Fact]
        public void Attack_SquareOccupied_SquareSetToHit()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            _validatePlacementOfShip.Validate(Arg.Any<Coordinate>(), Arg.Any<IBoard>(), Arg.Any<List<Square>>()).ReturnsForAnyArgs(true);
            var battleship = new BattleShip(_validatePlacementOfShip);
            var ship = battleship.AddBattleship(coordinate, board, battleshipName);
            var launchMissile = new LaunchMissile();
            var result = launchMissile.Attack(2, 1, board);
            result.Should().Be(SquareStatus.hit.ToString());
        }

        [Fact]
        public void Attack_SquareIsEmpty_SquareSetToMiss()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            _validatePlacementOfShip.Validate(Arg.Any<Coordinate>(), Arg.Any<IBoard>(), Arg.Any<List<Square>>()).ReturnsForAnyArgs(true);
            var battleship = new BattleShip(_validatePlacementOfShip);
            var ship = battleship.AddBattleship(coordinate, board, battleshipName);
            var launchMissile = new LaunchMissile();
            var result = launchMissile.Attack(2, 3, board);
            result.Should().Be(SquareStatus.miss.ToString());
        }

        [Fact]
        public void Attack_SquareOccupied_ShipSunk()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            _validatePlacementOfShip.Validate(Arg.Any<Coordinate>(), Arg.Any<IBoard>(), Arg.Any<List<Square>>()).ReturnsForAnyArgs(true);
            var battleship = new BattleShip(_validatePlacementOfShip);
            var ship = battleship.AddBattleship(coordinate, board, battleshipName);
            var launchMissile = new LaunchMissile();
            launchMissile.Attack(2, 1, board);
            var result = launchMissile.Attack(2, 2, board);
            result.Should().Be("Sunk");
        }

    }
}
