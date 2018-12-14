using Battleship.Services;
using Battleship.Services.Enums;
using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Tests.TestData
{
    public static class TestData
    {
        public static IBoard GetBoard(int noOfRows, int noOfColumns)
        => new Board(noOfRows, noOfColumns);

        public static Coordinate GetCoordinate()
        {
            int startR = 2, startC = 1, length = 2;
            var alignemnt = Alignment.Horizantal;
            return  new Coordinate(startR, startC, length, alignemnt);

        }
    }
}
