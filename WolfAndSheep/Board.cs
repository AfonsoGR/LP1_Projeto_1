using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheep
{
    public class Board
    {
        public char[,] BoardValues { get; }

        public Board(int sizeX, int sizeY)
        {
            BoardValues = new char[sizeX, sizeY];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    BoardValues[x, y] = ' ';
                }
            }
        }
    }
}
