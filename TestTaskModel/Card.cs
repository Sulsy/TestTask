using System;
using System.Collections.Generic;

namespace TestTaskModel
{
    public class Card 
    {
        /// <summary>
        /// Front Text
        /// </summary>
        public string FrontText { get;private set; }
        /// <summary>
        /// Back Text
        /// </summary>
        public string BackText { get; private set; }
        /// <summary>
        /// Is Card Learned?
        /// </summary>
        public bool Learned { get; set; }
        /// <summary>
        /// Is Card Open?
        /// </summary>
        public bool OpenBackText { get; set; }
        /// <summary>
        /// Number on Deck
        /// </summary>
        public int NumberInDeck;
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="number">Number on Deck</param>
        /// <param name="frontText">Front Text</param>
        /// <param name="backText">Back Text</param>
        public Card(int number, string frontText, string backText)
        {
            this.NumberInDeck = number;
            this.FrontText = frontText;
            this.BackText = backText;
        }
        /// <summary>
        /// Marks the card as Learned
        /// </summary>
        public void IsCardLearned() { this.Learned = true; Player.Progress++;}
        /// <summary>
        /// Marks the card as Open
        /// </summary>
        public void IsCardOpen() { this.OpenBackText = true; }
        /// <summary>
        /// Marks the card as Close
        /// </summary>
        public void IsCardClose() { this.OpenBackText = false; }
        /// <summary>
        /// Show Front text Card
        /// </summary>
        /// <returns>Front text</returns>
        public string OpenFrontCard()
        {
            return "My FrontText is " + FrontText.ToString()+"\n";
        }
        /// <summary>
        /// Show Front and Back text Card
        /// </summary>
        /// <returns>Front and Back text</returns>
        public string OpenBackCard()
        {
            return "My FrontText is " + FrontText.ToString() + "\nand my BackText is " + BackText.ToString()+"\n";
        }

    }
}
