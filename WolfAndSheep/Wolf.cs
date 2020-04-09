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
        public int xWolfPos {get; set; }
        
        /// <summary>
        /// Gets and Sets the value of the Wolf's Y position
        /// </summary>
        /// <value></value>
        public int yWolfPos {get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Wolf(int row = 0, int column = 0)
        {
            // X
            xWolfPos = row;

            // X
            yWolfPos = column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public void WolfOnBoard(Board board)
        {
            board.BoardValues [xWolfPos, yWolfPos] = 'W';             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public void WolfMovement(Board board)
        {
            // X
            Console.WriteLine("Which direction do you wish to move?\n"
            + "1 for TopLeft\t2 for TopRight\n"
            + "3 for BottomLeft\t4 for BottomRight");
            
            // X
            int moveChoice = int.Parse(Console.ReadLine());

            // X
            board.BoardValues [xWolfPos, yWolfPos] = ' ';

            // X
            if (moveChoice == 1)
            {   
                // X                             
                if (xWolfPos > 0 && yWolfPos > 0 
                    && board.BoardValues [xWolfPos -1, yWolfPos-1] != 'S')
                {
                    // X
                    xWolfPos -= 1;

                    // X
                    yWolfPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");
                    
                    // X
                    WolfMovement(board);
                }
            }
            // X
            else if (moveChoice == 2)
            {
                // X
                if (xWolfPos > 0 && yWolfPos < 7
                    && board.BoardValues [xWolfPos -1, yWolfPos +1] != 'S')
                {
                    // X
                    xWolfPos -= 1;

                    // X
                    yWolfPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");

                    // X
                    WolfMovement(board);
                }                
            }
            // X
            else if (moveChoice == 3)
            {
                // X
                if (xWolfPos < 7 && yWolfPos > 0
                    && board.BoardValues [xWolfPos +1, yWolfPos -1] != 'S')
                {
                    // X
                    xWolfPos += 1;

                    // X
                    yWolfPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");

                    // X
                    WolfMovement(board);
                }   
            }
            // X
            else if (moveChoice == 4)
            {
                // X
                if (xWolfPos < 7 && yWolfPos < 7
                    && board.BoardValues [xWolfPos +1, yWolfPos +1] != 'S')
                {
                    // X
                    xWolfPos += 1;
                    // X
                    yWolfPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");

                    // X
                    WolfMovement(board);
                }   
            }
            // X
            else
            {
                // X
                Console.WriteLine("Please select a valid option.");

                // X
                WolfMovement(board);
            }
            // X
            board.BoardValues [xWolfPos, yWolfPos] = 'W';
        }
    }
}