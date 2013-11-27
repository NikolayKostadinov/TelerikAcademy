using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string faseString = GetStringFace();
            string suitString = GetSuitString();
            string cardString = faseString + suitString;
            return cardString;
        }

        private string GetStringFace()
        {
            if ((int)this.Face > 10)
            {
                return this.Face.ToString()[0].ToString();
            }
            else
            {
                return ((int)this.Face).ToString();
            }
        }
        
        private string GetSuitString()
        {
            char suit;

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    suit = '♣';
                    break;
                case CardSuit.Diamonds:
                    suit = '♦';
                    break;
                case CardSuit.Hearts:
                    suit = '♥';
                    break;
                case CardSuit.Spades:
                    suit = '♠';
                    break;
                default:
                    throw new InvalidOperationException("No such suit! " + this.Suit.ToString());
            }

            return suit.ToString();
        }
    }
}