Console.Write("\nWhat is your grade percentage? ");
string gradeStr = Console.ReadLine();
int gradeInt = int.Parse(gradeStr);
float remainder = gradeInt % 10;
string letter = "";
string sign = "";

//////////////////////////////////////////////////////////////////////////

if (gradeInt >= 90)
{
    letter = "A";
}
else if (gradeInt < 90 && gradeInt >= 80)
{
    letter = "B";
}
else if (gradeInt < 80 && gradeInt >= 70)
{
    letter = "C";
}
else if (gradeInt < 70 && gradeInt >= 60)
{
    letter = "D";
}
else
{
    letter = "F";
}

//////////////////////////////////////////////////////////////////////////

if (remainder >= 7)
{
    sign = "+";
}
else if (remainder < 3)
{
    sign = "-";
}
else
{
    sign = "";
}

//////////////////////////////////////////////////////////////////////////

if (gradeInt >= 93)
{
    sign = "";
}

if (letter == "F")
{
    sign = "";
}

//////////////////////////////////////////////////////////////////////////

Console.WriteLine($"Your letter grade is {letter}{sign}");

//////////////////////////////////////////////////////////////////////////

if (gradeInt >= 70)
{
    Console.WriteLine("Congratulations, you passed the class!\n");
}
else
{
    Console.WriteLine("Sorry, you did not pass the class :(\n");
}