using System;

namespace WolfAndSheep
{
    public class Sheep
    {
        /// <summary>
        /// Gets and Sets the value of the Sheep's X position
        /// </summary>
        /// <value></value>
        public int XSheepPos { get; set; }

        /// <summary>
        /// Gets and Sets the value of the Sheep's Y position
        /// </summary>
        /// <value></value>
        public int YSheepPos { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Sheep(int row = 0, int column = 0)
        {
            // X
            XSheepPos = row;

            // X
            YSheepPos = column;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="board"></param>
        public void SheepOnBoard(Board board, char visuals = 'S')
        {
            // X
            board.BoardValues[XSheepPos, YSheepPos] = visuals;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="board"></param>
        public void SheepMovement(Board board, int sheepDirection)
        {
            // X
            Console.WriteLine("Which direction do you wish to move the Sheep?\n"
            + "1 - TopLeft      2 - TopRight\n"
            + "3 - BottomLeft   4 - BottomRight\n"
            + "Keep in mind, the Sheep can't move backwards.");

            // X
            int moveChoice;

            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                moveChoice < 1 || moveChoice > 4);

            // X
            board.BoardValues[XSheepPos, YSheepPos] = ' ';

            // X
            if (moveChoice == 1 && (sheepDirection == 2 || sheepDirection == 3))
            {
                // X
                if (XSheepPos > 0 && YSheepPos > 0
                    && board.BoardValues[XSheepPos - 1, YSheepPos - 1] != 'S'
                    && board.BoardValues[XSheepPos - 1, YSheepPos - 1] != 'W')
                {
                    // X
                    XSheepPos -= 1;

                    // X
                    YSheepPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // X
                    SheepMovement(board, sheepDirection);
                }
            }
            // X
            else if (moveChoice == 2 && (sheepDirection == 3 || sheepDirection == 4))
            {
                // X
                if (XSheepPos > 0 && YSheepPos < 7
                    && board.BoardValues[XSheepPos - 1, YSheepPos + 1] != 'S'
                    && board.BoardValues[XSheepPos - 1, YSheepPos + 1] != 'W')
                {
                    // X
                    XSheepPos -= 1;

                    // X
                    YSheepPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // X
                    SheepMovement(board, sheepDirection);
                }
            }
            // X
            else if (moveChoice == 3 && (sheepDirection == 1 || sheepDirection == 2))
            {
                // X
                if (XSheepPos < 7 && YSheepPos > 0
                    && board.BoardValues[XSheepPos + 1, YSheepPos - 1] != 'S'
                    && board.BoardValues[XSheepPos + 1, YSheepPos - 1] != 'W')
                {
                    // X
                    XSheepPos += 1;

                    // X
                    YSheepPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // X
                    SheepMovement(board, sheepDirection);
                }
            }
            // X
            else if (moveChoice == 4 && (sheepDirection == 1 || sheepDirection == 4))
            {
                // X
                if (XSheepPos < 7 && YSheepPos < 7
                    && board.BoardValues[XSheepPos + 1, YSheepPos + 1] != 'S'
                    && board.BoardValues[XSheepPos + 1, YSheepPos + 1] != 'W')
                {
                    // X
                    XSheepPos += 1;
                    // X
                    YSheepPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // X
                    SheepMovement(board, sheepDirection);
                }
            }
            // X
            else
            {
                // X
                Console.WriteLine("Your Sheep can't move backwards.\n");

                // X
                SheepMovement(board, sheepDirection);
            }
            // X
            board.BoardValues[XSheepPos, YSheepPos] = 'S';
        }
    }
}