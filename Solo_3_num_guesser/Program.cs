// string input;

// do
// {
//     Random randomGenerator = new Random();
//     int number = randomGenerator.Next(1,101);

//     int guesses = 0;
//     int guess = -1;

//     while (guess != number)
//     {
//         Console.Write("Guess a number between 1 and 100: ");
//         string guessStr = Console.ReadLine();
//         guess = int.Parse(guessStr);
//         guesses += 1;

//         if (guess > number)
//         {
//             Console.WriteLine("Lower");
//         }
//         else if (guess < number)
//         {
//             Console.WriteLine("Higher");
//         }
//         else
//         {
//             Console.WriteLine($"You guessed it! The number is {guess}.");
            
//             if (guesses == 1)
//             {
//                 Console.WriteLine($"It took you {guesses} guess!");
//             }
//             else
//             {
//                 Console.WriteLine($"It took you {guesses} guesses!");
//             }
//         }
//     }

//     Console.Write("Do you want to continue (Y/N): ");
//     input = Console.ReadLine();

// } while (input == "Y");



/////////////////////////////////////////////////////////////////////////////////////////////

string input;

do
{
    Console.Write("What is the magic number: ");
    string magicNumStr = Console.ReadLine();
    int magicNum = int.Parse(magicNumStr);

    int guesses = 0;
    int guess = -1;

    while (guess != magicNum)
    {
        Console.Write("Guess a number between 1 and 100: ");
        string guessStr = Console.ReadLine();
        guess = int.Parse(guessStr);
        guesses += 1;

        if (guess > magicNum)
        {
            Console.WriteLine("Lower");
        }
        else if (guess < magicNum)
        {
            Console.WriteLine("Higher");
        }
        else
        {
            Console.WriteLine($"You guessed it! The number is {guess}.");

            if (guesses == 1)
            {
                Console.WriteLine($"It took you {guesses} guess!");
            }
            else
            {
                Console.WriteLine($"It took you {guesses} guesses!");
            }
        }
    }



    Console.Write("Do you want to continue (Y/N): ");
    input = Console.ReadLine();

} while (input == "Y");



