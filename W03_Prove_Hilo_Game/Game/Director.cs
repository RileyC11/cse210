using System;

namespace W03_Prove_Hilo_Game.Game
{
    public class Director
    {
        List<Card> cards = new List<Card>();
        bool isPlaying = true;
        int score = 0;
        int totalScore = 300;

        public Director()
        {

        }

        public void StartGame()
        {
            while (isPlaying)
            {
                DisplayCard();
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        public void DisplayCard()
        {
            if (!isPlaying)
            {
                return;
            }

            
        }
    }
}