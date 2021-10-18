using System;
using System.Linq;
using System.Collections.Generic;

namespace TestTaskModel
{
    public class Deck 
    {
        /// <summary>
        /// List Card
        /// </summary>
        public readonly List<Card> DeckCard = new();
        /// <summary>
        /// Deck name
        /// </summary>
        public string DeckName { get;  set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deckName">Deck name</param>
        public Deck(string deckName)
        {
            this.DeckName = deckName;
        }
        /// <summary>
        /// Marks the card as Learned
        /// </summary>
        /// <param name="number">Number Card</param>
        public void IsCardLearned(int number)
        {
            var card = DeckCard.Find(x => x.NumberInDeck == number && !x.Learned);
            card?.IsCardLearned();
        }
        /// <summary>
        /// Create Card FOr Deck
        /// </summary>
        /// <param name="number">Number Card</param>
        /// <param name="frontText">Front Text Card</param>
        /// <param name="backText">Back Text Card</param>
        public void SetCard(int number,string frontText,string backText)
        {
            if (DeckCard.All(x => x.FrontText != frontText && x.BackText != backText  && x.NumberInDeck !=number))
            {
                DeckCard.Add(new Card(number,frontText,backText));
            }
        }
        /// <summary>
        /// Override To String For Deck
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Deck name is " + DeckName.ToString();
        }
    }

   

    
}
