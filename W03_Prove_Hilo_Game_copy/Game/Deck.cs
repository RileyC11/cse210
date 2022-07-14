using System;
using System.Collections.Generic;

namespace W03_Prove_Hilo_Game_copy.Game
{
    public class Deck
    {
        public List<int> cards = new List<int>();
        
        public Deck(int numDecksMake)
        {
            Draw(numDecksMake);
        }

        public void Draw(int numDecksMake)
        {
            for (int i = 0; i < numDecksMake; i++)
            {
                Random random = new Random();
                int value = random.Next(1,14);
                cards.Add(value);

            }
        }

        public List<int> GetDeck()
        {
            return cards;
        }

        public int DeckTwo()
        {
            int cardTwo = cards.Last<int>();
            return cardTwo;
        }

        public int DeckOne()
        {
            // int cardOneIndex = cardList.Count();
            // int cardOne = cardList[cardOneIndex];
            // return cardOne;

            int cardTwo = cards.Last<int>();
            return cardTwo;
        }
    }
}