using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiftwise_cards
{
    // The order of the card suits is determined by alphabetical order
    public enum suits { clubs = 0, diamonds, hearts, spades };

    // The order of cards within a suit
    public enum cardRank { two = 0, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace };

    /*
     * Standard playing card. One of 52 in a standard deck of cards
     */
    public class card
    {
        public suits cardSuit { get; }
        public cardRank cardValue { get; }

        public card() { }
        public card(suits s, cardRank v)
        {
            cardSuit = s;
            cardValue = v;
        }
    }

    /*
     * Stadard deck of cards. Four suits with 13 cards each
     */
    public class cardDeck
    {
        public card[] deck { get; set; }
        public cardDeck()
        {
            deck = new card[52];
            int i = 0;
            for (suits s = suits.clubs; s <= suits.spades; s++)
            {
                for (cardRank v = cardRank.two; v <= cardRank.ace; v++)
                {
                    deck[i++] = new card(s, v);
                }
            }
        }

        /* 
         * sort() method. The deck of cards will be sorted in ascending order
         */
        public void sort()
        {
            var sort =
                from d in deck
                orderby d.cardSuit, d.cardValue
                select d;

            deck = sort.ToArray();
        }

        /*
         * shuffle() method. The deck of card will be arranged in random order
         */
        public void shuffle()
        {
            var r = new Random(DateTime.Now.Second);
            var shuffled = from d in deck
                           let rand = r.Next()
                           orderby rand
                           select d;
            deck = shuffled.ToArray();
        }


        /* 
         * The validateDeck() method performs a test to see that deck of cards have
         * every card it should. It does this by ensuring the count of suite/value of each card
         * totals to the correct sum.
         */
        public bool validateDeck()
        {
            int checksum = 0;
            int sumOf51 = 0;
            for (int i = 0; i < 52; i++)
            {
                checksum += ((int)deck[i].cardSuit * 13) + (int)deck[i].cardValue;
                sumOf51 += i;
            }
            if (checksum != sumOf51)
            {
                Console.WriteLine("Trouble in paradice, a card was misplaced somehow");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
