using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TestTaskModel
{
    public class Player 
    {
        public static Player instance;
        public string NamePlayer { get; set; }
        public int Progress { get;  set; }

        public readonly List<Deck> _deckPlayer = new List<Deck>();
        public Player(string name) 
        {
            this.NamePlayer = name;
        }
        public void SetDeck(Deck deck)
        {
            if (_deckPlayer.All(x => x != deck))
            {
                _deckPlayer.Add(deck);
            }
        }
        public void SetDeck(string deckName)
        {
            if (_deckPlayer.All(x =>x.DeckName!=deckName))
            {
                _deckPlayer.Add(new Deck(deckName));
            }
        }
        public Deck GetDeck(string deck)
        {
            return _deckPlayer.Find(x => x.DeckName == deck);
        }

        public void ProgressPlayer(int progress)
        {
            this.Progress = progress;
        }

        public List<Deck> ShowDeck(int count = 0)
        {
            var showDeck = new List<Deck>();

            foreach (var deck in _deckPlayer)
            {
                if (count!=0)
                {

                    if (showDeck.Count == count)
                    {
                        return showDeck;
                    }

                    showDeck.Add(deck);
                }
                else
                {
                    showDeck.Add(deck);
                }

            }

            return showDeck;
        }
        public Deck ShowDeck(string nameDeck)
        {

            foreach (var deck in _deckPlayer)
            {
                if (nameDeck==deck.DeckName)
                {
                    return deck;
                }

            }

            return null;
        }
        public static void SaveData()
        {
            using (StreamWriter file = File.CreateText(@"E:\path.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, instance);
            }
        }
        public static Player LoadData()
        {
            using (StreamReader file = File.OpenText(@"E:\path.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                JsonReader r = new JsonTextReader(file);
                return (serializer.Deserialize<Player>(r));
            }
            
        }

    }
}
