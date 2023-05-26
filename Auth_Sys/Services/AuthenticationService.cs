using Auth_Sys.Models;
using Auth_Sys.Services;
using Auth_Sys.Repositories;
using Auth_Sys.Utilities;


namespace Auth_Sys.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository userRepository;

        public AuthenticationService()
        {
            userRepository = new UserRepository();
        }

        public bool RegisterUser(string username, string password, string email)
        {
            // Check if the username is already taken
            User existingUser = userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                Console.WriteLine("Username is already taken.");
                return false;
            }

            // Hash the password
            string hashedPassword = HashingUtility.HashPassword(password);

            // Create a new User object
            User newUser = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            // Save the user in the database
            userRepository.CreateUser(newUser);

            Console.WriteLine("User registered successfully.");
            return true;
        }

        public bool AuthenticateUser(string username, string password)
        {
            // Retrieve the user from the database
            User user = userRepository.GetUserByUsername(username);

            if (user != null)
            {
                // Hash the provided password
                string hashedPassword = HashingUtility.HashPassword(password);

                // Compare the hashed passwords
                if (hashedPassword == user.Password)
                {
                    Console.WriteLine("Authentication successful.");
                    return true;
                }
            }

            Console.WriteLine("Authentication failed.");
            return false;
        }
    }
}

