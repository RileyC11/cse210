using System;

namespace W03_Prove_Hilo_Game.Game
{
    public class Card
    {
        public int valueOne = 0;
        public int valueTwo = 0;
        public int points = 0;
        public Card()
        {
        }

        public void Draw()
        {
            Random random = new Random();
            valueOne = random.Next(1,14);
            valueTwo = random.Next(1,14);
            if (valueTwo == valueOne )
            {
                valueTwo = random.Next(1,14);
 
            }
        }
    }
}