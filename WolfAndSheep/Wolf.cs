using System;

namespace WolfAndSheep
{
    /// <summary>
    ///
    /// </summary>
    public class Wolf
    {
        /// <summary>
        /// Gets and Sets the value of the Wolf's X position
        /// </summary>
        /// <value></value>
        public int XWolfPos { get; set; }

        /// <summary>
        /// Gets and Sets the value of the Wolf's Y position
        /// </summary>
        /// <value></value>
        public int YWolfPos { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Wolf(int row = 0, int column = 0)
        {
            // X
            XWolfPos = row;

            // X
            YWolfPos = column;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="board"></param>
        public void WolfOnBoard(Board board)
        {
            board.BoardValues[XWolfPos, YWolfPos] = 'W';
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="board"></param>
        public void WolfMovement(Board board)
        {
            // X
            Console.WriteLine("Which direction do you wish to move the Wolf?\n"
            + "1 - TopLeft   \t2 - TopRight\n"
            + "3 - BottomLeft\t4 - BottomRight");

            // X
            int moveChoice;
            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                moveChoice < 1 || moveChoice > 4)
            {
                ;
            }

            // X
            board.BoardValues[XWolfPos, YWolfPos] = ' ';

            // X
            if (moveChoice == 1)
            {
                // X
                if (XWolfPos > 0 && YWolfPos > 0
                    && board.BoardValues[XWolfPos - 1, YWolfPos - 1] != 'S')
                {
                    // X
                    XWolfPos -= 1;

                    // X
                    YWolfPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // X
                    WolfMovement(board);
                }
            }
            // X
            else if (moveChoice == 2)
            {
                // X
                if (XWolfPos > 0 && YWolfPos < 7
                    && board.BoardValues[XWolfPos - 1, YWolfPos + 1] != 'S')
                {
                    // X
                    XWolfPos -= 1;

                    // X
                    YWolfPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // X
                    WolfMovement(board);
                }
            }
            // X
            else if (moveChoice == 3)
            {
                // X
                if (XWolfPos < 7 && YWolfPos > 0
                    && board.BoardValues[XWolfPos + 1, YWolfPos - 1] != 'S')
                {
                    // X
                    XWolfPos += 1;

                    // X
                    YWolfPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // X
                    WolfMovement(board);
                }
            }
            // X
            else if (moveChoice == 4)
            {
                // X
                if (XWolfPos < 7 && YWolfPos < 7
                    && board.BoardValues[XWolfPos + 1, YWolfPos + 1] != 'S')
                {
                    // X
                    XWolfPos += 1;
                    // X
                    YWolfPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // X
                    WolfMovement(board);
                }
            }
            // X
            board.BoardValues[XWolfPos, YWolfPos] = 'W';
        }
    }
}