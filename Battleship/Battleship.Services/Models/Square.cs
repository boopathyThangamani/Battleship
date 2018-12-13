using Battleship.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Models
{
    public class Square
    {

        public int Row { get; set; }
        public int Column { get; set; }
        public Ship Ship { get; set; }
        public SquareStatus Status {get;set;}
        public Square(int row, int column)
        {
            Row = row;
            Column = column;
            Status = SquareStatus.empty;
        }

    }
}
