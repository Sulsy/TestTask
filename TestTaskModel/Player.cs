using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TestTaskModel
{
    /// <summary>
    /// Class Player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Direct for Save
        /// </summary>
        public static readonly string Path = AppDomain.CurrentDomain.BaseDirectory+"\\Save.Json";
        /// <summary>
        /// Static reference for Player
        /// </summary>
        public static Player Instance;
        /// <summary>
        /// Name Player
        /// </summary>
        public string NamePlayer { get; set; }
        /// <summary>
        /// Progress Player
        /// </summary>
        public static int Progress { get;  set; }
        /// <summary>
        ///List Deck
        /// </summary>
        public readonly List<Deck> DeckPlayer = new();
        /// <summary>
        /// Constructor Player
        /// </summary>
        /// <param name="name">Name Player</param>
        public Player(string name) 
        {
            this.NamePlayer = name;
        }
        /// <summary>
        /// Create Deck
        /// </summary>
        /// <param name="deckName">Deck Name</param>
        public void SetDeck(string deckName)
        {
            if (DeckPlayer.All(x =>x.DeckName!=deckName))
            {
                DeckPlayer.Add(new Deck(deckName));
            }
        }
        /// <summary>
        /// Return Selected Deck
        /// </summary>
        /// <param name="deck">Deck for selected</param>
        /// <returns>Deck</returns>
        public Deck GetDeck(string deck)
        {
            return DeckPlayer.Find(x => x.DeckName == deck);
        }
        /// <summary>
        /// Show Deck
        /// </summary>
        /// <param name="count">Count Card Show</param>
        /// <returns>List Deck</returns>
        public List<Deck> ShowDeck(int count=0)
        {
            var showDeck = new List<Deck>();

            foreach (var deck in DeckPlayer)
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
        /// <summary>
        /// Save Player Data
        /// </summary>
        public static void SaveData()
        {
            using var file = File.CreateText(Path);
            var serializer = new JsonSerializer();
            serializer.Serialize(file, Instance);
        }
        /// <summary>
        /// Load Player Data
        /// </summary>
        /// <returns></returns>
        public static Player LoadData()
        {
            using var file = File.OpenText(Path);
            var serializer = new JsonSerializer();
            JsonReader r = new JsonTextReader(file);
            return (serializer.Deserialize<Player>(r));
        }
        /// <summary>
        /// Override To String for Player
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NamePlayer+ " Progress:"+Progress;
        }
    }
}
