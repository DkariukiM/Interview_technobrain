using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ProjectName.Models;

namespace ProjectName.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString = "server=localhost;database=auth_sys;uid=root;password="; // "server=localhost;database=mydatabase;uid=myusername;password=mypassword";


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
