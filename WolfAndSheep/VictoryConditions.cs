using System;
using System.Collections.Generic;

namespace WolfAndSheep
{
    public class VictoryConditions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="board"></param>
        /// <param name="wolf"></param>
        public void SheepVictory(Board board, Wolf wolf)
        {
            List<(int, int)> neighbours = new List<(int, int)>();

            for (int x = 0; x < board.XDim; x++)
            {
                for (int y = 0; y < board.YDim; y++)
                {
                    float distX = Math.Abs(Math.Abs(x) -
                        Math.Abs(wolf.XWolfPos));
                    float distY = Math.Abs(Math.Abs(y) -
                        Math.Abs(wolf.YWolfPos));

                    if ((distX == 1 && distY == 1))
                    {
                        neighbours.Add((x, y));
                    }
                }
            }
            int blockedCells = 0;

            for (int k = 0; k < neighbours.Count; k++)
            {
                if (board[neighbours[k].Item1, neighbours[k].Item2] == 'S')
                {
                    blockedCells++;
                }
            }
            if (blockedCells == neighbours.Count)
            {
                Console.WriteLine("The Sheep have cornered the Wolf!\n"
                + "SHEEP WIN!!!");
                Console.WriteLine("\nPress any key to exit");
                Console.Read();
                Environment.Exit(0);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="wolf"></param>
        public void WolfVictory(Wolf wolf, (int, int)[] winCorridors)
        {
            for (int i = 0; i < winCorridors.Length; i++)
            {
                if (winCorridors[i].Item1 == wolf.XWolfPos
                    && winCorridors[i].Item2 == wolf.YWolfPos)
                {
                    Console.WriteLine("The Wolf has reached the Sheep's farm!\n"
                    + "WOLF WINS!!!");
                    Console.WriteLine("\nPress any key to exit");
                    Console.Read();
                    Environment.Exit(0);
                }
            }
        }
    }
}