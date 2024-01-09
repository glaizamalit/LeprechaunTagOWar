const int MinStartingPosition = 20,
          CharLengthOfRope = 10,
          MaxNumberOfRound = 10;

string leprechaun1,
       leprechaun2,
       displayMessage;

int startingPosition,
    originalStartingPosition,
    tagPosition,
    totalWinOfLeprechaun1 = 0,
    totalWinOfLeprechaun2 = 0,
    countOfDraw = 0,
    pointsDifference,
    leprechaun1PlayerPoint,
    leprechaun2PlayerPoint;

char toPlayAgain;

// Prompt to enter string for leprechaun1
Console.Write("Please enter the string for leprechaun 1(must be 3 characters): ");
leprechaun1 = Console.ReadLine();
while (leprechaun1.Length != 3)
{
    Console.Write("Invalid entry! Please enter the string for leprechaun 1(MUST BE 3 CHARACTERS!): ");
    leprechaun1 = Console.ReadLine();
}

// Prompt to enter string for leprechaun2
do
{
    Console.Write("Please enter the string for leprechaun 2(must be 3 characters): ");
    leprechaun2 = Console.ReadLine();

    if (leprechaun2 == leprechaun1)
    {
        Console.WriteLine("String for Leprechaun 2 is the same as Leprechaun 1!");
    }

    if (leprechaun2.Length != 3)
    {
        Console.WriteLine("Invalid entry! Please enter the string for leprechaun 2(MUST BE 3 CHARACTERS!): ");
    }

} while (leprechaun1 == leprechaun2 || leprechaun2.Length != 3);

// Prompt to enter starting position for the rounds
Console.Write("What is the starting position for the rounds? ");
while (!int.TryParse(Console.ReadLine(), out startingPosition) || startingPosition < MinStartingPosition)
{
    Console.Write($"Invalid entry! Please enter starting position atleast {MinStartingPosition}: ");
}

startingPosition = startingPosition - CharLengthOfRope;

tagPosition = startingPosition + (CharLengthOfRope / 2) + 1;
originalStartingPosition = startingPosition;

do
{
    // Reset the screen and the variables
    Console.Clear();
    leprechaun1PlayerPoint = 0;
    leprechaun2PlayerPoint = 0;
    displayMessage = "";
    startingPosition = originalStartingPosition;

    // Loop until there is a winner 
    for (int i = 0; i <= MaxNumberOfRound; i++)
    {
        Console.Clear();

        if (leprechaun1PlayerPoint != 0 || leprechaun2PlayerPoint != 0)
        {
            Console.WriteLine($"{displayMessage}");
        }

        Console.WriteLine($"Player 1: {leprechaun1}");
        Console.WriteLine($"Player 2: {leprechaun2}\n\n\n");
        Console.WriteLine($"{"||".PadLeft(tagPosition)}");
        Console.WriteLine($"{leprechaun1.PadLeft(startingPosition)}{new String('~', CharLengthOfRope)}{leprechaun2}");
        Console.WriteLine($"{"||".PadLeft(tagPosition)}");

        if ((tagPosition) <= (startingPosition + 1))
        {
            Console.WriteLine($"\nleprechaun 2 ({leprechaun2}) WINNER!\n");
            totalWinOfLeprechaun2++;
            break;
        }

        if ((tagPosition) >= (startingPosition + (CharLengthOfRope + 1)))
        {
            Console.WriteLine($"\nleprechaun 1 ({leprechaun1}) WINNER!\n");
            totalWinOfLeprechaun1++;
            break;
        }

        // If maximum number of round reaches, then display message that it is a draw.
        if (i == MaxNumberOfRound)
        {
            Console.WriteLine("\n\n10 rounds have been  completed  and the Leprechauns are tired! It is a draw!\n\n");
            countOfDraw++;
        }
        else
        {
            // Prompt to press enter to generate random number and determine the winner.
            Console.WriteLine("\n\nPress enter to pull!");
            Console.ReadLine();
            Random randomNumber = new Random();
            leprechaun1PlayerPoint = randomNumber.Next(1, 5);
            leprechaun2PlayerPoint = randomNumber.Next(1, 5);

            // Get the points difference between the two players
            pointsDifference = Math.Abs(leprechaun1PlayerPoint - leprechaun2PlayerPoint);

            // Move the starting point of the rope based on which side is the winner
            if (leprechaun1PlayerPoint > leprechaun2PlayerPoint)
            {
                startingPosition = startingPosition - pointsDifference;
                displayMessage = "leprechaun 1 pulled with " + pointsDifference + " power\n";
            }
            else if (leprechaun2PlayerPoint > leprechaun1PlayerPoint)
            {
                startingPosition = startingPosition + pointsDifference;
                displayMessage = "leprechaun 2 pulled with " + pointsDifference + " power\n";
            }
            else
            {
                displayMessage = "Both leprechauns pulled with the same strength!\n";
            }
        }
    }

    // Prompt to play again
    Console.Write("Would you like to play again?(Y/N) ");
    while (!char.TryParse(Console.ReadLine(), out toPlayAgain))
    {
        Console.Write("Invalid input! Would you like to play again?(Y/N) ");
    }

    if (char.ToUpper(toPlayAgain) != 'Y')
    {
        // Prompt the messsage and summary if the user will not play again.
        Console.WriteLine("\nThank you for playing the Leprechaun Tug O' War!\n");
        Console.WriteLine($"Leprechaun 1 wins: {totalWinOfLeprechaun1} ");
        Console.WriteLine($"Leprechaun 2 wins: {totalWinOfLeprechaun2} ");
        Console.WriteLine($"Draws: {countOfDraw} ");
    }

} while (char.ToUpper(toPlayAgain) == 'Y');