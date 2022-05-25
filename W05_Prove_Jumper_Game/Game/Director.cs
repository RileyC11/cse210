using System;
using System.Collections.Generic;

namespace W05_Prove_Jumper_Game.Game
{
    public class Director
    {
        private WordGenerator word = new WordGenerator();
        private bool isAlive = true;
        private Guesser guess = new Guesser();
        private TerminalServices terminalServices = new TerminalServices();
        public Director()
        {
        }

        public void StartGame()
        {
            GetInputs();
            DoUpdates();
            DoOutputs();
        }

        private void GetInputs()
        {

        }

        private void DoUpdates()
        {

        }

        private void DoOutputs()
        {

        }
    }
}