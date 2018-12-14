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


		public Coordinate(int startRow, int startColumn, int length, Alignment alignment)
		{
            StartRow = startRow;
            StartColumn = startColumn;

			Length = length;
			Alignment = alignment;
		}
	}
}
