

    public class Board
    {
        public List<Quote> quotes = new List<Qutoes>;


        public void NicePrint(string item)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"{item}");
            Console.WriteLine("-------------------------------------------------------");
        }
        public void ShowQuotes()
        {
            foreach (Quote quote in quotes)
            {
                NicePrint(quote.GetQuote());
            }
        }

        public void AddQuote(Quote quote)
        {
            quotes.Add(quote);
        }

        public void GetRandomQuote()
        {
            var random = new Random();
            var randNum = random.Next(0, quotes.Count);


        }

        public void StartBoard()
        {
            string response = "";
            string[] options = {"A", "S", "Q", "P", "R"};

            while (response != "Q")
            {
                while (options.Contains(response)==false)
                {
                    
                }
            }
        }
    }