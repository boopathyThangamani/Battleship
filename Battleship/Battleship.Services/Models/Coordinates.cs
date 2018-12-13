using Battleship.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Models
{
    public class Coordinate
    {
        // Start co-ordinate is row 
        public int Start { get; set; }

        // End cordinate is Column if position is Horizantol and Row if position is Vertical
        public int End { get; set; }

        public Alignment Alignment { get; set; }

        public Coordinate(int start, int end, Alignment alignment)
        {
            // in case start is 3 and end is 1 (place ship from 1 to 3) by swapping the values;
            if (start > end)
            {
                Start = end;
                End = start;
            }
            else
            {
                Start = start;
                End = end;
            }
            Alignment = alignment;
        }
    }
}
