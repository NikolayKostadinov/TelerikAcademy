using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardToStringAceOfSpadesTest()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTenOfHeartsTest()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Hearts);
            string expected = "10♥";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
                        
        [TestMethod]
        public void CardToStringNineOfDiamondTest()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Diamonds);
            string expected = "9♦";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CardToStringTwoOfClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "2♣";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

    }
}
