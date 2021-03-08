using System;
using System.Text;
using System.Linq;

namespace ConsoleAppCharArray
{
    public class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            RunHangman();
        }

        static void RunHangman()
        {
            // init start
            string secretWord = RandomPickWord();

            StringBuilder incorrectLetter = new StringBuilder();

            char[] correctLetters = new char[secretWord.Length];

            Array.Fill(correctLetters, '_');

            int guessCounter = 10;

            //init end

            Console.WriteLine("Dev debug print of secret word: " + secretWord);

            while (guessCounter > 0 && correctLetters.Contains('_'))
            {
                HangmanStatus(guessCounter, correctLetters, incorrectLetter);

                Console.Write("Type in your guess: ");
                string userInput = Console.ReadLine();

                if (userInput.Length > 1)
                {
                    //user guessed on the word
                }
                else// just a letter
                {
                    guessCounter = guessCounter + UserGuessLetter(userInput[0], secretWord, correctLetters, incorrectLetter);
                }

            }

            if (guessCounter > 0 && !correctLetters.Contains('_'))
            {
                Console.WriteLine("Winner!!!");
            }
            else
            {
                Console.WriteLine("Lost");
            }
            
        }

        /// <summary>
        /// • The incorrect letters the player has guessed, 
        ///    should be put inside a StringBuilder and presented to the player after each guess.
        /// • The correct letters should be put inside a char array. 
        ///     Unrevealed letters need to be represented by a lower dash ( _ ).
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="secretWord"></param>
        /// <param name="correctLetters"></param>
        /// <param name="incorrectLetter"></param>
        /// <returns></returns>
        public static int UserGuessLetter(char guess, string secretWord, char[] correctLetters, StringBuilder incorrectLetter)
        {
            if (correctLetters.Contains(guess) || incorrectLetter.ToString().Contains(guess))
            {
                return 0;// reduse guesses by 0
            }
            else
            {
                if (secretWord.Contains(guess))
                {
                    //correct letter

                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (guess == secretWord[i])
                        {
                            correctLetters[i] = secretWord[i];
                        }
                    }
                }
                else
                {
                    //incorrect letter
                    incorrectLetter.Append(guess);
                    incorrectLetter.Append(' ');
                }

                return -1;// reduse guesses by -1
            }
        }

        static void HangmanStatus(int guessCounter, char[] correctLetters, StringBuilder incorrectLetter)
        {
            Console.Clear();
            Console.WriteLine("Guess left: " + guessCounter);

            Console.Write("correctLetters: ");
            for (int i = 0; i < correctLetters.Length; i++)
            {
                Console.Write(correctLetters[i].ToString() + ' ');
            }

            Console.WriteLine("\nincorrectLetter: " + incorrectLetter.ToString());
        }

        /// <summary>
        /// • The secret word should be randomly chosen from an array of Strings.
        /// </summary>
        /// <returns></returns>
        static string RandomPickWord()
        {

            string[] wordPool = { "Hello", "World", "Love", "Code" };

            int randomIndex = random.Next(wordPool.Length);//wordPool.Length == 4

            string secretWord = wordPool[randomIndex];

            return secretWord;

        }


    }
}
