using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shiftwise_cards;

namespace shiftwise_card_tests
{
    [TestClass]
    public class sortTests
    {
        [TestMethod]
        public void sortTest1()
        {
            // Allocate a deck of cards
            cardDeck deck = new cardDeck();

            // The deck of cards is sorted by default. 
            // To test this feature we will use the shuffle method
            deck.shuffle();

            // Sort the cards
            deck.sort();

            // Use the validate method to see if all of the cards are in place
            Assert.IsTrue(deck.validateDeck());
        }

        [TestMethod]
        public void sortTest2()
        {
            // Allocate a deck of cards
            Random r = new Random(DateTime.Now.Second);
            cardDeck d = new cardDeck();

            // Shuffle the cards manually
            for (int i = 0; i < 51; i++)
            {
                int idx = (i + r.Next(0, 51)) % 52;
                card c = new card();
                c = d.deck[i];
                d.deck[i] = d.deck[idx];
                d.deck[idx] = c;
            }

            // sort 
            d.sort();

            // Validate the cards manually
            int errorCnt = 0;
            for (int j = 0; j < 51; j++)
            {
                int cardValue = ((int)d.deck[j].cardSuit * 13) + (int)d.deck[j].cardValue;
                if (cardValue != j) errorCnt++;
            }
            Assert.IsTrue(errorCnt == 0);
        }
    }
}
