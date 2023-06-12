using Auth_Sys.Models;
using Auth_Sys.Services;
using Auth_Sys.Repositories;
using Auth_Sys.Utilities;

namespace Auth_Sys.Services
{
    public AuthenticationService()
    {
        userRepository = new UserRepository();
    }

    public bool RegisterUser(string username, string password, string email)
    {
        User existingUser = userRepository.GetUserByUsername(username);
        if (existingUser != null)
        {
            Console.WriteLine("Username already exists. Please choose a different username.");
            return false;
        }

        string hashedPassword = HashingUtility.HashPassword(password);

        User newUser = new User
        {
            Username = username,
            Password = hashedPassword,
            Email = email
        };

        userRepository.CreateUser(newUser);

        Console.WriteLine("User registration successful.");
        return true;
    }

    public bool AuthenticateUser(string username, string password)
    {
        User user = userRepository.GetUserByUsername(username);
        if (user == null)
        {
            Console.WriteLine("Invalid username.");
            return false;
        }

        string hashedPassword = HashingUtility.HashPassword(password);
        if (user.Password != hashedPassword)
        {
            Console.WriteLine("Incorrect password.");
            return false;
        }

        Console.WriteLine("User authentication successful.");
        return true;
    }
}

