using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestTaskModel;
using UI.View;

namespace UI
{
    public enum Input
    {
        SeeAll=1,
        Find=2,
        Create = 3,
        FindRandom = 4,
        Learned=5,
        Next=6
        

    }
    public static class ModelView
    {
        public static void SelectOperation()
        {
            Player player = Player.LoadData();
            Player.instance = player;
            Deck deck;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nВведите:" +
                                  "\n1 если хотите просмотреть все существующие колоды," +
                                  "\n2 если хотите просмотреть колоду " +
                                  "\n3 если хотите создать колоду\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case (int)Input.SeeAll:

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        ShowDecks(player);

                        break;
                    case (int)Input.Find:
                        deck =GetDeck(player);
                        var kopeck = DeckView.DeckOperation();
                        OpenDeck(deck, kopeck == 1 ? CardView.CountCardRandom() : deck._deckCard.Count);
                        break;
                    case (int)Input.Create:
                        CreateDeck();
                        break;
                    default:
                        break;
                }
                Player.SaveData();
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
        public static Deck GetDeck(Player player)
        {
            return player.GetDeck(DeckView.DeckInput());
        }
        public static void ShowDecks(Player player)
        {
            List<Deck> allDecks =player.ShowDeck();
            foreach (var _deck in allDecks) { DeckView.DeckOutput(_deck); }
        }
        public static void CreateCard(Deck deck)
        {
            var pl = CardView.CardCount();
            for (int i = 0; i < pl; i++)
            {
                var card=CardView.CardInput();
                SetCard(deck, i, card[0], card[1]);
            }

        }
        public static void CreateDeck()
        {
            Player player = Player.instance;
            var name = DeckView.DeckInput();
            SetDeck(player, name);
            CreateCard(player.GetDeck(name));


        }
        public static void OpenDeck(Deck deck, int count)
        {
            HashSet<int> numbers=null;
            bool rand = false, randD = false;
            var deckCardCount = deck._deckCard.Count;
            if (count!= deckCardCount)
            {
                rand = true;
                numbers = RandomCard(count, deckCardCount);
            }
            foreach (var card in deck._deckCard)
            {
                if (rand)
                {
                    foreach (var randCard in numbers.Where(randCard => card.NumberInDeck == randCard))
                    {
                        randD = true;
                    }

                    if (randD)
                    {
                        randD = false;
                        continue;
                    }
                }
                var cardL = card.Learned || card.OpenBackText ? 0 : CardView.CardOutput(card);
                switch (cardL)
                {
                    case 1:
                        Console.Clear();
                        card.IsCardLearned();
                        break;
                    case 2:
                        Console.Clear();
                        card.IsCardOpen();
                        CardView.CardOutput(card);
                        card.IsCardClose();
                        break; ;
                    default:
                        continue;
                }
            }
        }
    }
}
