using System;

namespace W06_Inheritance_Customer_Dealer
{
    class Dealer : Customer
    {
        public long DealerId {get; set; }
        public double Discount {get; set; } 
        public Dealer(string name, long dealerId, double discount) : base(name)
        {
            DealerId = dealerId;
            Discount = discount;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"My dealer ID is {DealerId} and my discount is {Discount}.");
        
        }
    }
}