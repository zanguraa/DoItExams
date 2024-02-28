class PlayerManager
{
    private readonly FileHandler _fileHandler;

    public PlayerManager(FileHandler fileHandler)
    {
        _fileHandler = fileHandler;
    }

    public void UpdatePlayerScore(string playerName, int score)
    {
        _fileHandler.UpdatePlayerScore(playerName, score);
    }
}