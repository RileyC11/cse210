Console.Write("Enter first number: ");
string xStr = Console.ReadLine();
Console.Write("Enter second number: ");
string yStr = Console.ReadLine();
Console.Write("Enter third number: ");
string zStr = Console.ReadLine();

int x = int.Parse(xStr);
int y = int.Parse(yStr);
int z = int.Parse(zStr);

int eqOne = (x + y) * z;
int eqTwo = (x * y) + (y * z);

Console.WriteLine($"Equation One: {eqOne}");
Console.WriteLine($"Equation two: {eqTwo}");