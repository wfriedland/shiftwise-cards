using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shiftwise_cards;

namespace shiftwise_card_tests
{
    [TestClass]
    public class sortTests
    {
        Random r;
        public sortTests()
        {
            r = new Random(DateTime.Now.Second);
        }

        [TestMethod]
        public void sortTest1()
        {
            // Allocate a deck of cards
            cardDeck d = new cardDeck();

            // The deck of cards is sorted by default. 
            // Shuffle the cards manually
            card c = new card();
            for (int i = 0; i < 51; i++)
            {
                int idx = (i + r.Next()) % 52;
                c = d.deck[idx];
                d.deck[idx] = d.deck[i];
                d.deck[i] = c;
            }

            // Sort the cards
            d.sort();

            // Use the validate method to see if all of the cards are in place
            Assert.IsTrue(d.validateDeck());
        }

        [TestMethod]
        public void sortTest2()
        {
            // Allocate a deck of cards
            cardDeck d = new cardDeck();
            card c = new card();
            // Shuffle the cards manually
            for (int i = 0; i < 51; i++)
            {
                int idx = (r.Next()) % 52;
                if (i == idx) idx = (r.Next()) % 52;
                c = d.deck[idx];
                d.deck[idx] = d.deck[i];
                d.deck[i] = c;
            }

            // sort 
            d.sort();

            // Validate the cards manually
            int errorCnt = 0;
            for (int j = 0; j < 51; j++)
            {
                if (j != d.deck[j].sortOrder()) errorCnt++;
            }
            Assert.IsTrue(errorCnt == 0);
        }

        [TestMethod]
        public void sortTest3()
        {
            int idx;

            // Allocate 5 deck of cards
            cardDeck d1 = new cardDeck();
            cardDeck d2 = new cardDeck();
            cardDeck d3 = new cardDeck();
            cardDeck d4 = new cardDeck();
            cardDeck d5 = new cardDeck();
            card c = new card();

            // Shuffle the cards manually
            for (int i = 0; i < 51; i++)
            {
                // Each deck gets shuffled with different values
                idx = (r.Next()) % 52;
                if (i == idx) idx = (r.Next()) % 52;
                c = d1.deck[idx];
                d1.deck[idx] = d1.deck[i];
                d1.deck[i] = c;

                // Each deck gets shuffled with different values
                idx = (r.Next()) % 52;
                if (i == idx) idx = (r.Next()) % 52;
                c = d2.deck[idx];
                d2.deck[idx] = d2.deck[i];
                d2.deck[i] = c;

                // Each deck gets shuffled with different values
                idx = (r.Next()) % 52;
                if (i == idx) idx = (r.Next()) % 52;
                c = d3.deck[idx];
                d3.deck[idx] = d3.deck[i];
                d3.deck[i] = c;

                // Each deck gets shuffled with different values
                idx = (r.Next()) % 52;
                if (i == idx) idx = (r.Next()) % 52;
                c = d4.deck[idx];
                d4.deck[idx] = d4.deck[i];
                d4.deck[i] = c;

                // Each deck gets shuffled with different values
                idx = (r.Next()) % 52;
                if (i == idx) idx = (r.Next()) % 52;
                c = d5.deck[idx];
                d5.deck[idx] = d5.deck[i];
                d5.deck[i] = c;

            }

            // sort 
            d1.sort();
            d2.sort();
            d3.sort();
            d4.sort();
            d5.sort();

            // Validate the cards manually
            int [] errorCnt = { 0, 0, 0, 0, 0 };
            for (int j = 0; j < 51; j++)
            {
                if (j != d1.deck[j].sortOrder()) errorCnt[0]++;
                if (j != d2.deck[j].sortOrder()) errorCnt[1]++;
                if (j != d3.deck[j].sortOrder()) errorCnt[2]++;
                if (j != d4.deck[j].sortOrder()) errorCnt[3]++;
                if (j != d5.deck[j].sortOrder()) errorCnt[4]++;
            }
            Assert.IsTrue(errorCnt[0] == 0
                       && errorCnt[1] == 0
                       && errorCnt[2] == 0
                       && errorCnt[3] == 0
                       && errorCnt[4] == 0);
        }
    }
}
