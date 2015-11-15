using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
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
            for (int j = 51; j >= 0; j--)
            {
                // Test to see if each card is in its original order in the deck
                if (j == d.deck[j].sortOrder()) errorCnt++;
            }

            // It might be possible for one or two cards to be in its original order
            // Three such insidents will be flagged as a failure
            Assert.IsTrue(errorCnt < 3);
        }
        [TestMethod]
        public void shuffleTest3()
        {
            // Allocate 5 deck of cards
            cardDeck d1 = new cardDeck();
            cardDeck d2 = new cardDeck();
            cardDeck d3 = new cardDeck();
            cardDeck d4 = new cardDeck();
            cardDeck d5 = new cardDeck();

            // Shuffle
            d1.shuffle();
            d2.shuffle();
            d3.shuffle();
            d4.shuffle();
            d5.shuffle();

            // Test to see if all card decks have been shuffled
            int[] errorCnt = { 0, 0, 0, 0, 0 };
            for (int j = 0; j < 52; j++)
            {
                // Test to see if each card is in its original order in the deck
                if (j == d1.deck[j].sortOrder()) errorCnt[0]++;
                if (j == d2.deck[j].sortOrder()) errorCnt[1]++;
                if (j == d3.deck[j].sortOrder()) errorCnt[2]++;
                if (j == d4.deck[j].sortOrder()) errorCnt[3]++;
                if (j == d5.deck[j].sortOrder()) errorCnt[4]++;
            }

            // It might be possible for one or two cards to be in its original order
            // Three such insidents will be flagged as a failure
            Assert.IsTrue(errorCnt[0] < 3
                       && errorCnt[1] < 3
                       && errorCnt[2] < 3
                       && errorCnt[3] < 3
                       && errorCnt[4] < 3);
        }

    }
}
