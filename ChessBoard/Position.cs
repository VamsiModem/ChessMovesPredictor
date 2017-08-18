using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.Core
{
    public enum NumberProperties
    {
        Max = 8,
        Min = 1
    }
    public enum Alphabets
    {
        a = 1,
        b = 2,
        c = 3,
        d = 4,
        e = 5,
        f = 6,
        g = 7,
        h = 8
    }

    public class Position
    {
        public int X { get; set; }
        public Alphabets Y { get; set; }

        public Position(int x, Alphabets y)
        {
            this.X = x;
            this.Y = y;
        }

        public string GetPositionAsString()
        {
            return this.Y.ToString() + this.X.ToString();
        }
    }
}
