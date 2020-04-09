using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheep
{
    public struct Position
    {
        public int x;
        public int y;
        public char Visual { get; set; }

        public Position(int x, int y, char visual)
        {
            this.x = x;
            this.y = y;
            this.Visual = visual;
        }
    }
}
