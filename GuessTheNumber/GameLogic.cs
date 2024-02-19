using System;

namespace GuessTheNumber
{
    public class GameLogic
    {
        private Random random = new Random();
        private int targetNumber;
        private int minRange;
        private int maxRange;
        private int attempts;
        private bool correctGuess;
        private string difficultyLevel;
        private string playerName;
        private int attemptsLimit = 10;


        public void InitializeGame()
        {
            SetDifficultyLevel();
            attempts = 0;
            correctGuess = false;
            Console.WriteLine($"Guess the number (between {minRange} and {maxRange}):");
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

            switch (choice)
            {
                case "1":
                    minRange = 1;
                    maxRange = 15;
                    difficultyLevel= "Easy";
                    break;
                case "2":
                    minRange = 1;
                    maxRange = 25;
                    difficultyLevel = "Medium";
                    break;
                case "3":
                    minRange = 1;
                    maxRange = 50;
                    difficultyLevel = "Hard";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Easy level.");
                    minRange = 1;
                    maxRange = 15;
                    difficultyLevel = "Easy";
                    break;
            }

            targetNumber = GenerateRandomNumber(minRange, maxRange);
        }

        public void PlayGame()
        {
            InitializeGame();

            while (!correctGuess && attempts < attemptsLimit)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int userGuess) || userGuess < minRange || userGuess > maxRange)
                {
                    Console.WriteLine($"Invalid input. Please enter a valid number between {minRange} and {maxRange}.");
                    continue;
                }

                attempts++;

                if (userGuess < targetNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                    Console.WriteLine($"you have left {attempts} try");
                }
                else if (userGuess > targetNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                    Console.WriteLine($"you have left {attempts} try");
                }
                else
                {
                    correctGuess = true;
                    Console.WriteLine($"Congratulations! You've guessed the number {targetNumber} in {attempts} attempts.");
                }
            }

            if (!correctGuess)
            {
                Console.WriteLine($"Sorry, you've used all your attempts. The correct number was {targetNumber}.");
            }
        }

        private int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public string GetGameResult()
        {
           
            return $"{DateTime.Now},{difficultyLevel},{attempts}";
        }
    }
}
