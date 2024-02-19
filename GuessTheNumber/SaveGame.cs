using System;
using System.IO;

namespace GuessTheNumber
{
    public class SaveGame
    {
        public void SaveResult(string gameResult)
        {
            string fileName = "game_history.csv";
            try
            {
                if (!File.Exists(fileName))
                {
                    string header = "Date,Difficulty Level,Attempts";
                    File.WriteAllText(fileName, header + Environment.NewLine);
                }
                File.AppendAllText(fileName, gameResult + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving game result: {ex.Message}");
            }
        }
    }
}
