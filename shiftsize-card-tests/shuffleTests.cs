using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shiftwise_cards;

namespace shiftsize_card_tests
{
    [TestClass]
    public class shuffleTests
    {
        [TestMethod]
        public void shuffleTest1()
        {
            // Allocate a deck of cards
            cardDeck deck = new cardDeck();
            
            // Shuffle
            deck.shuffle();

            // Use the validate method to see if all of the cards are in place
            Assert.IsTrue(deck.validateDeck());
        }

        [TestMethod]
        public void shuffleTest2()
        {
            // Allocate a deck of cards
            cardDeck d = new cardDeck();

            // Shuffle
            d.shuffle();

            // Validate the shuffling of the deck manually
            int errorCnt = 0;
            for (int j = 0; j < 52; j++)
            {
                int cardValue = ((int)d.deck[j].cardSuit * 13) + (int)d.deck[j].cardValue;
                if (cardValue == j) errorCnt++;
            }

            // It might be possible for one card to be in its original order
            // Two such insidents will be flagged as a failure
            Assert.IsTrue(errorCnt < 2);
        }

    }
}
