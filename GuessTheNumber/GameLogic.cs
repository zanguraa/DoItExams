using System;

namespace GuessTheNumber
{
    public class GameLogic
    {
        private Random random = new Random();
        private int targetNumber;
        private int attempts;
        private bool correctGuess;

        public void InitializeGame()
        {
            SetDifficultyLevel();
            attempts = 0;
            correctGuess = false;
            Console.WriteLine($"Guess the number (between 1 and {targetNumber}):");
        }

        private void SetDifficultyLevel()
        {
            Console.WriteLine("Welcome to Guess The Number Game!");
            Console.WriteLine("Please choose the difficulty level:");
            Console.WriteLine("1. Easy (1-15)");
            Console.WriteLine("2. Medium (1-25)");
            Console.WriteLine("3. Hard (1-50)");
            Console.Write("Enter your choice (1/2/3): ");
            string choice = Console.ReadLine();

            int[] maxRanges = { 15, 25, 50 };
            int index;

            if (int.TryParse(choice, out int numericChoice) && numericChoice >= 1 && numericChoice <= 3)
            {
                index = numericChoice - 1;
            }
            else
            {
                Console.WriteLine("Invalid choice. Defaulting to Easy level.");
                index = 0;
            }

            targetNumber = GenerateRandomNumber(1, maxRanges[index]);
        }

        public void PlayGame()
        {
            while (!correctGuess)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int userGuess) || userGuess < 1 || userGuess > targetNumber)
                {
                    Console.WriteLine($"Invalid input. Please enter a valid number between 1 and {targetNumber}.");
                    continue;
                }

                attempts++;

                if (userGuess < targetNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (userGuess > targetNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    correctGuess = true;
                    Console.WriteLine($"Congratulations! You've guessed the number {targetNumber} in {attempts} attempts.");
                }
            }
        }

        private int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public string GetGameResult()
        {
            string difficultyLevel = "";
            return $"{DateTime.Now},{difficultyLevel},{attempts}";
        }
    }
}
