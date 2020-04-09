using System;

namespace WolfAndSheep
{
    public class Sheep
    {
        /// <summary>
        /// Gets and Sets the value of the Sheep's X position
        /// </summary>
        /// <value></value>
        public int xSheepPos {get; set; }
        
        /// <summary>
        /// Gets and Sets the value of the Sheep's Y position
        /// </summary>
        /// <value></value>
        public int ySheepPos {get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Sheep(int row = 0, int column = 0)
        {
            // X
            xSheepPos = row;

            // X
            ySheepPos = column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public void SheepOnBoard(Board board)
        {
            // X
            board.BoardValues [xSheepPos, ySheepPos] = 'S'; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public void SheepMovement(Board board)
        {
            // X
            Console.WriteLine("Which direction do you wish to move?\n"
            + "1 for TopLeft\t2 for TopRight\n"
            + "3 for BottomLeft\t4 for BottomRight");
            
            // X
            int moveChoice = int.Parse(Console.ReadLine());

            // X
            board.BoardValues [xSheepPos, ySheepPos] = ' ';

            // X
            if (moveChoice == 1)
            {   
                // X                             
                if (xSheepPos > 0 && ySheepPos > 0)
                {
                    // X
                    xSheepPos -= 1;

                    // X
                    ySheepPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");
                    
                    // X
                    SheepMovement(board);
                }
            }
            // X
            else if (moveChoice == 2)
            {
                // X
                if (xSheepPos > 0 && ySheepPos < 7)
                {
                    // X
                    xSheepPos -= 1;

                    // X
                    ySheepPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");

                    // X
                    SheepMovement(board);
                }                
            }
            // X
            else if (moveChoice == 3)
            {
                // X
                if (xSheepPos < 7 && ySheepPos > 0)
                {
                    // X
                    xSheepPos += 1;

                    // X
                    ySheepPos -= 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");

                    // X
                    SheepMovement(board);
                }   
            }
            // X
            else if (moveChoice == 4)
            {
                // X
                if (xSheepPos < 7 && ySheepPos < 7)
                {
                    // X
                    xSheepPos += 1;
                    // X
                    ySheepPos += 1;
                }
                // X
                else
                {
                    // X
                    Console.WriteLine("You can't move there");

                    // X
                    SheepMovement(board);
                }   
            }
            // X
            else
            {
                // X
                Console.WriteLine("Please select a valid option.");

                // X
                SheepMovement(board);
            }
            // X
            board.BoardValues [xSheepPos, ySheepPos] = 'S';
        }
    }
}