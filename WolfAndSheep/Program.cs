using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Main class of the program containing the game loop
    /// </summary>
    class Program
    {
        /// <summary>
        /// Game initialization and and game loop
        /// </summary>
        /// <param name="args"> Argum </param>
        private static void Main(string[] args)
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
            Console.Clear();
            Console.WriteLine("+---+---+---+---+---+---+---+---+");
            for (int x = 0; x < board.XDim; x++)
            {
                for (int y = 0; y < board.YDim; y++)
                {
                    Console.Write("|");
                    if (board[x, y] == '-')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write(' ');
                    Console.Write(board[x, y]);
                    Console.Write(' ');
                    Console.ResetColor();
                }
                Console.Write("| \n");
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
            }
            Console.WriteLine("+-------------------------------+");
        }

        private static int sheepDirection;

        private static (Wolf, Sheep[]) SetupSheep(Board board)
        {
            Render(board);

            Console.WriteLine("Where do you want your Sheep on the board?\n"
                + "1 = up , 2 = right, 3 = down, 4 = left");

            int input;

            while (!int.TryParse(Console.ReadLine(), out input) ||
                input < 1 || input > 4);

            sheepDirection = input;

            Sheep[] sheeps = new Sheep[board.XDim / 2];

            int x = input == 1 || input == 4 ? 0 :
                board.YDim - 1;

            int i = 0;

            for (int y = 0; y < board.XDim; y++)
            {
                if (input == 1 || input == 3)
                {
                    if (board[x, y] == ' ')
                    {
                        sheeps[i] = new Sheep(x, y);
                        i++;
                    }
                }
                else
                {
                    if (board[y, x] == ' ')
                    {
                        sheeps[i] = new Sheep(y, x);
                        i++;
                    }
                }
            }

            for (int l = 0; l < sheeps.Length; l++)
            {
                board[sheeps[l].XSheepPos,
                    sheeps[l].YSheepPos] = 'S';
            }
            return (SetupWolf(input, board), sheeps);
        }

        private static Wolf SetupWolf(int side, Board board)
        {
            Render(board);

            int x = side == 1 || side == 4 ?
                board.XDim - 1 : 0;

            (int x, int y)[] position = new
                (int, int)[board.XDim / 2];

            int i = 0;

            for (int y = 0; y < board.YDim; y++)
            {
                if (side == 1 || side == 3)
                {
                    if (board[x, y] == ' ')
                    {
                        position[i] = (x, y);
                        i++;
                    }
                }
                else
                {
                    if (board[y, x] == ' ')
                    {
                        position[i] = (y, x);
                        i++;
                    }
                }
            }

            for (int l = 0; l < position.Length; l++)
            {
                board[position[l].x, position[l].y] =
                    (l + 1).ToString()[0];
            }

            Render(board);

            Console.WriteLine("Where do you wish to place the Wolf?"
                + "\nPress 1 , 2 , 3 or 4");

            for (int l = 0; l < position.Length; l++)
            {
                board[position[l].x, position[l].y] = ' ';
            }

            int input;
            while (!int.TryParse(Console.ReadLine(), out input) ||
                input < 1 || input > position.Length) ;

            return new Wolf(position[input - 1].x, position[input - 1].y);
        }
    }
}