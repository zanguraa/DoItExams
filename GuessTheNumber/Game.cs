using System;

namespace GuessTheNumber
{
    public class Game
    {
        private GameLogic gameLogic;
        private SaveGame saveGame;

        public Game()
        {
            gameLogic = new GameLogic();
            saveGame = new SaveGame();
        }

        public void Start()
        {
            gameLogic.PlayGame();
            saveGame.SaveResult(gameLogic.GetGameResult());
            saveGame.TopTenPlayers();

            Console.WriteLine("Do you want to see top 10 players? (yes/no)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "yes")
            {
                Console.WriteLine(saveGame.TopTenPlayers());
            }
            else
            {

                Console.WriteLine("Thank you for playing!");
            }
        }
    }
}
