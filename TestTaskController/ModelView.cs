using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskModel;

namespace TestTaskController
{
    public static class ModelView
    {
        public static void SelectOperation()
        {
            Player player = Player.GetInstance();
            while (true)
            {
                Console.WriteLine("Введите:" +
                                  "\n1 если хотите просмотреть все существующие колоды," +
                                  "\n2 если хотите просмотреть конкретную колоду " +
                                  "\n3 если хотите создать колоду\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        player.ShowDeck();
                        break;
                    case 2:
                        Console.WriteLine("Укажите название колоды\n");
                        var a = Console.ReadLine();
                        player.ShowDeck(a);
                        break;
                    case 3:
                        CreateDeck();
                        break;
                    default:
                        break;
                }
            }

        }

        public static HashSet<int> RandomCard(int count,int deckCount)
        {
            HashSet<int> numbers=new HashSet<int>();
            var r = new Random();
            while (numbers.Count < count)
            {
                numbers.Add(r.Next(0, deckCount));
            }

            return numbers;
        }
        public static void SetDeck(Player player,string name)
        {
            player.SetDeck(name);
        }
        public static void SetCard(Deck  deck,int number,string frontText,string backText)
        {
            deck.SetCard(number, frontText, backText);
        }
        public static Deck GetDeck(Player player, string name)
        {
            return player.GetDeck(name);
        }
        public static Card GetCard(Deck deck, int number)
        {
            return deck.GetCard(number);
        }
        public static void CreateCard(Deck deck)
        {
            Console.WriteLine("Сколько карточек вы хотите добавить?\n");
            var pl = (Convert.ToInt32(Console.ReadLine()));
            for (int i = 0; i < pl; i++)
            {
                Console.WriteLine("Введите слово на иностанном языке\n");
                var a = Console.ReadLine();
                Console.WriteLine("Введите перевод\n");
                var b = Console.ReadLine();
                SetCard(deck,i, a,b);
            }

        }
        public static void CreateDeck()
        {
            Player player = Player.GetInstance();
            Console.WriteLine("Введите название колоды\n");
            var a = Console.ReadLine();
            SetDeck(player, a);
            CreateCard(player.GetDeck(a));


        }
    }
}
