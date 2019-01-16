using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello.  Welcome to Joe's Guessing Game!");
            

            //Console.WriteLine(userGuess);

            int maxGuesses = 3;
            int guessCount = 0;
            int min = 0;
            int max = 10;
            bool userWon = false;
            bool exitTheApp = false;
            String userGuess = null;
            int userGuessInt = 0;

            //Generate Random Number between 1 and 10
            Random rnd = new Random();
            int secretNumber = rnd.Next(1, 11);
            

            do
            {
                Console.WriteLine("\n\n   GUESSES REMAINING = "+ (maxGuesses - guessCount));
                Console.WriteLine("Type your guess (a number) and press enter: ");
                userGuess = Console.ReadLine();
                guessCount++;

                try
                {
                    userGuessInt = System.Convert.ToInt32(userGuess);
                }
                catch (FormatException)
                {
                    userGuessInt = -2; //if it's not a valid integer, then make it -2 so program knows
                }
                catch (OverflowException)
                {
                    userGuessInt = -2; //if it's not a valid integer, then make it -2 so program knows
                }
                switch (userGuessInt)
                {
                    case 0:
                        Console.WriteLine("INSTRUCTIONS: Guess a number from 1 to 10, type it, and then press enter.\n " +
                            "Type -1 to exit.");
                        guessCount--;
                        break;
                    /*case secretNumber:
                        Console.WriteLine("Good Jorb!  You've Won!\n\n\n");
                        userWon = true;
                        break;*/
                    case -1: //exit 
                        guessCount--;
                        exitTheApp = true;
                        break;

                    default:
                        if ((userGuessInt < min) || (userGuessInt > max))
                            Console.WriteLine("Choose a number between 1 and 10!\n\n\n");
                        else if (userGuessInt > secretNumber)
                            Console.WriteLine("Your guess is too HIGH!\n");
                        else if (userGuessInt < secretNumber)
                            Console.WriteLine("Your guess is too LOW!\n");
                        else
                        {
                            Console.WriteLine("Good Jorb!  You've Won!\n\n\n");
                            userWon = true;
                        }
                        
                        break;

                }


            } while ((guessCount < maxGuesses) && (!userWon) && (!exitTheApp)); //This loop control is getting convoluted
            if ((guessCount >= maxGuesses) && (!userWon))
                Console.WriteLine("Dang! You Lost, Mang!\n");
            Console.WriteLine("Bye-bye.  The secret number was: " + secretNumber + "\n\n\n");
            

        }
    }
}
