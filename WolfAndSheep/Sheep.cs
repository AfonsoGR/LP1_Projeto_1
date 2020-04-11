using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Setup Sheep to be placed on the board and manages their movement
    /// </summary>
    public class Sheep
    {
        /// <summary>
        /// Gets and Sets the value of the Sheep's X position
        /// </summary>
        /// <value> Value of X position </value>
        public int XSheepPos { get; set; }

        /// <summary>
        /// Gets and Sets the value of the Sheep's Y position
        /// </summary>
        /// <value> Value of Y position </value>
        public int YSheepPos { get; set; }

        /// <summary>
        /// Constructor for creating a new Sheep
        /// </summary>
        /// <param name="row"> Sheep's X position </param>
        /// <param name="column"> Sheep's Y position </param>
        public Sheep(int row = 0, int column = 0)
        {
            // Sheep's X position
            XSheepPos = row;

            // Sheep's Y position
            YSheepPos = column;
        }

        /// <summary>
        /// Method that displays an 'S' on the Sheep's position on the board
        /// </summary>
        /// <param name="board"> Current state of the board </param>
        public void SheepOnBoard(Board board, char visuals = 'S')
        {
            // Displays 'S' on Sheep's position
            board[XSheepPos, YSheepPos] = visuals;
        }

        /// <summary>
        /// Method that manages the Sheep's movement
        /// </summary>
        /// <param name="board"> Current state of the board </param>
        public void SheepMovement(Board board, int sheepDirection)
        {
            // Displays Sheep's movement options on screen
            Console.WriteLine("Which direction do you wish to move the Sheep?\n"
            + "1 - TopLeft      2 - TopRight\n"
            + "3 - BottomLeft   4 - BottomRight\n"
            + "Keep in mind, the Sheep can't move backwards.");

            // Stores user choice
            int moveChoice;

            // Asks for user input until a valid one is given
            while (!int.TryParse(Console.ReadLine(), out moveChoice) ||
                moveChoice < 1 || moveChoice > 4) ;

            // Replaces 'S' in the previous position with an empty space
            board[XSheepPos, YSheepPos] = ' ';

            // Checks player movement choice and its viability on board layout
            // Moves Sheep if choice is viable or asks user for another choice
            if (moveChoice == 1 && (sheepDirection == 2 || sheepDirection == 3))
            {
                // Checks if the Sheep can move in the specified direction
                if (XSheepPos > 0 && YSheepPos > 0
                    && board[XSheepPos - 1, YSheepPos - 1] != 'S'
                    && board[XSheepPos - 1, YSheepPos - 1] != 'W')
                {
                    // Reduces Sheep's X position by 1
                    XSheepPos -= 1;

                    // Reduces Sheep's Y position by 1
                    YSheepPos -= 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // Prompts user to choose movement option again
                    SheepMovement(board, sheepDirection);
                }
            }
            // Checks player movement choice and its viability on board layout
            // Moves Sheep if choice is viable or asks user for another choice
            else if (moveChoice == 2 && 
                (sheepDirection == 3 || sheepDirection == 4))
            {
                // Checks if the Sheep can move in the specified direction
                if (XSheepPos > 0 && YSheepPos < 7
                    && board[XSheepPos - 1, YSheepPos + 1] != 'S'
                    && board[XSheepPos - 1, YSheepPos + 1] != 'W')
                {
                    // Reduces Sheep's X position by 1
                    XSheepPos -= 1;

                    // Increases Sheep's Y position by 1
                    YSheepPos += 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // Prompts user to choose movement option again
                    SheepMovement(board, sheepDirection);
                }
            }
            // Checks player movement choice and its viability on board layout
            // Moves Sheep if choice is viable or asks user for another choice
            else if (moveChoice == 3 
                && (sheepDirection == 1 || sheepDirection == 2))
            {
                // Checks if the Sheep can move in the specified direction
                if (XSheepPos < 7 && YSheepPos > 0
                    && board[XSheepPos + 1, YSheepPos - 1] != 'S'
                    && board[XSheepPos + 1, YSheepPos - 1] != 'W')
                {
                    // Increases Sheep's X position by 1
                    XSheepPos += 1;

                    // Increases Sheep's X position by 1
                    YSheepPos -= 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // Prompts user to choose movement option again
                    SheepMovement(board, sheepDirection);
                }
            }
            // Checks player movement choice and its viability on board layout
            // Moves Sheep if choice is viable or asks user for another choice
            else if (moveChoice == 4 
                && (sheepDirection == 1 || sheepDirection == 4))
            {
                // Checks if the Sheep can move in the specified direction
                if (XSheepPos < 7 && YSheepPos < 7
                    && board[XSheepPos + 1, YSheepPos + 1] != 'S'
                    && board[XSheepPos + 1, YSheepPos + 1] != 'W')
                {
                    // Increases Sheep's X position by 1
                    XSheepPos += 1;
                    // Increases Sheep's Y position by 1
                    YSheepPos += 1;
                }
                // The movement choice isn't valid
                else
                {
                    // Displays text saying that the choice isn't possible
                    Console.WriteLine("Your Sheep can't move there.\n");

                    // Prompts user to choose movement option again
                    SheepMovement(board, sheepDirection);
                }
            }
            // Prompts user to choose another movement choice 
            else
            {
                // Displays text saying that the choice isn't possible
                Console.WriteLine("Your Sheep can't move backwards.\n");

                // Prompts user to choose movement option again
                SheepMovement(board, sheepDirection);
            }            
            // Replaces the empty space in the new position with an 'S'
            board[XSheepPos, YSheepPos] = 'S';
        }
    }
}