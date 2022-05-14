In my program, I used classes and objects. I created three classes for this program called Card, Director, and Program. The only purpose of the Card class was to create a new card and store the value of that one card. In the Card class, I created a new Random object for creating my card value. In the Director class, I created a constructor for Director and created a new Card object within it to create two new cards and store them in a list. The Program class was used to create a new Director object to start the game. These were the ways that I was able to implement classes and objects in my program.

The Card class is responsible for creating one new card. It then stores that card as "value" in case I want to call it later in the Director class.

The Director class has a lot of responsibilities. I defined any variables that I wanted global or that needed a predefined value such as the starting score (totalScore), whether the player has guessed yet (guess), or if the player still wants to play (isPlaying). All of those make it possible to start each game the same. Then I create a constructor of Director by creating a Card object to create two new cards. The for loop is what makes two cards, not the Card object. The Director class contains multiple methods, some of which are almost unnecessary. 

The first method is StartGame which runs all of the following methods.

The next method is MakeCards which makes two new cards calling the Draw method from the Card class. Then I store the value of each card into global variables so that I can use them in later methods.

The next method is DisplayCard which displays a specific card. This is used to display the first card if the user hasn't guessed higher or lower. It then displays the second card once they have guessed.

The next method is GetGuess which displays to the user to guess higher or lower and stores their guess as "guess".

The next method is DoUpdates which updates the players total score based upon their guess, adds one to the number of times they've played, and checks to see if their score is still greater than zero. 

The next method is DisplayScore which shows the players current score. I feel that this could be added into another method but keeping as its own made it easier for me to follow and understand.

The next method is PlayAgain which asks if the user wants to play again. If the user decides not to play again, then it displays how many times they played. If the user decides to play again, then it updates their choice and resets "guess" to "" so that DisplayCard works properly.

The Program class creates a new Director object then calls the StartGame method. 
