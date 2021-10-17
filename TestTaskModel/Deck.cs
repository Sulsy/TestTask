using System;
using System.Linq;
using System.Collections.Generic;

namespace TestTaskModel
{
    public class Deck 
    {
        public static readonly Dictionary<string, Deck> instances =
            new Dictionary<string, Deck>();

        public readonly List<Card> _deckCard = new List<Card>();
        public string DeckName { get;  set; }
        public Deck(string deckName)
        {
            this.DeckName = deckName;
        }


        public void IsCardLearned(int number)
        {
            var card = _deckCard.Find(x => x.NumberInDeck == number && !x.Learned);
            card.IsCardLearned();
            //NextCard(number);
        }
        public Card NextCard(int number)
        {
            return _deckCard.Find(x => x.NumberInDeck == number + 1 && !x.Learned);
        }
        public void SetCard(Card card)
        {
            if (_deckCard.All(x=>x!=card))
            {
                _deckCard.Add(card);
            }
        }
        public void SetCard(int number,string FrontText,string BackText)
        {
            if (_deckCard.All(x => x.FrontText != FrontText && x.BackText != BackText  && x.NumberInDeck !=number))
            {
                _deckCard.Add(new Card(number,FrontText,BackText));
            }
        }
        public Card GetCard(int number)
        {
            return _deckCard.Find(x => x.NumberInDeck == number);
        }
        public Card GetCard(string frontText)
        {
            return _deckCard.Find(x => x.FrontText == frontText);
        }
        public List<Card> ShowCards(int count = 0)
        {
            var showCards = new List<Card>();

            foreach (var card in _deckCard)
            {
                if (count != 0)
                {

                    if (showCards.Count == count)
                    {
                        return showCards;
                    }

                    showCards.Add(card);
                }
                else
                {
                    showCards.Add(card);
                }

            }

            return showCards;
        }

        public List<Card> ShowRandomCards(HashSet<int> randomHashSet)
        {
            return (
                from card in _deckCard 
                from hashSet in randomHashSet 
                where card.NumberInDeck == hashSet && !card.Learned 
                select card).
                ToList();
        }
        public override string ToString()
        {
            return "Deck name is " + DeckName.ToString();
        }
    }

   

    
}
