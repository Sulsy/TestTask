using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskModel;

namespace UI.View
{
    public static class CardView
    {
        public static string[] CardInput()
        { 
            Console.WriteLine("Введите слово на иностанном языке\n"); 
            var a = Console.ReadLine(); 
            Console.WriteLine("Введите перевод\n"); 
            var b = Console.ReadLine();
            string[] card = new[] {a, b};
            return card;
        }
        public static int CardCount()
        {
            Console.WriteLine("Сколько карточек вы хотите добавить?\n");
            return (Convert.ToInt32(Console.ReadLine()));
        }
        public static int CardOutput(Card card)
        {
            if (card.Learned)
            {
                Console.WriteLine("\n"+card.OpenBackCard());
                return 0;
            }
            Console.WriteLine("\n" + card.OpenFrontCard());
            Console.WriteLine("\nВведите:" +
                              "\n1 чтобы пометить слово как выученное" +
                              "\n2 чтобы пометить узнать перевод"+
                              "\n3 чтобы закончить просмотр");
            return (Convert.ToInt32(Console.ReadLine()));


        }
    }
}
