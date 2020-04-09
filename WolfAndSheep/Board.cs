namespace WolfAndSheep
{
    public class Board
    {
        public char[,] BoardValues { get; set; }

        public Board(int sizeX, int sizeY)
        {
            BoardValues = new char[sizeX, sizeY];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (((x + y) % 2) == 0)
                    {
                        BoardValues[x, y] = '-';
                    }

                    if (((x + y) % 2) != 0)
                    {
                        BoardValues[x, y] = ' ';
                    }
                }
            }
        }
    }
}
