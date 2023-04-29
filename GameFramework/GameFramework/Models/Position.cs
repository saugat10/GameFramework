using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Models
{
    public class Position
    {
        public int X;
        
        public int Y;

        //public Position(int x, int y)
        //{
        //    X = x;
        //    Y = y;
        //}   

        public int DistanceTo(Position other)
        {
            int dx = X-other.X;
            int dy = Y-other.Y;

            return (int)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
