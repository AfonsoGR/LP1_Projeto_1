namespace WolfAndSheep
{
    /// <summary>
    /// Creates and stores the board
    /// </summary>
    public class Board
    {
        // Property containing all the board values
        private readonly char[,] BoardValues;

        /// <summary>
        /// Returns the X dimension of the board
        /// </summary>
        public int XDim => BoardValues.GetLength(0);

        /// <summary>
        /// Returns the Y dimension of the board
        /// </summary>
        public int YDim => BoardValues.GetLength(1);

        /// <summary>
        /// Sets the value of the board on the given postition
        /// </summary>
        /// <param name="x"> The wanted x position </param>
        /// <param name="y"> The wanted y position </param>
        /// <returns> A character </returns>
        public char this[int x, int y]
        {
            get => BoardValues[x, y];
            set => BoardValues[x, y] = value;
        }

        /// <summary>
        /// Creates the board with given width and height
        /// </summary>
        /// <param name="sizeX"> Wanted width </param>
        /// <param name="sizeY"> Wanted height </param>
        public Board(int sizeX, int sizeY)
        {
            // Assigns the size to the Array
            BoardValues = new char[sizeX, sizeY];

            // A loop for the width
            for (int x = 0; x < sizeX; x++)
            {
                // A loop for the height
                for (int y = 0; y < sizeY; y++)
                {
                    // Checks if the current position is even
                    if (((x + y) % 2) == 0)
                    {
                        // Assigns a dash to that position
                        BoardValues[x, y] = '-';
                    }

                    // Checks if the current position is odd
                    if (((x + y) % 2) != 0)
                    {
                        // Assigns an empty space to that position
                        BoardValues[x, y] = ' ';
                    }
                }
            }
        }
    }
}