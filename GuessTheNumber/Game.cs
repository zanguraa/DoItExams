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
            gameLogic.InitializeGame();
            gameLogic.PlayGame();
            saveGame.SaveResult(gameLogic.GetGameResult());
        }
    }
}
