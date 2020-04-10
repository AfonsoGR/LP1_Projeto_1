using System;

namespace WolfAndSheep
{
    /// <summary>
    /// 
    /// </summary>
    public class IntroRules
    {
        /// <summary>
        /// 
        /// </summary>
        public void IR()
        {
            //
            Console.WriteLine("Welcome to Wolf & Sheep!\n" 
                + "This is a turn-based PvP game for 2 players," 
                + "where one controls a Wolf and the other controls the Sheep."
                + "\nThe game will begin by the Sheep's Player selecting the " 
                + "side of the board where he wants to place his Sheep.\n"
                + "After doing this, the Wolf's Player will be able to select " 
                + "his starting point on the opposite side of the board.\n\n"
                + "The Wolf's goal is to get to one of the spaces " 
                + "that the sheep started in," 
                + "whilst the Sheep need to make the Wolf unable to move, by "
                + "cornering him (walls count towards this).\n" 
                + "If either the Sheep's Player or the Wolf's Player complete "
                + "their goals, they claim victory and the game is over.\n\n"
                + "Regarding their movement options:\n"
                + "\n\t- Both the Sheep and the Wolf can only move diagonally;"
                + "\n\t- They can only move in the empty/black spaces;"
                + "\n\t- The Sheep can only move forward;" 
                + "\n\t- The Wolf can move in all directions;" 
                + "\n\t- The Sheep's Players can choose one Sheep" 
                + "to move per turn;" 
                + "\n\t- The Wolf goes first.\n\n" 
                + "Good luck and have fun! Press any key to Start playing.");
            Console.Read();
        }
    }
}