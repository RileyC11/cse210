using System;

// namespace W05_Prove_Jumper_Game.Game
// {
    public class Director
    {
        private TerminalServices terminalServices = new TerminalServices();
        private Guesser guesser = new Guesser();
        private Jumper jumper = new Jumper();
        private bool isAlive = true;
        
        public Director()
        {
        }

        public void StartGame()
        {
            // GetInputs();
            // DoUpdates();
            // DoOutputs();
            jumper.CreatePerson();
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
// }