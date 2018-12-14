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
    public class BattleShipTests
    {

        [Fact]
        public void AddBattleship_PlaceShipsIfValid_ReturnsShipPlaced()
        {
            var board = TestData.TestData.GetBoard(10, 10);
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            var battleship = new BattleShip(new ValidatePlacementOfShip());
            var ship = battleship.AddBattleship(coordinate, board, battleshipName);
            ship.Name.Should().Be(battleshipName);
            ship.Squares.Count().Should().Be(2);
            ship.Squares.Any(s => s.Column == 1 && s.Row == 2).Should().BeTrue();
            ship.Squares.Any(s => s.Column == 2 && s.Row == 2).Should().BeTrue();
            ship.Squares.All(s => s.Status == Services.Enums.SquareStatus.occupied).Should().BeTrue();
        }
    }
}
