using System;
using System.Collections.Generic;

namespace W03_Prove_Hilo_Game.Game
{
    public class Card
    {
        public List<int> cardList = new List<int>();
        public Card()
        {
        }

        public void Draw()
        {
            Random random = new Random();
            int value = random.Next(1,14);
            cardList.Add(value);
        }

        public List<int> GetCards()
        {
            return cardList;
        }

        public int CardTwo()
        {
            int cardTwo = cardList.Last<int>();
            return cardTwo;
        }

        public int CardOne()
        {
            int cardOneIndex = cardList.Count() - 2;
            int cardOne = cardList[cardOneIndex];
            return cardOne;
        }
    }
}