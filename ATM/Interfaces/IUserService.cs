public interface IUserService
{
    User GetUserById(Guid userId);
    User RegisterUser(string username);
}


