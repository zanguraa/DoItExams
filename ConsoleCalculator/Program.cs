using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Power");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "6")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                if(choice == null || choice == "")
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                int num1, num2;
                Console.Write("Enter first number: ");
                while (!int.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }

                Console.Write("Enter second number: ");
                while (!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }

                try
                {
                    int result = 0;
                    switch (choice)
                    {
                        case "1":
                            result = calculator.Add(num1, num2);
                            break;
                        case "2":
                            result = calculator.Subtract(num1, num2);
                            break;
                        case "3":
                            result = calculator.Multiply(num1, num2);
                            break;
                        case "4":
                            result = calculator.Divide(num1, num2);
                            break;
                        case "5":
                            result = calculator.Power(num1, num2);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            continue;
                    }

                    Console.WriteLine($"Result: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
