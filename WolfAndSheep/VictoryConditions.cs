using System;
using System.Collections.Generic;

namespace WolfAndSheep
{
    /// <summary>
    /// Manages Victory Conditions for the game
    /// </summary>
    public class VictoryConditions
    {
        /// <summary>
        /// Method that manages the Sheep's victory conditions
        /// </summary>
        /// <param name="board"> Current state of the board </param>
        /// <param name="wolf"> Current state of the Wolf </param>
        public void SheepVictory(Board board, Wolf wolf)
        {
            // 
            List<(int, int)> neighbours = new List<(int, int)>();

            // X
            for (int x = 0; x < board.XDim; x++)
            {
                //X
                for (int y = 0; y < board.YDim; y++)
                {
                    // X
                    float distX = Math.Abs(Math.Abs(x) -
                        Math.Abs(wolf.XWolfPos));

                    // X
                    float distY = Math.Abs(Math.Abs(y) -
                        Math.Abs(wolf.YWolfPos));

                    // X
                    if ((distX == 1 && distY == 1))
                    {
                        // X
                        neighbours.Add((x, y));
                    }
                }
            }
            // X
            int blockedCells = 0;

            // X
            for (int k = 0; k < neighbours.Count; k++)
            {
                // X
                if (board[neighbours[k].Item1, neighbours[k].Item2] == 'S')
                {
                    // X
                    blockedCells++;
                }
            }
            // Checks specified conditions to see if the Sheep have won
            if (blockedCells == neighbours.Count)
            {
                // Displays Sheep's victory messages
                Console.WriteLine("The Sheep have cornered the Wolf!\n"
                + "SHEEP WIN!!!");
                Console.WriteLine("\nPress any key to exit");

                // Waits for player input
                Console.Read();

                // Closes the console
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Method that manages the Wolf's victory conditions
        /// </summary>
        /// <param name="wolf"> Current state of the Wolf </param>
        public void WolfVictory(Wolf wolf, (int, int)[] winCorridors)
        {
            // X
            for (int i = 0; i < winCorridors.Length; i++)
            {
                // Checks specified conditions to see if Wolf has won
                if (winCorridors[i].Item1 == wolf.XWolfPos
                    && winCorridors[i].Item2 == wolf.YWolfPos)
                {
                    // Displays Wolf's victory messages
                    Console.WriteLine("The Wolf has reached the Sheep's farm!\n"
                    + "WOLF WINS!!!");
                    Console.WriteLine("\nPress any key to exit");

                    // Waits for player input
                    Console.Read();

                    // Closes the console
                    Environment.Exit(0);
                }
            }
        }
    }
}