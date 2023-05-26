using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Auth_Sys.Models;

namespace Auth_Sys.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString = "server=localhost;database=auth_sys;uid=root;password= "; // Replace with your MySQL connection string eg server=localhost;database=mydatabase;uid=myusername;password=mypassword;

            // run the above query to create a user table
            //CREATE TABLE users (
            // id INT AUTO_INCREMENT PRIMARY KEY,
            // username VARCHAR(50) NOT NULL,
            // password VARCHAR(255) NOT NULL,
            // email VARCHAR(100) NOT NULL);
 



        public User GetUserByUsername(string username)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM users WHERE username = @Username";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Email = reader["email"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void CreateUser(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO users (username, password, email) VALUES (@Username, @Password, @Email)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
