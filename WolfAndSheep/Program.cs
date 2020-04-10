﻿using System;

namespace WolfAndSheep
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "PLEASE END MY PAIN, I WANT TO DIE";

            Board board = new Board(8, 8);
            VictoryConditions vc = new VictoryConditions();

            (Wolf wolf, Sheep[] sheeps) things = SetupSheep(board);

            Sheep[] allSheep = things.sheeps;
            Wolf wolf = things.wolf;

            (int, int)[] winCorridor = new (int, int)[allSheep.Length];

            for (int b = 0; b < allSheep.Length; b++)
            {
                winCorridor[b] = (allSheep[b].xSheepPos, allSheep[b].ySheepPos);
                allSheep[b].SheepOnBoard(board);
            }

            wolf.WolfOnBoard(board);

            while (true)
            {
                for (int b = 0; b < allSheep.Length; b++)
                {
                    allSheep[b].SheepOnBoard(board, (b +1).ToString()[0]);
                }
                Render(board);

                Console.WriteLine("Which Sheep do you want to move?\n"
                    + "1 , 2 , 3 , 4");
                int sheepChoice = Convert.ToInt32(Console.ReadLine());

                for (int b = 0; b < allSheep.Length; b++)
                {
                    allSheep[b].SheepOnBoard(board);
                }

                allSheep[sheepChoice - 1].SheepMovement(board);
                Render(board);
                vc.SheepVictory(board, wolf);

                wolf.WolfMovement(board);
                Render(board);
                vc.WolfVictory(wolf, winCorridor);
            }
        }

        private static void Render(Board board)
        {
            Console.Clear();
            Console.WriteLine("+---+---+---+---+---+---+---+---+");
            for (int x = 0; x < board.BoardValues.GetLength(0); x++)
            {
                for (int y = 0; y < board.BoardValues.GetLength(1); y++)
                {
                    Console.Write("|");
                    if (board.BoardValues[x, y] == '-')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write(' ');
                    Console.Write(board.BoardValues[x, y]);
                    Console.Write(' ');
                    Console.ResetColor();

                }
                Console.Write("| \n");
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
            }
            Console.WriteLine("+-------------------------------+");
        }
        private static (Wolf,Sheep[]) SetupSheep(Board board)
        {
            Render(board);

            Console.WriteLine("Where do you want your Sheep on the board?\n"
                + "1 = up , 2 = right, 3 = down, 4 = left");
            int input = 0;

            while (input < 1 || input > 4)
            {
                input = Convert.ToInt32(Console.ReadLine());
            }

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

            for (int l = 0; l < sheeps.Length; l++)
            {
                board.BoardValues[sheeps[l].xSheepPos, sheeps[l].ySheepPos] = 'S';
            }
            return (SetupWolf(input, board), sheeps);
        }

        private static Wolf SetupWolf(int side, Board board)
        {
            Render(board);

            int x = side == 1 || side == 4 ? board.BoardValues.GetLength(1) - 1 :
                0;

            (int x, int y)[] position = new(int,int)[board.BoardValues.GetLength(0) / 2];

            int i = 0;

            for (int y = 0; y < board.BoardValues.GetLength(1); y++)
            {
                if (side == 1 || side == 3)
                {
                    if (board.BoardValues[x, y] == ' ')
                    {
                        position[i] = (x, y);
                        i++;
                    }
                }
                else
                {
                    if (board.BoardValues[y, x] == ' ')
                    {
                        position[i] = (y, x);
                        i++;
                    }
                }
            }

            for (int l = 0; l < position.Length; l++)
            {
                board.BoardValues[position[l].x, position[l].y] = (l + 1).ToString()[0];
            }

            Render(board);

            Console.WriteLine("Where do you wish to place the Wolf?"
                + "\nPress 1 , 2 , 3 or 4");

            for (int l = 0; l < position.Length; l++)
            {
                board.BoardValues[position[l].x, position[l].y] = ' ';
            }

            while (true)
            {
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1: return new Wolf(position[0].x, position[0].y);
                    case 2: return new Wolf(position[1].x, position[1].y);
                    case 3: return new Wolf(position[2].x, position[2].y);
                    case 4: return new Wolf(position[3].x, position[3].y);
                }
            }
        }
    }
}
