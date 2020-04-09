using System;

namespace WolfAndSheep
{
    public class WinConditions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="wolf"></param>
        /// <param name="sheep"></param>
        public void SheepVictory(Board board, Wolf wolf)
        {
            // X
            if((wolf.xWolfPos +1 > 7 && wolf.yWolfPos +1 > 7 || 
                board.BoardValues [wolf.xWolfPos +1, wolf.yWolfPos +1] == 'S') 
                && (wolf.xWolfPos -1 < 0 && wolf.yWolfPos -1 < 0 ||
                board.BoardValues [wolf.xWolfPos -1, wolf.yWolfPos -1] == 'S') 
                && (wolf.yWolfPos +1 > 7 && wolf.yWolfPos -1 < 0 ||
                board.BoardValues [wolf.xWolfPos +1, wolf.yWolfPos -1] == 'S') 
                && (wolf.yWolfPos -1 < 0 && wolf.yWolfPos +1 > 7 ||
                board.BoardValues [wolf.xWolfPos -1, wolf.yWolfPos +1] == 'S'))
            {
                // X
                Console.WriteLine("The Sheep have cornered the Wolf!\n"
                    + "SHEEP WIN!!!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="wolf"></param>
        /// <param name="sheep"></param>
        public void WolfVictory(Board board, Wolf wolf, Sheep sheep, 
            (int,int)[] winCorridors)
        {
            for(int i = 0; i < winCorridors.Length; i++)
            {
                if(winCorridors[i].Item1 == wolf.xWolfPos 
                    && winCorridors[i].Item2 == wolf.yWolfPos)
                {
                    Console.WriteLine("The Wolf has reached the Sheep's farm!\n"
                    + "WOLF WINS!!!");
                } 
            }
        }
    }
}