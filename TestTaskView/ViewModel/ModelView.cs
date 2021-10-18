using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestTaskModel;
using TestTaskUI.View;

namespace TestTaskUI.ViewModel
{
    /// <summary>
    /// List Input variants 
    /// </summary>
    public enum Input
    {
        SeeAll=1,
        Find=2,
        Create = 3,
        FindRandom = 4,
        Learned=5,
        Next=6
    }
    /// <summary>
    /// Model View program 
    /// </summary>
    public static class ModelView
    {
        /// <summary>
        /// Main menu
        /// </summary>
        public static void MainMenu()
        {
            Deck deck;
            Player player;
            player = File.Exists(Player.Path) ? Player.LoadData() : new Player(PlayerView.Input());
            Player.Instance = player;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nPlayer " + PlayerView.Output(player)+"\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEnter:" +
                                  "\n1 if you want to see all the existing decks," +
                                  "\n2 if you want to see the deck " +
                                  "\n3 if you want to create a deck\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case (int)Input.SeeAll:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        ShowDecks(player);

                        break;
                    case (int)Input.Find:
                        deck =GetDeck(player);
                        DeckOperation(deck,DeckView.Operation());
                        break;
                    case (int)Input.Create:
                        CreateDeck();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
                Player.SaveData();
            }

        }
        /// <summary>
        /// Generation random number card
        /// </summary>
        /// <param name="count">Count random</param>
        /// <param name="deckCount">Count Card on Deck</param>
        /// <returns>HasSet Random number  Card</returns>
        private static HashSet<int> RandomCard(int count,int deckCount)
        {
            var numbers=new HashSet<int>();
            var r = new Random();
            while (numbers.Count < deckCount-count)
            {
                numbers.Add(r.Next(0, deckCount));
            }

            return numbers;
        }
        /// <summary>
        /// Create Deck
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="name">Name Deck</param>
        private static void SetDeck(Player player,string name)
        {
            player.SetDeck(name);
        }
        /// <summary>
        /// Create Card
        /// </summary>
        /// <param name="deck">Deck</param>
        /// <param name="number">Number Card</param>
        /// <param name="frontText">Front Text Card</param>
        /// <param name="backText">Back Text Card</param>
        private static void SetCard(Deck  deck,int number,string frontText,string backText)
        {
            deck.SetCard(number, frontText, backText);
        }
        /// <summary>
        /// Return Deck
        /// </summary>
        /// <param name="player">Player</param>
        /// <returns>Deck</returns>
        private static Deck GetDeck(Player player)
        {
            return player.GetDeck(DeckView.Input());
        }
        /// <summary>
        /// Show Deck
        /// </summary>
        /// <param name="player">Player</param>
        private static void ShowDecks(Player player)
        {
            List<Deck> allDecks =player.ShowDeck();
            foreach (var deck in allDecks) { DeckView.Output(deck); }
        }
        /// <summary>
        /// Create card
        /// </summary>
        /// <param name="deck">Deck</param>
        private static void CreateCard(Deck deck)
        {
            if (deck == null) return;
            var pl = CardView.CardCount();
            for (int i = 0; i < pl; i++)
            {
                var card=CardView.Input();
                SetCard(deck, i+deck.DeckCard.Count, card[0], card[1]);
            }

        }
        /// <summary>
        /// Create Deck
        /// </summary>
        private static void CreateDeck()
        {
            Player player = Player.Instance;
            var name = DeckView.Input();
            SetDeck(player, name);
            CreateCard(player.GetDeck(name));


        }
        /// <summary>
        /// Operation on Deck
        /// </summary>
        /// <param name="deck">Deck</param>
        /// <param name="inputDeckOperation">Input Deck Operation</param>
        private static void DeckOperation(Deck deck, int inputDeckOperation)
        {
            switch (inputDeckOperation)
            {
                case (int)Input.SeeAll:
                    OpenDeck(deck, CardView.CountCardRandom());
                    break;
                case (int)Input.Find:
                    OpenDeck(deck, deck.DeckCard.Count);
                    break;
                case (int)Input.Create:
                    CreateCard(deck);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            CardView.FirstElement = false;
        }
        /// <summary>
        /// Open N Count card on Deck
        /// </summary>
        /// <param name="deck">Deck</param>
        /// <param name="count">Count card</param>
        private static void OpenDeck(Deck deck, int count)
        {
            if (deck == null || deck.DeckCard.Count < count) return;
            HashSet<int> numbers = null;
            bool rand = false, randD = false;
            var deckCardCount = deck.DeckCard.Count;

            if (count != deckCardCount)
            {
                rand = true;
                numbers = RandomCard(count, deckCardCount);
            }

            foreach (var card in deck.DeckCard)
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

                var inputCardOperation = card.Learned || card.OpenBackText ? 0 : CardView.Output(card);
                CardOperation(card, inputCardOperation);
            }
        } 
        /// <summary>
        /// Card Operation
        /// </summary>
        /// <param name="card">Card</param>
        /// <param name="inputCardOperation">input Card Operation</param>
        private static void CardOperation(Card card, int inputCardOperation)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (inputCardOperation)
                {
                    case 1:
                        Console.Clear();
                        card.IsCardLearned();
                        return;
                    case 2:
                        Console.Clear();
                        card.IsCardOpen();
                        CardView.Output(card);
                        card.IsCardClose();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
