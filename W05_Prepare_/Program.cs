Console.WriteLine();
VendingMachine v = new VendingMachine();
v.Populate();
v.getList();
Console.WriteLine();

public class Item
{
    // these are accessible when calling the item.name and item.price in VendingMachine
    // public string name = "";
    // public double price;

    private string name;
    private double price;
    private string location;
    private int quantity;

    public Item(string name, double price, string location, int quantity=1)
    {
        this.name = name;
        this.price = price;
        this.location = location;
        this.quantity = quantity;
    }

    private double totalValue()
    {
        return quantity * price;
    }

    public void showItem()
    {
        Console.WriteLine($"{name}---${price:0.00}---{location}---{quantity}---${totalValue():0.00}");
    }
}

public class VendingMachine
{
    // private makes the items list unaccessible outside of the VendingMachine class.
    private List<Item> items = new List<Item>();

    public VendingMachine()
    {
        Console.WriteLine("I'm a vending machine.");
    }

    public void Populate()
    {
        items.Add(new Item("Doritos", 2.50, "A1", 2));
        items.Add(new Item("Gatorade", 1.25, "A2"));
        items.Add(new Item("Reese's", 0.75, "A3", 6));
    }

    // getter?? This works but multiple uses makes private useless.
    // public List<Item> getList()
    // {
    //     return items;
    // }

    public void getList()
    {
        Console.WriteLine("Items in the vending machine");
        foreach (Item item in items)
        {
            // Console.WriteLine($"{item}");
            // Console.WriteLine($"{item.name}_____${item.price}");
            item.showItem();
        }
    }
}