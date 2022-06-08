using W06_Inheritance_Customer_Dealer;

namespace W06_Inheritance_Customer_Dealer
{
    class Program
    {
        static int Main(string[] args)
        {
            Customer John = new Customer("John Smith");
            John.Purchase(50.00);
            John.GetInfo();
            Console.WriteLine(John.Name);

            Dealer Ace = new Dealer("Ace Hardware", 12345678, 0.05);
            Ace.Purchase(60.00);
            Ace.GetInfo();
            Console.WriteLine(Ace.Name);
            Console.WriteLine(Ace.DealerId);
            Console.WriteLine(Ace.Discount);
            
            return 0;
        }
    }

}