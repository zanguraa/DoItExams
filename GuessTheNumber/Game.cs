namespace GuessTheNumberGame
{
    public class Game
    {
        private int randomNumber;
        private int attempts;
        private bool correctGuess;

        public Game()
        {
            Random random = new Random();
            randomNumber = random.Next(1, 101);
            attempts = 0;
            correctGuess = false;
        }

        public void Play()
        {
            Console.WriteLine("Welcome to Guess The Number Game!");
            Console.WriteLine("I've picked a random number between 1 and 100. Can you guess it?");

            while (!correctGuess)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                attempts++;

                if (guess < randomNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    correctGuess = true;
                    Console.WriteLine($"Congratulations! You've guessed the number {randomNumber} in {attempts} attempts.");
                }
            }
        }
    }
}