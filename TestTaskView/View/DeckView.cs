using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskModel;

namespace UI.View
{
    public static class DeckView
    {
        public static string DeckInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Введите название колоды\n");
            return Console.ReadLine();
        }
        public static int DeckOperation()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Введите:\n" +
                              "1 чтобы посмотреть N случайных карт\n"+
                              "2 чтобы получить информацию о конкретной карте\n");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void DeckOutput(Deck deck)
        {
            Console.WriteLine(deck);

        }
    }
}
