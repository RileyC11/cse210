using System;

namespace W03_Prove_Hilo_Game.Game
{
    public class Card
    {
        public int value = 0;
        public Card()
        {
        }

        public void Draw()
        {
            Random random = new Random();
            value = random.Next(1,14);
        }
    }
}