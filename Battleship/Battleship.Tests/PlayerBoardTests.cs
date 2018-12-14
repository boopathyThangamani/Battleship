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
    //No need to test other methods in playerboard as its unit tested individually. 
    //This class is just an orchestrator
    public class PlayerBoardTests
    {
        [Fact]
        public void GameStatus_AssertSunk_SquareSetToHit()
        {
            var coordinate = TestData.TestData.GetCoordinate();
            string battleshipName = "test";
            var playerBoard = new PlayerBoard();
            playerBoard.CreateBoard(10, 10);
            playerBoard.AddBattleShip(coordinate, battleshipName);
            var hitResult = playerBoard.Attack(2, 1);
            hitResult.Should().Be(SquareStatus.hit.ToString());
            var miss = playerBoard.Attack(2, 3);
            hitResult.Should().Be(SquareStatus.miss.ToString());
            playerBoard.GameStatus().Should().BeFalse();
            playerBoard.Attack(2, 2);
            playerBoard.GameStatus().Should().BeTrue();
        }
    }
}
