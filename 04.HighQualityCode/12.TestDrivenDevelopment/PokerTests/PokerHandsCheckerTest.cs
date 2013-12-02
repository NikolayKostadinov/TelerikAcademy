using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void IsHighCardTest()
        {
            Hand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            PokerHandsChecker checker = new PokerHandsChecker();
            bool actual = checker.IsHighCard(hand);
            bool expected = true; 
            Assert.AreEqual(expected, actual);
        }
    }
}
