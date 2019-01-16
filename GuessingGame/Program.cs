using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello.  Welcome to Joe's Guessing Game!");
            

            //Console.WriteLine(userGuess);

            int maxGuesses = 2;
            int guessCount = 0;
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
                    // the FormatException is thrown when the string text does 
                    // not represent a valid integer.
                }
                catch (OverflowException)
                {
                    // the OverflowException is thrown when the string is a valid integer, 
                    // but is too large for a 32 bit integer.  Use Convert.ToInt64 in
                    // this case.
                }
                switch (userGuessInt)
                {
                    case 0:
                        Console.WriteLine("INSTRUCTIONS: Guess a number from 1 to 10, type it, and then press enter.\n " +
                            "Type -1 to exit.");
                        guessCount--;
                        break;
                    case secretNumber:
                        Console.WriteLine("Good Jorb!  You've Won!\n\n\n");
                        userWon = true;
                        break;
                    case -1: //exit 
                        exitTheApp = true;
                        break;

                    default:
                        if (userGuessInt > secretNumber)
                            Console.WriteLine("Your guess is too HIGH!\n");
                        else
                            Console.WriteLine("Your guess is too LOW!\n");
                        break;

                }


            } while ((guessCount < maxGuesses) && (!userWon) && (!exitTheApp)); //This loop control is getting convoluted

            
        }
    }
}
