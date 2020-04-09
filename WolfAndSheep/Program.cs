using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Sheep[] allSheeps = SetupSheep(board);
            Wolf wolf = new Wolf(3, 4);

            wolf.WolfOnBoard(board);
            (int, int)[] winCorridor = new (int,int)[allSheeps.Length];

            for (int b = 0; b < allSheeps.Length; b++)
            {
                winCorridor[b] = (allSheeps[b].xSheepPos, allSheeps[b].ySheepPos);
                allSheeps[b].SheepOnBoard(board);
            }

            //---------- See win corridors for wolf--------------
            //for (int b = 0; b < allSheeps.Length; b++)
            //{
            //    Console.WriteLine(winCorridor[b]);
            //}

            while(true)
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
                allSheeps[0].SheepMovement(board); 
            }
        }
        private static Sheep[] SetupSheep(Board board)
        {
            Console.WriteLine("1 = up , 2 = right, 3 = down, 4 = left");

            int input = Convert.ToInt32(Console.ReadLine());

            Sheep[] wolves = new Sheep[board.BoardValues.GetLength(1) / 2];

            int x = input == 1 || input == 4 ? 0 : 
                board.BoardValues.GetLength(1) - 1;

            int i = 0;

            for (int y = 0; y < board.BoardValues.GetLength(1); y++)
            {
                if (input == 1 || input == 3)
                {
                    if (board.BoardValues[x, y] == ' ')
                    {
                        wolves[i] = new Sheep(x, y);
                        i++;
                    }
                }
                else
                {
                    if (board.BoardValues[y, x] == ' ')
                    {
                        wolves[i] = new Sheep(y, x);
                        i++;
                    }
                }
            }
            return wolves;
        }
    }
}
