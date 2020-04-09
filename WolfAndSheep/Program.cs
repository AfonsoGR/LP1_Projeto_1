using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Wolf wolf = new Wolf(0,0);

            wolf.WolfOnBoard(board);

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
    }
}
