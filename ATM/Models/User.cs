public class User
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; }

    public User(string username)
    {
        UserId = Guid.NewGuid();
        Username = username;
    }
}