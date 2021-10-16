using System;
using System.Collections.Generic;

namespace TestTaskModel
{
    public class Card 
    {
        public string FrontText { get;private set; }
        public string BackText { get; private set; }
        public bool Learned { get; set; }

        public readonly int NumberInDeck;

        public Card(int number, string frontText, string backText)
        {
            this.NumberInDeck = number;
            this.FrontText = frontText;
            this.BackText = backText;

        }

        public void IsCardLearned() { this.Learned = true; }
        
        public string OpenFrontCard()
        {
            return "My FrontText is " + FrontText.ToString()+"\n";
        }

        public string OpenBackCard()
        {
            return "My FrontText is " + FrontText.ToString() + "\nand my BackText is " + BackText.ToString()+"\n";
        }

    }
}
