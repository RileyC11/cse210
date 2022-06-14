Program for the W05 parachute/hangman game.

Program class simply creates a new instance of Director and calls the "StartGame" method in Director.

Director class creates a new instance of each class within the "Game" folder and runs all of the actual code. "StartGame" has two while loops, one for stopping the
game when the jumper dies or when the user guessed the word. The second, nested while loop is so that the user can input the same letter twice without it penalizing
them and taking away a part of the parachute. "GetInputs" method simply calls the "terminalServices.ReadChar" to read the character input from the user. "DoUpdates"
method creates the secret word, checks to see if the user has already guessed that letter, and then proceeds to either update or not update the parachute. If the user
has already guessed that letter, then the jumper isn't updated and the user is told they have already guessed that letter. If they haven't guessed that letter, then 
the jumper and checker are updated to see if the jumper is still alive or if the user has won. "DoOutputs" method displays the jumper one last time if the user died
and then tells the user that they lost and what the secret word was. If the user won, then it says congrats and displays the secret word.

Guesser class was simply to have a way to keep track of the user's/guesser's inputs. "GetGuess" method returns the guess stored in guesser. "UpdateGuess" method takes
the character input from the user and stores it in guesser.

Jumper class is in charge of creating the jumper and updating the parachute. "CreatePerson" method creates the jumper from a list with strings for each section of the parachute
(top row, second row, third row, last row). "UpdatePerson" method takes a bool parameter "correctGuess" to determine how to update the jumper. If the parachute has the
conditions that the current line is not empty and the next line is "   X   ", then the jumper is dead.

Checker class is used to create the secret word and check the guess. "CheckLists" method takes the user's guess as a parameter and uses the "correctGuesses" and
"incorrectGuesses" lists to see if the user has already guessed that character and returns the bool "alreadyGuessed". "CheckGuess" method takes the user's guess as a 
parameter and compares it to the secret word. The guess is then added to the correct or incorrect list and the "secretLetters" list if it was correct. Then returns
the bool "correctGuess". "CheckAlive" method takes the jumper as a parameter and checks to see if the person contains "   X   ". If so, then the jumper is dead 
and returns the bool "isAlive". "CheckWin" method sees if the "secretLetters" list contains any underscores or empty spaces still and returns the bool "hasWon".
"WriteLetters" writes the characters in the "secretLetters" list.

TerminalServices class is a dumb class used to get user input and right something rather than using Console.WriteLine. "WriteText" takes a string as a parameter and then
displays the text/prompt. "ReadChar" method takes a prompt as a parameter, displays it using "WriteText" method, and then returns the character.


Director is private so that the other classes don't change any of the values stored there. They are only changed withing Director.
