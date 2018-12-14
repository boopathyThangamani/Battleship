using Battleship.Services.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Models
{
	public class Coordinate
	{
		public int StartRow { get; set; }

		public int StartColumn { get; set; }

		public int Length { get; set; }

		public Alignment Alignment { get; set; }

		//This  property required to place ship
		public int EndColumn
		{
			get
			{
				if (Alignment == Alignment.Horizantal)
					return StartColumn + (Length -1);
				return StartColumn;
			}
		}

		//This  property required to place ship
		public int EndRow
		{
			get
			{
				if (Alignment == Alignment.Vertical)
					return StartRow + (Length -1);
				return StartRow;
			}
		}


		public Coordinate(int start, int end, int length, Alignment alignment)
		{
			// in case start is 3 and end is 1 (place ship from 1 to 3) by swapping the values;
			if (start > end)
			{
				StartRow = end;
				StartColumn = start;
			}
			else
			{
				StartRow = start;
				StartColumn = end;
			}

			Length = length;
			Alignment = alignment;
		}
	}
}
