using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            for (int x = 0; x < board.BoardValues.GetLength(0); x++)
            {
                for (int y = 0; y < board.BoardValues.GetLength(1); y++)
                {
                    Console.Write(board.BoardValues[x,y].Visual);
                }
                Console.WriteLine();
            }
        }
    }
}
