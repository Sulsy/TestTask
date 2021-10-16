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
            Console.WriteLine("Введите название колоды\n");
            return Console.ReadLine();
        }

        public static void DeckOutput(Deck deck)
        {
            Console.WriteLine(deck);

        }
    }
}
