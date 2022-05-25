using System;

namespace W06_RPS_game
{
    class Rules
    {
        public string p1_choice = "";
        public string p2_choice = "";
        public string winner = "";
        public Rules()
        {}
        public string whoWins(p1_choice, p2_choice)
        {
            if (p1_choice == p2_choice)
            {
                return winner = "";
            }
            else if (p1_choice == "r" && p1_choice == "s" || p1_choice == "s" && p1_choice == "p" || p1_choice == "p" && p1_choice == "r")
            {
                return winner = p1_choice;
            }
            else
            {
                return winner = p2_choice;
            }
        }
    }
}