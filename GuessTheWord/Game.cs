class Game
{
    private readonly PlayerManager _playerManager;
    private readonly List<string> _words = new List<string>
        {
            "apple", "banana", "orange", "grape", "kiwi",
            "strawberry", "pineapple", "blueberry", "peach", "watermelon"
        };

    public Game(PlayerManager playerManager)
    {
        _playerManager = playerManager;
    }

    public void Start(string playerName)
    {
        Random random = new Random();
        string wordToGuess = _words[random.Next(_words.Count)];
        string hiddenWord = new string('_', wordToGuess.Length);
        HashSet<char> guessedLetters = new HashSet<char>();
        int chances = 6;

        Console.WriteLine($"Guess the word: {hiddenWord}");

        while (chances > 0)
        {
            Console.WriteLine($"\nChances left: {chances}");
            Console.Write("Enter a letter: ");
            char guessedLetter = Char.ToLower(Console.ReadKey().KeyChar);
            if (guessedLetters.Contains(guessedLetter))
            {
                Console.WriteLine("\nYou already guessed that letter. Try again.");
                continue;
            }

            guessedLetters.Add(guessedLetter);

            if (wordToGuess.Contains(guessedLetter))
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guessedLetter)
                    {
                        char[] hiddenWordArray = hiddenWord.ToCharArray();
                        hiddenWordArray[i] = guessedLetter;
                        hiddenWord = new string(hiddenWordArray);
                    }
                }
                Console.WriteLine($"\nCorrect! Updated word: {hiddenWord}");

                if (hiddenWord == wordToGuess)
                {
                    Console.WriteLine("Congratulations! You guessed the word correctly!");
                    _playerManager.UpdatePlayerScore(playerName, hiddenWord.Length);
                    break;
                }
            }
            else
            {
                chances--;
                Console.WriteLine("\nIncorrect guess!");
                if (chances == 0)
                {
                    Console.WriteLine($"Sorry, you've run out of chances. The word was: {wordToGuess}");
                    break;
                }
            }
        }
    }
}