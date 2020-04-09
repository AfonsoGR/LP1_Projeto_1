using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheep
{
    public class Board
    {
        public Position[,] BoardValues { get; }

        public Board(int sizeX, int sizeY)
        {
            BoardValues = new Position[sizeX, sizeY];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    BoardValues[x, y] = new Position(x, y, '_');
                }
            }
        }
    }
}
