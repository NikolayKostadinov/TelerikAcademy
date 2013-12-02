using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            bool moreThanTwoFomTheSameSuit = CheckAllEqualSuits(hand);
            bool moreThanOneFromTheSameFace = CheckFaceForDublication(hand);
            return !moreThanOneFromTheSameFace && !moreThanTwoFomTheSameSuit;
        }

        private bool CheckAllEqualSuits(IHand hand)
        {
            bool allEqualSuits = true;
            ICard previouseCard = hand.Cards[0];
            int lastIndex = hand.Cards.Count;
            for (int index = 1; index < lastIndex; index++)
            {
                if (previouseCard.Suit != hand.Cards[index].Suit)
                {
                    allEqualSuits = false;
                    break;
                }
            }

            return allEqualSuits;
        }

        private bool CheckFaceForDublication(IHand hand)
        {
            bool isThereDublicatedFaces = false;
            int[] countFaces = new int[(int)CardFace.Ace + 1];
            int lastIndex = hand.Cards.Count;

            for (int index = 0; index < lastIndex; index++)
            {
                countFaces[(int)hand.Cards[index].Face]++;
            }

            foreach (var counter in countFaces)
            {
                if (counter > 1)
                {
                    isThereDublicatedFaces = true;
                    break;
                }
            }
            return isThereDublicatedFaces;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
