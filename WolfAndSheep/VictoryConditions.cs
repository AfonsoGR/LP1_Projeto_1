using System;
using System.Collections.Generic;
using System.Collections;

namespace WolfAndSheep
{
    public class VictoryConditions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="wolf"></param>
        /// <param name="sheep"></param>
        public void SheepVictory(Board board, Wolf wolf)
        {
            List<(int, int)> neighbours = new List<(int, int)>();

            for (int x = 0; x < board.BoardValues.GetLength(0); x++)
            {
                for (int y = 0; y < board.BoardValues.GetLength(1); y++)
                {
                    float distX = Math.Abs(Math.Abs(x) -
                        Math.Abs(wolf.xWolfPos));
                    float distY = Math.Abs(Math.Abs(y) -
                        Math.Abs(wolf.yWolfPos));

                    if ((distX == 1 && distY == 1))
                    {
                        neighbours.Add((x, y));
                    }
                }
            }
            int blockedCells = 0;

            for (int k = 0; k < neighbours.Count; k++)
            {
                if (board.BoardValues[neighbours[k].Item1, neighbours[k].Item2] == 'S')
                {
                    blockedCells++;
                }
            }
            if (blockedCells == neighbours.Count)
            {
                Console.WriteLine("The Sheep have cornered the Wolf!\n"
                + "SHEEP WIN!!!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="wolf"></param>
        /// <param name="sheep"></param>
        public void WolfVictory(Board board, Wolf wolf, Sheep sheep,
            (int, int)[] winCorridors)
        {
            for (int i = 0; i < winCorridors.Length; i++)
            {
                if (winCorridors[i].Item1 == wolf.xWolfPos
                    && winCorridors[i].Item2 == wolf.yWolfPos)
                {
                    Console.WriteLine("The Wolf has reached the Sheep's farm!\n"
                    + "WOLF WINS!!!");
                }
            }
        }
    }
}