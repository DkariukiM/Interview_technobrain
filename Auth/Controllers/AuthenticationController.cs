//responsible for handling user registration and login
//Importing Required Namespaces 
//The code begins by importing the necessary namespaces. 
//The System namespace provides fundamental classes and base types, 
//while the Auth.Services namespace contains the AuthenticationService 
//class required for user registration and authentication.

using System;
using Auth.Services;


namespace Auth.Controllers
{
    public class AuthenticationController
    {
        private readonly AuthenticationService authenticationService;

        public AuthenticationController()
        {
            authenticationService = new AuthenticationService();
        }

        public void RegisterUser()
        {
            Console.WriteLine("User Registration");
            Console.WriteLine("-----------------");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            authenticationService.RegisterUser(username, password, email);
        }

        public void AuthenticateUser()
        {
            Console.WriteLine("User Authentication");
            Console.WriteLine("-------------------");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            authenticationService.AuthenticateUser(username, password);
        }
    }
}