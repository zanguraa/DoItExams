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
                    string header = "PlayerName,Date,Difficulty Level,Attempts";
                    File.WriteAllText(fileName, header + Environment.NewLine);
                }
                File.AppendAllText(fileName, gameResult + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving game result: {ex.Message}");
            }
        }
        public string TopTenPlayers()
        {
            string fileName = "game_history.csv";
            string topTenPlayers = "";
            try
            {
                if (File.Exists(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName);
                    if (lines.Length > 1)
                    {
                        Array.Sort(lines, 1, lines.Length - 1);
                        int count = 0;
                        foreach (string line in lines)
                        {
                            if (count < 10)
                            {
                                topTenPlayers += line + Environment.NewLine;
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving top 10 players: {ex.Message}");
            }
            return topTenPlayers;
        }
    }
}
