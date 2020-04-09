namespace WolfAndSheep
{
    /// <summary>
    /// 
    /// </summary>
    public class Wolf
    {
        /// <summary>
        /// Gets and Sets the value of the Wolf's X position
        /// </summary>
        /// <value></value>
        public int xWolfPos {get; set; }
        
        /// <summary>
        /// Gets and Sets the value of the Wolf's Y position
        /// </summary>
        /// <value></value>
        public int yWolfPos {get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Wolf(int row = 0, int column = 0)
        {
            xWolfPos = row;
            yWolfPos = column;
        }
    }
}