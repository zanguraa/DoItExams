
namespace GuessTheWord
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Guessing Game!");

            var playerManager = new PlayerManager(new FileHandler());
            var game = new Game(playerManager);

            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            game.Start(playerName);

            Console.WriteLine("\nThanks for playing!");
        }
    }

}