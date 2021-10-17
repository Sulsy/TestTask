using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTaskModel;

namespace UI.View
{

    public static class CardView
    {
        private static bool? _isRead;
        private static int _inputMenu;
        private static readonly int _sleep = 1000;
        private static readonly int _timeForRead=3;

        public static string[] CardInput()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Введите слово на иностанном языке\n"); 
            var a = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Введите перевод\n");
            var b = Console.ReadLine();
            string[] card = new[] {a, b};
            return card;
        }
        public static int CardCount()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Сколько карточек вы хотите добавить?\n");
            return (Convert.ToInt32(Console.ReadLine()));
        }
        public static int CardOutput(Card card)
        {
            Console.Clear();
            if (card.OpenBackText  &&!card.Learned)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n"+card.OpenBackCard());
                Console.ResetColor();
                return 2;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            _inputMenu = 2;
            Console.WriteLine("\n" + card.OpenFrontCard());
            Thread th = new Thread(WaitingForEntry);
            th.Start();
            for (int i = 0; i < _timeForRead; i++)
            {
                Thread.Sleep(_sleep);
                if (_isRead != false) continue;
                Console.Clear();
                return (_inputMenu);
            }
            _isRead = null;
            Console.Clear();
            return (_inputMenu);
        }
        public static void WaitingForEntry() 
        {
            Console.WriteLine("\nВведите:" +
                              "\n1 чтобы пометить слово как выученное" +
                              "\n2 чтобы узнать перевод");
                              
            _isRead = true;
            if(_isRead==true)
                _inputMenu = Convert.ToInt32(Console.ReadLine());
            _isRead = false;
            
        }
        public static int CountCardRandom()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Сколько карточек вы хотите посмотреть?\n");
            return (Convert.ToInt32(Console.ReadLine()));
        }
    }
}
