using System;
using Auth_Sys.Controllers;

namespace Auth_Sys
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthenticationController authController = new AuthenticationController();

            Console.WriteLine("Welcome to the Secure Authentication System!");
            Console.WriteLine("--------------------------------------------");

            while (true)
            {
                Console.WriteLine("\nAvailable Actions:");
                Console.WriteLine("1. New Here? Create Account");
                Console.WriteLine("2. Login To the system");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1-3): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        authController.RegisterUser();
                        break;
                    case "2":
                        authController.AuthenticateUser();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
