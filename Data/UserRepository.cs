using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using todolist.Models;

namespace todolist.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            User user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Users_arc WHERE Username = @Username AND Password = @Password";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return user;
        }

        public string GetUserRole(string username)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT Role FROM Users_arc WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Username FROM Users_arc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                   
                            });
                        }
                    }
                }
            }

            return users;
        }
        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Users_arc SET Password = @Password WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User GetUserById(int userId)
        {
            User user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Users_arc WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return user;
        }

        public string DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Check if the user has any tasks assigned
                var checkTasksQuery = "SELECT COUNT(*) FROM Tasks_arc WHERE UserId = @UserId";
                using (var command = new SqlCommand(checkTasksQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    int taskCount = (int)command.ExecuteScalar();

                    if (taskCount > 0)
                    {
                        // Return a message indicating the user cannot be deleted
                        return "User cannot be deleted because they have tasks assigned.";
                    }
                }

                // If no tasks are assigned, delete the user
                var deleteUserQuery = "DELETE FROM Users_arc WHERE Id = @UserId";
                using (var command = new SqlCommand(deleteUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }

                return "User deleted successfully.";
            }
        }
        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Users_arc (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}

