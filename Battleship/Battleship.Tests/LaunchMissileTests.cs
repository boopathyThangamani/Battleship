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
        [Fact]
        public void Attack_SquareOccupied_SquareSetToHit()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            var battleship = new BattleShip(new ValidatePlacementOfShip());
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
            var battleship = new BattleShip(new ValidatePlacementOfShip());
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
            var battleship = new BattleShip(new ValidatePlacementOfShip());
            var ship = battleship.AddBattleship(coordinate, board, battleshipName);
            var launchMissile = new LaunchMissile();
            launchMissile.Attack(2, 1, board);
            var result = launchMissile.Attack(2, 2, board);
            result.Should().Be("Sunk");
        }

    }
}
