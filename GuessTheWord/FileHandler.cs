using System.Xml.Linq;

class FileHandler
{
    private const string FilePath = "top_players.xml";

    public void UpdatePlayerScore(string playerName, int score)
    {
        XDocument doc;
        if (File.Exists(FilePath))
        {
            doc = XDocument.Load(FilePath);
        }
        else
        {
            doc = new XDocument(new XElement("Players"));
        }

        XElement playerElement = doc.Root.Elements("Player").FirstOrDefault(e => e.Element("Name").Value == playerName);
        if (playerElement != null)
        {
            int currentScore = int.Parse(playerElement.Element("Score").Value);
            if (score > currentScore)
            {
                playerElement.Element("Score").SetValue(score);
            }
        }
        else
        {
            XElement newPlayer = new XElement("Player",
                                new XElement("Name", playerName),
                                new XElement("Score", score));
            doc.Root.Add(newPlayer);
        }

        doc.Save(FilePath);
        Console.WriteLine($"Updating player '{playerName}' score to {score} in file: {FilePath}");
    }
}