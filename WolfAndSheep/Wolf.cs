using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Setup Wolf to be placed on the board and manages their movement
    /// </summary>
    public class Wolf
    {
        /// <summary>
        /// Gets and Sets the value of the Wolf's X position
        /// </summary>
        /// <value> Value of Wolf's X position </value>
        public int XWolfPos { get; set; }

        /// <summary>
        /// Gets and Sets the value of the Wolf's Y position
        /// </summary>
        /// <value> Value of Wolf's Y position </value>
        public int YWolfPos { get; set; }

        /// <summary>
        /// Constructor for creating a new Wolf
        /// </summary>
        /// <param name="row"> Wolf's X position </param>
        /// <param name="column"> Wolf's Y position </param>
        public Wolf(int row = 0, int column = 0)
        {
            // Wolf's X position
            XWolfPos = row;

            // Wolf's Y position
            YWolfPos = column;
        }

        /// <summary>
        /// Method that displays a 'W' on the Wolf's position on the board
        /// </summary>
        /// <param name="board"> Current state of the board </param>
        public void WolfOnBoard(Board board)
        {
            // Displays 'W' on the Wolf's position on the board
            board[XWolfPos, YWolfPos] = 'W';
        }

        /// <summary>
        /// Method that manages the Wolf's movement 
        /// </summary>
        /// <param name="board"> Current state of the board </param>
        public void WolfMovement(Board board)
        {
            // Displays the Wolf's movement options
            Console.WriteLine("Which direction do you wish to move the Wolf?\n"
            + "1 - TopLeft   \t2 - TopRight\n"
            + "3 - BottomLeft\t4 - BottomRight");

            // Stores user movement choice
            int moveChoice;

            // Asks for user input until a valid one is given
            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                moveChoice < 1 || moveChoice > 4);

            // Replaces 'W' in the previous position with an empty space
            board[XWolfPos, YWolfPos] = ' ';

            // Checks player movement choice and its viability on board layout
            // Moves Wolf if choice is viable or asks user for another choice
            if (moveChoice == 1)
            {
                // Checks if the Wolf can move in the specified direction
                if (XWolfPos > 0 && YWolfPos > 0
                    && board[XWolfPos - 1, YWolfPos - 1] != 'S')
                {
                    // Reduces Wolf's X position by 1
                    XWolfPos -= 1;

                    // Reduces Wolf's Y position by 1
                    YWolfPos -= 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // Prompts user to choose movement option again
                    WolfMovement(board);
                }
            }
            // Checks player movement choice and its viability on board layout
            // Moves Sheep if choice is viable or asks user for another choice
            else if (moveChoice == 2)
            {
                // Checks if the Wolf can move in the specified direction
                if (XWolfPos > 0 && YWolfPos < 7
                    && board[XWolfPos - 1, YWolfPos + 1] != 'S')
                {
                    // Reduces Wolf's X position by 1
                    XWolfPos -= 1;

                    // Increases Wolf's Y position by 1
                    YWolfPos += 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // Prompts user to choose movement option again
                    WolfMovement(board);
                }
            }
            // Checks player movement choice and its viability on board layout
            // Moves Sheep if choice is viable or asks user for another choice
            else if (moveChoice == 3)
            {
                // Checks if the Wolf can move in the specified direction
                if (XWolfPos < 7 && YWolfPos > 0
                    && board[XWolfPos + 1, YWolfPos - 1] != 'S')
                {
                    // Increases Wolf's X position by 1
                    XWolfPos += 1;

                    // Reduces Wolf's Y position by 1
                    YWolfPos -= 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // Prompts user to choose movement option again
                    WolfMovement(board);
                }
            }
            // Checks player movement choice and its viability on board layout
            // Moves Sheep if choice is viable or asks user for another choice
            else if (moveChoice == 4)
            {
                // Checks if the Wolf can move in the specified direction
                if (XWolfPos < 7 && YWolfPos < 7
                    && board[XWolfPos + 1, YWolfPos + 1] != 'S')
                {
                    // Increases Wolf's X position by 1
                    XWolfPos += 1;

                    // Increases Wolf's Y position by 1
                    YWolfPos += 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("You can't move the Wolf there.\n");

                    // Prompts user to choose movement option again
                    WolfMovement(board);
                }
            }
            // Replaces the empty space in the new position with an 'W'
            board[XWolfPos, YWolfPos] = 'W';
        }
    }
}