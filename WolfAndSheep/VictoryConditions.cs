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
            // Saves Wolf's neighbours on the board
            List<(int, int)> neighbours = new List<(int, int)>();

            // Checks the spaces along the width of the board
            for (int x = 0; x < board.XDim; x++)
            {
                // Checks the spaces along the height of the board
                for (int y = 0; y < board.YDim; y++)
                {
                    // Converts negative values to positive values in the X axis
                    float distX = Math.Abs(Math.Abs(x) -
                        Math.Abs(wolf.XWolfPos));

                    // Converts negative values to positive values in the Y axis
                    float distY = Math.Abs(Math.Abs(y) -
                        Math.Abs(wolf.YWolfPos));

                    // Checks if the diagonal is adjacent to the current Wolf
                    if ((distX == 1 && distY == 1))
                    {
                        // Adds neighbour to List
                        neighbours.Add((x, y));
                    }
                }
            }
            // Int to save blockedCells value
            int blockedCells = 0;

            // Checks if the Wolf's surrounding cells are blocked
            for (int k = 0; k < neighbours.Count; k++)
            {
                // Checks if neighbour cell is a Sheep
                if (board[neighbours[k].Item1, neighbours[k].Item2] == 'S')
                {
                    // Increments blockedCells
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
        /// <param name="wolf"> Current state of the Wolf </param>
        /// <param name="winCorridors"> Wolf victory positions </param>
        public void WolfVictory(Wolf wolf, (int, int)[] winCorridors)
        {
            // Goes through the winCorridors array
            for (int i = 0; i < winCorridors.Length; i++)
            {
                // Checks if the Wolf is at the given winCorridor
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