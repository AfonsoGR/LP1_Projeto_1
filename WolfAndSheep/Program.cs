using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Main class of the program containing the game loop
    /// </summary>
    class Program
    {
        // Stores the side of the board where the sheep will be placed on
        private static int sheepDirection;

        /// <summary>
        /// Game initialization and and game loop
        /// </summary>
        private static void Main()
        {
            // Creates a new Intro Rules
            IntroRules introRules = new IntroRules();
            
            // Calls IR from Intro Rules
            introRules.IR(); 

            // Creates a new board with the given size
            Board board = new Board(8, 8);

            // Creates a new Victory Conditions
            VictoryConditions vc = new VictoryConditions();

            // A touple containing a list of sheeps and a wolf
            (Wolf wolf, Sheep[] sheeps) boardPieces = SetupSheep(board);

            // Sets the array of sheeps to the array on boardPieces
            Sheep[] allSheep = boardPieces.sheeps;

            // Sets the wolf to the one on boardPieces
            Wolf wolf = boardPieces.wolf;

            // Creates an array of the places the wolf can win
            (int, int)[] winCorridor = new (int, int)[allSheep.Length];

            // A loop to initialize the sheep on the board and fill winCorridor
            for (int b = 0; b < allSheep.Length; b++)
            {
                // Sets the winCorridor to the position of the sheep
                winCorridor[b] = (allSheep[b].XSheepPos, allSheep[b].YSheepPos);
                // Initializes the sheep on the board
                allSheep[b].SheepOnBoard(board);
            }

            // Initializes the wolf on the board
            wolf.WolfOnBoard(board);

            // Renders the board
            Render(board);

            // Main loop of the game
            while (true)
            {
                // Moves the wolf to the wanted position
                wolf.WolfMovement(board);

                // Renders the board
                Render(board);

                // Checks if the wolf has won
                vc.WolfVictory(wolf, winCorridor);

                // Checks all the sheep
                for (int b = 0; b < allSheep.Length; b++)
                {
                    // Sets it's visuals to their number
                    allSheep[b].SheepOnBoard(board, (b + 1).ToString()[0]);
                }
                // Renders the board
                Render(board);

                // Displays information to the user
                Console.WriteLine("Which Sheep do you want to move?\n"
                    + "1 , 2 , 3 , 4");

                // Stores the decision of the user
                int sheepChoice;

                // Asks the user for input until a viable one is given
                while (!int.TryParse(Console.ReadLine(), out sheepChoice) ||
                    sheepChoice < 1 || sheepChoice > allSheep.Length) ;

                // Checks all the sheep
                for (int b = 0; b < allSheep.Length; b++)
                {
                    // Resets the sheep visuals to their normal one
                    allSheep[b].SheepOnBoard(board);
                }

                // Moves the selected sheep to the wanted position
                allSheep[sheepChoice - 1].SheepMovement(board, sheepDirection);

                // Renders the board
                Render(board);

                // Checks if the sheep have won
                vc.SheepVictory(board, wolf);
            }
        }

        /// <summary>
        /// Renders the board with all it's pieces
        /// </summary>
        /// <param name="board"> The current state of the board </param>
        private static void Render(Board board)
        {
            // Clears the console
            Console.Clear();

            // A loop for the width of the board
            for (int x = 0; x < board.XDim; x++)
            {
                // Displays the middle or end of the board
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
                // A loop for the height of the board
                for (int y = 0; y < board.YDim; y++)
                {
                    // Displays a vertical bar to seperate de symbols
                    Console.Write("|");
                    // Checks if the current piece has a dash
                    if (board[x, y] == '-')
                    {
                        // Switches the background color to white
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    // Displays the current symbol on the board
                    Console.Write($" {board[x, y]} ");

                    // Resets the color of the background
                    Console.ResetColor();
                }
                // If it's at the end of the line writes an extra vertical bar
                Console.Write("| \n");
                
            }
            // Displays the end of the board
            Console.WriteLine("+---+---+---+---+---+---+---+---+" +
                              "+-------------------------------+");
        }

        /// <summary>
        /// Setups the positions of the sheeps and the wolf
        /// </summary>
        /// <param name="board"> The current board </param>
        /// <returns> A touple with all the sheep and a wolf </returns>
        private static (Wolf, Sheep[]) SetupSheep(Board board)
        {
            // Renders the board
            Render(board);

            // Displays the possible places to place the sheeps
            Console.WriteLine("Where do you want your Sheep on the board?\n"
                + "1 = up , 2 = right, 3 = down, 4 = left");

            // Variable for storing the input of the user
            int input;

            // Asks for input while it's not the wanted input
            while (!int.TryParse(Console.ReadLine(), out input) ||
                input < 1 || input > 4);

            // Sets the sheepDirection variable the same as input
            sheepDirection = input;

            // Creates an array of sheep half the size of the board width
            Sheep[] sheeps = new Sheep[board.XDim / 2];

            // Creates x and gives it a value according to the input
            int x = input == 1 || input == 4 ? 0 :
                board.YDim - 1;

            // Index to store a new Sheep on the sheeps array
            int i = 0;

            // A for loop for the height of the board
            for (int y = 0; y < board.YDim; y++)
            {
                // Checks if the choosen side is up or down
                if (input == 1 || input == 3)
                {
                    // checks if the board is an empty space
                    if (board[x, y] == ' ')
                    {
                        // Creates a new sheep at the given x and y position
                        sheeps[i] = new Sheep(x, y);
                        // Increments the Index i by one
                        i++;
                    }
                }
                // If it's left or right flips the x and y
                else
                {
                    // checks if the board is an empty space
                    if (board[y, x] == ' ')
                    {
                        // Creates a new sheep at the given x and y position
                        sheeps[i] = new Sheep(y, x);
                        // Increments the Index i by one
                        i++;
                    }
                }
            }

            // Checks all the sheep on the sheeps array
            for (int l = 0; l < sheeps.Length; l++)
            {
                // Sets the board visual to S where the current sheep is
                board[sheeps[l].XSheepPos, sheeps[l].YSheepPos] = 'S';
            }

            // Gets a wolf from SetupWolf and returns it with the sheeps array 
            return (SetupWolf(input, board), sheeps);
        }

        /// <summary>
        /// Creates a new wolf at the desired position
        /// </summary>
        /// <param name="side"> The side the player put the sheep on </param>
        /// <param name="board"> The current board </param>
        /// <returns> A new wolf </returns>
        private static Wolf SetupWolf(int side, Board board)
        {
            // Renders the board
            Render(board);

            // Creates x and gives it a value according to the input
            int x = side == 1 || side == 4 ? board.XDim - 1 : 0;

            // Array of positions where the player can place the wolf
            (int x, int y)[] position = new (int, int)[board.XDim / 2];

            // Index to store a new Sheep on the sheeps array
            int i = 0;

            // A for loop for the height of the board
            for (int y = 0; y < board.YDim; y++)
            {
                // Checks if the choosen side is up or down
                if (side == 1 || side == 3)
                {
                    // checks if the board is an empty space
                    if (board[x, y] == ' ')
                    {
                        // Assigns the postion at the index the x and y
                        position[i] = (x, y);
                        // Increments the Index i by one
                        i++;
                    }
                }
                // If it's left or right flips the x and y
                else
                {
                    // checks if the board is an empty space
                    if (board[y, x] == ' ')
                    {
                        // Assigns the postion at the index the x and y
                        position[i] = (y, x);
                        // Increments the Index i by one
                        i++;
                    }
                }
            }

            // Checks all the positions on the positions array
            for (int l = 0; l < position.Length; l++)
            {
                // Sets the board visual to a number for each position
                board[position[l].x, position[l].y] = (l + 1).ToString()[0];
            }

            // Renders the board
            Render(board);

            // Display information to the user
            Console.WriteLine("Where do you wish to place the Wolf?"
                + "\nPress 1 , 2 , 3 or 4");

            // Checks all the positions on the positions array
            for (int l = 0; l < position.Length; l++)
            {
                // Resets the previous set visuals to an empty space
                board[position[l].x, position[l].y] = ' ';
            }

            // Creates a variable to store the player input
            int input;

            // Asks for input while it's not the wanted input
            while (!int.TryParse(Console.ReadLine(), out input) ||
                input < 1 || input > position.Length) ;

            // Returns a wolf the a the position choosen by the player
            return new Wolf(position[input - 1].x, position[input - 1].y);
        }
    }
}