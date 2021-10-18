using System;
using TestTaskModel;

namespace TestTaskUI.View
{
    /// <summary>
    /// Deck Interaction
    /// </summary>
    public class DeckView 
    {
        /// <summary>
        /// Deck name Input
        /// </summary>
        /// <returns>Name Deck</returns>
        public static string Input()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Enter the name of the deck\n");
            return Console.ReadLine();
        }
        /// <summary>
        /// Deck all operation
        /// </summary>
        /// <returns>Player input</returns>
        public static int Operation()
        {

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Enter:\n" +
                                      "1 to see N random cards available\n" +
                                      "2 to see all available maps\n" +
                                      "3 to add a card\n");
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    continue;
                }
            }
            
        }
        /// <summary>
        /// Output name Deck
        /// </summary>
        /// <param name="deck">Selected deck</param>
        public static void Output(Deck deck)
        {
            Console.WriteLine(deck);
        }
    }
}
