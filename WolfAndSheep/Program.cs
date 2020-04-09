using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Wolf[] pack = SetupSheep(board);
            (int, int)[] winCorridor = new (int,int)[pack.Length];

            for (int b = 0; b < pack.Length; b++)
            {
                winCorridor[b] = (pack[b].xWolfPos, pack[b].yWolfPos);
                pack[b].WolfOnBoard(board);
            }

            for (int b = 0; b < pack.Length; b++)
            {
                Console.WriteLine(winCorridor[b]);
            }

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
        }
        private static Wolf[] SetupSheep(Board board)
        {
            Console.WriteLine("1 = up , 2 = right, 3 = down, 4 = left");

            int input = Convert.ToInt32(Console.ReadLine());

            Wolf[] wolves = new Wolf[board.BoardValues.GetLength(1) / 2];

            int x = input == 1 || input == 4 ? 0 : 
                board.BoardValues.GetLength(1) - 1;

            int i = 0;

            for (int y = 0; y < board.BoardValues.GetLength(1); y++)
            {
                if (input == 1 || input == 3)
                {
                    if (board.BoardValues[x, y] == ' ')
                    {
                        wolves[i] = new Wolf(x, y);
                        i++;
                    }
                }
                else
                {
                    if (board.BoardValues[y, x] == ' ')
                    {
                        wolves[i] = new Wolf(y, x);
                        i++;
                    }
                }
            }
            return wolves;
        }
    }
}
