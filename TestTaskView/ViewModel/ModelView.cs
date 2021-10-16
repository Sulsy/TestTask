using System;
using System.Collections.Generic;
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
            Player player = new Player("Oleg");
            Player.instance = player;
            while (true)
            {
                Console.WriteLine("Введите:" +
                                  "\n1 если хотите просмотреть все существующие колоды," +
                                  "\n2 если хотите просмотреть конкретную колоду " +
                                  "\n3 если хотите создать колоду\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case (int)Input.SeeAll:
                        player.ShowDeck();
                        break;
                    case (int)Input.Find:
                        var deckInput = DeckView.DeckInput();
                        var deck = player.GetDeck(deckInput);
                        DeckView.DeckOutput(deck);
                        OpenDeck(deck);
                        break;
                    case (int)Input.Create:
                        CreateDeck();
                        break;
                    default:
                        player= Player.LoadData();
                        Player.instance = player;
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

        public static void OpenDeck(Deck deck)
        {
            Console.Clear();
            for (int i = 0; i < deck._deckCard.Count; i++)
            {

                var card = deck._deckCard[i];
                var cardL =card.Learned==true ? 0 : CardView.CardOutput(card);
                switch (cardL)
                {
                    case 1:
                        Console.Clear();
                        card.IsCardLearned();
                        break;
                    case 2:
                        Console.Clear();
                        card.IsCardLearned();
                        CardView.CardOutput(card);
                        break;
                    case 3:
                        return;
                    default:
                        continue;
                }
            }
            
        }
    }
}
