using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Models
{
    /// <summary>
    /// This class represents a position in a two-dimensional space with integer values for the X and Y coordinates.
    /// </summary>
    public class Position
    {
       public int X { get; set; }
       public int Y { get; set; }

       public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Determines if two positions are adjacent to each other, within one cell of distance.
        /// </summary>
        /// <param name="firstPosition">The first position to compare.</param>
        /// <param name="secondPosition">The second position to compare.</param>
        /// <returns>True if the two positions are adjacent to each other, false otherwise.</returns>
        public static bool IsObjectWithInOneCell(Position firstPosition, Position secondPosition)
        {
            int x = Math.Abs(firstPosition.X - secondPosition.X);
            int y = Math.Abs(firstPosition.Y- secondPosition.Y);
            return (x <= 1 && y <= 1 && x + y <= 1);
        }

        /// <summary>
        /// Determines if two positions are within a given number of cells of distance.
        /// </summary>
        /// <param name="firstPosition">The first position to compare.</param>
        /// <param name="secondPosition">The second position to compare.</param>
        /// <param name="cells">The maximum distance allowed between the two positions.</param>
        /// <returns>True if the two positions are within the specified number of cells of each other, false otherwise.</returns>
        public static bool IsObjectWithInGivenNumberOfCells(Position firstPosition, Position secondPosition, int cells)
        {
            int x = Math.Abs(firstPosition.X - secondPosition.X);
            int y = Math.Abs(firstPosition.Y - secondPosition.Y);
            return (x<=cells && y<=cells && x+y <=cells);
        }
    }
}
