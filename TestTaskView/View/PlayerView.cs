using System;
using TestTaskModel;

namespace TestTaskUI.View
{
    /// <summary>
    /// Player Interaction
    /// </summary>
    public class PlayerView
    {
        /// <summary>
        /// Player name Input
        /// </summary>
        /// <returns>Name Player</returns>
        public static string Input()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter your name\n");
            return Console.ReadLine();
        }
        /// <summary>
        /// Output name Player
        /// </summary>
        /// <param name="deck">Selected Player</param>
        public static string Output(Player player)
        {
            return player.ToString();
        }
    }
}
