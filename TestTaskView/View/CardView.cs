using System;
using System.Threading;
using TestTaskModel;

namespace TestTaskUI.View
{
    /// <summary>
    /// Card Interaction
    /// </summary>
    /// <returns>Name Card</returns>
    public static class CardView
    {
        /// <summary>
        /// First element is create?
        /// </summary>
        public static bool FirstElement;
        /// <summary>
        /// Is card Read?
        /// </summary>
        private static bool? _isRead;
        /// <summary>
        /// Input Player
        /// </summary>
        private static int _inputMenu;
        /// <summary>
        /// Waiting for user input 
        /// </summary>
        private const int Sleep = 1000;
        /// <summary>
        /// Waiting for user input(Count for)
        /// </summary>
        private const int TimeForRead = 15;
        /// <summary>
        /// Card name Input
        /// </summary>
        /// <returns>Name Card</returns>
        public static string[] Input()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter a word in a foreign language\n"); 
            var a = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter translation\n");
            var b = Console.ReadLine();
            string[] card = new[] {a, b};
            return card;
        }
        /// <summary>
        /// Input Count Card
        /// </summary>
        /// <returns>Input count Card create</returns>
        public static int CardCount()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("How many cards do you want to add?\n");
            return (Convert.ToInt32(Console.ReadLine()));
        }
        /// <summary>
        /// Card name Output
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static int Output(Card card)
        {
            if (card.OpenBackText  &&!card.Learned)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n"+card.OpenBackCard());
                return 2;
            }

            if (FirstElement)
            {
                Console.WriteLine("Next");
                Console.ReadLine();
                Console.Clear();
               
            }

            FirstElement = true;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            _inputMenu = 2;
            Console.WriteLine("\n" + card.OpenFrontCard());
            var th = new Thread(WaitingForEntry);
            th.Start();
            for (int i = 0; i < TimeForRead; i++)
            {
                Thread.Sleep(Sleep);
                if (_isRead != false) continue;
                Console.Clear();
                return (_inputMenu);
            }
            _isRead = null;
            Console.Clear();
            return (_inputMenu);
        }
        /// <summary>
        /// Waiting input
        /// </summary>
        private static void WaitingForEntry() 
        {
            Console.WriteLine("\nEnter :" +
                              "\n1 to mark a word as learned" +
                              "\n2 to word as Open");
                              
            _isRead = true;
            _inputMenu = Convert.ToInt32(Console.ReadLine());
            _isRead = false;
            
        }
        /// <summary>
        /// Input Random Count Card
        /// </summary>
        /// <returns>Input count random Card create</returns>
        public static int CountCardRandom()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("How many cards do you want to see?\n");
            return (Convert.ToInt32(Console.ReadLine()));
        }
    }
}
