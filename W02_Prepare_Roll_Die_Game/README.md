**Program.cs**

The Program file contains the Program class and Main function to start the program. The Main function calls the Director class and creates a new instance of Director as a variable called "director", which is then used to execute the StartGame method in the Director class.

**Director.cs**

The Director file contains the Director class and will control/direct the sequence of play. We begin by creating a new list called "dice" using the Die class from the Die file. We give the class attributes such as "isPlaying", "score", and "totalScore". Then we create a new instance of Director by calling the Director class and then the Die class to roll the die five times and add those valyes to our "dice" list. Then we start the game by running the StartGame method, which uses the attribute of "isPlaying" to start the while loop. Then the GetInputs, DoUpdates, and DoOutputs methods. GetInputs is asking the user if they want to roll again, changing our "isPlaying" to false if they say no. This causes us to exit the while loop. If they roll, then DoUpdates sets the starting score to 0, calls the Roll method from the Die class, adds up the points using the Die class, and changes the "totalScore" of the Director class. DoOutputs creates a new string called "values" that will contain the values of the "dice" list by using the "value" variable from the Die class. Then the console displays "values" and "totalScore". At the start of each method, the program is checking to see if "isPlaying" is true.

**Die.cs**

The Die file contains the Die class and rolls the die. An instance of the Random class is created as "random", which allows us to generate a random die number. The number is stored as "value". The points associated with that value are determined by an if/else if statement and stored as "points". Both "value" and "points" are accessed within the Director file.
