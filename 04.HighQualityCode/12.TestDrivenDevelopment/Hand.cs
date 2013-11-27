using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder handString = new StringBuilder(20);

            foreach (Card card in this.Cards)
            {
                handString.Append("[");
                handString.Append(card.ToString());
                handString.Append("]");
            }

            return handString.ToString();
        }
    }
}
