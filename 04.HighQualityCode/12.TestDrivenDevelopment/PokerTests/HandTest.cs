using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void HendToStringTest()
        {
            Hand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            string expected = "[A♠][8♣][10♦][J♥][2♠]";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }                                     
    }                                         
}
