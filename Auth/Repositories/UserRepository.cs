using System;
using System.Data.SqlClient;
using Auth.Models;


namespace Auth.Repositories
{
    public class UserRepository
    {
        private string connectionString = "server=localhost;database=auth_sys;uid=root;password="; // Replace with your actual connection string

        public void CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Email", user.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public User GetUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    return user;
                }

                return null;
            }
        }

        public void SaveResetToken(string username, string resetToken)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET ResetToken = @ResetToken WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ResetToken", resetToken);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string GetResetToken(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ResetToken FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }

                return null;
            }
        }

        public void UpdatePassword(string username, string password, string salt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @Password, Salt = @Salt, ResetToken = NULL WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
