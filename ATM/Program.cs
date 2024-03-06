using ATM.Interfaces;
using ATM.Logging;
using ATM.Services;

class Program
{
    static IUserService userService = new UserService(); // Make sure to replace with your actual implementations
    static IAccountService accountService = new AccountService(new JsonFileLogger()); // Ditto

    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to the ATM!");

        bool closeApp = false;

        while (!closeApp)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Register User");
            Console.WriteLine("2) Login");
            Console.WriteLine("3) Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await RegisterUserAsync();
                    break;
                case "2":
                    await LoginAsync();
                    break;
                case "3":
                    closeApp = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static async Task RegisterUserAsync()
    {
        Console.WriteLine("Please enter a username to register:");
        string username = Console.ReadLine();
        // Additional input for password and other required data can be included here.

        try
        {
            // Call to the UserService to register the user
            User newUser = userService.RegisterUser(username);
            // You may want to save this user to your database here.

            Console.WriteLine($"Registration successful! Your user ID is: {newUser.UserId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during registration: {ex.Message}");
        }
    }

    static async Task LoginAsync()
    {
        Console.WriteLine("Please enter your user ID to login:");
        string userIdInput = Console.ReadLine();

        try
        {
            if (Guid.TryParse(userIdInput, out Guid userId))
            {
                // Here, you'd normally verify the username and password. Since we're using only the userID, 
                // we assume that if the user exists, it's a successful login.
                // In a real application, always use proper authentication (like JWT tokens, OAuth, etc.)

                // Example pseudo-code for user validation could be something like:
                // User user = await userService.ValidateUser(userId, password);
                User user = userService.GetUserById(userId); // Assuming this method exists and returns a user if found

                if (user != null)
                {
                    Console.WriteLine("Login successful!");
                    await DisplayUserMenuAsync(user);
                }
                else
                {
                    Console.WriteLine("Login failed. User not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid User ID format.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during login: {ex.Message}");
        }
    }

    static async Task DisplayUserMenuAsync(User user)
    {
        bool logout = false;

        while (!logout)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Check Balance");
            Console.WriteLine("2) Deposit Money");
            Console.WriteLine("3) Withdraw Money");
            Console.WriteLine("4) Change PIN");
            Console.WriteLine("5) View Transaction History");
            Console.WriteLine("6) Logout");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await CheckBalanceAsync(user);
                    break;
                case "2":
                    await DepositMoneyAsync(user);
                    break;
                case "3":
                    await WithdrawMoneyAsync(user);
                    break;
                case "4":
                    await ChangePINAsync(user);
                    break;
                case "5":
                    await ViewTransactionHistoryAsync(user);
                    break;
                case "6":
                    logout = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static async Task CheckBalanceAsync(User user)
    {
        try
        {
            var account = await accountService.GetAccountByUserId(user.UserId);
            if (account != null)
            {
                Console.WriteLine($"Your current balance is: ${account.Balance}");
            }
            else
            {
                Console.WriteLine("No account found for this user.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while checking the balance: {ex.Message}");
        }
    }

    static async Task DepositMoneyAsync(User user)
    {
        try
        {
            Console.WriteLine("How much would you like to deposit?");
            string input = Console.ReadLine();
            decimal amount;

            // Validate the input
            if (decimal.TryParse(input, out amount) && amount > 0)
            {
                // Retrieve the user's account. Assuming GetAccountByUserId is implemented and works as expected.
                var account = await accountService.GetAccountByUserId(user.UserId);
                if (account != null)
                {
                    // Deposit the money
                    await accountService.DepositMoneyAsync(account.AccountId, amount);

                    // Optionally, confirm the deposit to the user
                    Console.WriteLine($"Successfully deposited ${amount}. New balance will be displayed in the main menu.");
                }
                else
                {
                    Console.WriteLine("Failed to find your account.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during the deposit: {ex.Message}");
        }
    }

}
