using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Sheep[] allSheep = SetupSheep(board);
            Wolf wolf = new Wolf(3, 4);

            WinConditions winConditions = new WinConditions();

            wolf.WolfOnBoard(board);
            (int, int)[] winCorridor = new (int,int)[allSheep.Length];

            for (int b = 0; b < allSheep.Length; b++)
            {
                winCorridor[b] = (allSheep[b].xSheepPos, allSheep[b].ySheepPos);
                allSheep[b].SheepOnBoard(board);
            }

            SetupWolf(winCorridor);

            //---------- See win corridors for wolf--------------
            //for (int b = 0; b < allSheep.Length; b++)
            //{
            //    Console.WriteLine(winCorridor[b]);
            //}

            while (true)
            {   
                Console.WriteLine("+-+-+-+-+-+-+-+-+");
                for (int x = 0; x < board.BoardValues.GetLength(0); x++)
                {
                    for (int y = 0; y < board.BoardValues.GetLength(1); y++)
                    {
                        Console.Write('|');
                        if (board.BoardValues[x, y] == '-')
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.Write(board.BoardValues[x, y]);
                        Console.ResetColor();

                    }
                    Console.Write("| \n");
                    Console.WriteLine("+-+-+-+-+-+-+-+-+");
                }
                allSheep[0].SheepMovement(board);
                
                winConditions.SheepVictory(board, wolf);     
            }
        }
        private static Sheep[] SetupSheep(Board board)
        {
            Console.WriteLine("1 = up , 2 = right, 3 = down, 4 = left");

            int input = Convert.ToInt32(Console.ReadLine());

            Sheep[] sheeps = new Sheep[board.BoardValues.GetLength(1) / 2];

            int x = input == 1 || input == 4 ? 0 : 
                board.BoardValues.GetLength(1) - 1;

            int i = 0;

            for (int y = 0; y < board.BoardValues.GetLength(1); y++)
            {
                if (input == 1 || input == 3)
                {
                    if (board.BoardValues[x, y] == ' ')
                    {
                        sheeps[i] = new Sheep(x, y);
                        i++;
                    }
                }
                else
                {
                    if (board.BoardValues[y, x] == ' ')
                    {
                        sheeps[i] = new Sheep(y, x);
                        i++;
                    }
                }
            }
            return sheeps;
        }

        private static void SetupWolf((int,int)[] winCorridors)
        {
            int x = -1;
            int y = -1;

            if (winCorridors[0].Item1 == 0 && winCorridors[1].Item1 == 0)
                x = 7;
            else if (winCorridors[0].Item1 == 7 && winCorridors[1].Item1 == 7)
                x = 0;
            else if (winCorridors[0].Item2 == 0 && winCorridors[1].Item2 == 0)
                y = 7;
            else
                y = 0;

            for (int z = 0; z < winCorridors.Length; z++)
            {
                if (x > -1)
                    winCorridors[z].Item1 = x;
                if (y > -1)
                    winCorridors[z].Item2 = y;
            }
        }
    }
}
