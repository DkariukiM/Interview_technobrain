
using System;

namespace Auth_Sys.Controllers
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
