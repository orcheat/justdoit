using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using todolist.Models;

namespace todolist.Data
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<TaskItem> GetAllTasks()
        {
            var tasks = new List<TaskItem>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(
            @"SELECT t.Id, t.Title, t.DueDate, t.IsCompleted, t.Priority, c.Name AS CategoryName, t.UserId, u.Username
              FROM Tasks_arc t
              LEFT JOIN Categories_arc c ON t.CategoryId = c.Id
              LEFT JOIN Users_arc u ON t.UserId = u.Id ORDER BY (t.Priority)", connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskItem
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            DueDate = (DateTime)reader["DueDate"],
                            IsCompleted = (bool)reader["IsCompleted"],
                            Priority = reader["Priority"].ToString(),
                            Category = reader["CategoryName"]?.ToString(),
                            UserId = reader["UserId"] != DBNull.Value ? (int)reader["UserId"] : 0,
                            UserName = reader["Username"]?.ToString()
                        });
                    }
                }
            }

            return tasks;
        }



        public List<Category> GetAllCategories()
        {
            var categories = new List<Category>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Categories_arc", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }

            return categories;
        }


        public void AddTask(TaskItem task)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var getCategoryIdCommand = new SqlCommand("SELECT Id FROM Categories_arc WHERE Name = @CategoryName", connection);
                getCategoryIdCommand.Parameters.AddWithValue("@CategoryName", task.Category);

                var categoryIdResult = getCategoryIdCommand.ExecuteScalar();

                if (categoryIdResult == null)
                {
                    throw new Exception($"Category with name {task.Category} does not exist.");
                }

                var categoryId = Convert.ToInt32(categoryIdResult);

                var command = new SqlCommand(
                    "INSERT INTO Tasks_arc (Title, DueDate, IsCompleted, Priority, CategoryId, UserId) VALUES (@Title, @DueDate, @IsCompleted, @Priority, @CategoryId, @UserId)",
                    connection);

                command.Parameters.AddWithValue("@Title", task.Title);
                command.Parameters.AddWithValue("@DueDate", task.DueDate);
                command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                command.Parameters.AddWithValue("@Priority", task.Priority);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@UserId", task.UserId != 0 ? (object)task.UserId : DBNull.Value); // Handle UserId appropriately

                command.ExecuteNonQuery();
            }
        }





        public TaskItem GetTaskById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Task ID must be greater than 0.");
            }

            TaskItem task = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(
                    @"SELECT t.Id, t.Title, t.DueDate, t.IsCompleted, t.Priority, t.CategoryId, c.Name AS CategoryName, t.UserId, u.Username
              FROM Tasks_arc t
              LEFT JOIN Categories_arc c ON t.CategoryId = c.Id
              LEFT JOIN Users_arc u ON t.UserId = u.Id
              WHERE t.Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        task = new TaskItem
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            DueDate = (DateTime)reader["DueDate"],
                            IsCompleted = (bool)reader["IsCompleted"],
                            Priority = reader["Priority"].ToString(),
                            CategoryId = (int)reader["CategoryId"],
                            Category = reader["CategoryName"]?.ToString(),
                            UserId = reader["UserId"] != DBNull.Value ? (int)reader["UserId"] : 0,
                            UserName = reader["Username"]?.ToString()
                        };
                    }
                }
            }

            return task;
        }

        public void UpdateTask(TaskItem task)
        {
            if (task.Id <= 0)
            {
                throw new ArgumentException("Task ID must be greater than 0.");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Check if the category exists
                var getCategoryIdCommand = new SqlCommand("SELECT Id FROM Categories_arc WHERE Name = @CategoryName", connection);
                getCategoryIdCommand.Parameters.AddWithValue("@CategoryName", task.Category);

                var categoryIdResult = getCategoryIdCommand.ExecuteScalar();

                if (categoryIdResult == null)
                {
                    throw new Exception($"Category with name {task.Category} does not exist.");
                }

                var categoryId = Convert.ToInt32(categoryIdResult);

                // Check if the task exists
                var checkTaskExistsCommand = new SqlCommand("SELECT COUNT(1) FROM Tasks_arc WHERE Id = @Id", connection);
                checkTaskExistsCommand.Parameters.AddWithValue("@Id", task.Id);

                var taskExists = (int)checkTaskExistsCommand.ExecuteScalar() > 0;
                if (!taskExists)
                {
                    throw new Exception($"Task with ID {task.Id} does not exist.");
                }

                // Update task
                var command = new SqlCommand(
                    "UPDATE Tasks_arc SET Title = @Title, DueDate = @DueDate, IsCompleted = @IsCompleted, Priority = @Priority, CategoryId = @CategoryId, UserId = @UserId WHERE Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@Id", task.Id);
                command.Parameters.AddWithValue("@Title", task.Title);
                command.Parameters.AddWithValue("@DueDate", task.DueDate);
                command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                command.Parameters.AddWithValue("@Priority", task.Priority);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@UserId", task.UserId != 0 ? (object)task.UserId : DBNull.Value); // Handle UserId appropriately

                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception($"No rows were updated for task with ID {task.Id}. This may be due to an incorrect ID or no changes being made.");
                }
            }
        }



        // Delete a task
        public void DeleteTask(int taskId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Begin a transaction
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // First delete related documents
                        var deleteDocumentsQuery = "DELETE FROM Documents_arc WHERE TaskId = @TaskId";
                        using (var command = new SqlCommand(deleteDocumentsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TaskId", taskId);
                            command.ExecuteNonQuery();
                        }

                        // Then delete related comments
                        var deleteCommentsQuery = "DELETE FROM Comments_arc WHERE TaskId = @TaskId";
                        using (var command = new SqlCommand(deleteCommentsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TaskId", taskId);
                            command.ExecuteNonQuery();
                        }

                        // Finally delete the task
                        var deleteTaskQuery = "DELETE FROM Tasks_arc WHERE Id = @TaskId";
                        using (var command = new SqlCommand(deleteTaskQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TaskId", taskId);
                            var rowsAffected = command.ExecuteNonQuery();

                            // Check if the task was actually deleted
                            if (rowsAffected == 0)
                            {
                                throw new Exception("Task deletion failed. Task might not exist.");
                            }
                        }

                        // Commit the transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        throw; // Re-throw the exception to be handled by the caller
                    }
                }
            }
        }



        // Add a new category
        public void AddCategory(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Categories_arc (Name) VALUES (@Name)", connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Comment> GetCommentsByTaskId(int taskId)
        {
            var comments = new List<Comment>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Comments_arc WHERE TaskId = @TaskId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comments.Add(new Comment
                            {
                                CommentId = reader.GetInt32(reader.GetOrdinal("CommentId")),
                                TaskId = reader.GetInt32(reader.GetOrdinal("TaskId")),
                                CommentText = reader.GetString(reader.GetOrdinal("CommentText")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            });
                        }
                    }
                }
            }

            return comments;
        }
        public Comment GetCommentById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Comments_arc WHERE CommentId = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Comment
                        {
                            CommentId = reader.GetInt32(0),
                            TaskId = reader.GetInt32(1),
                            CommentText = reader.GetString(2),
                            CreatedAt = reader.GetDateTime(3)
                        };
                    }
                }
            }

            return null;
        }



        // Method to update a comment
        public void UpdateComment(Comment comment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = "UPDATE Comments_arc SET CommentText = @CommentText WHERE CommentId = @CommentId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CommentId", comment.CommentId);
                    cmd.Parameters.AddWithValue("@CommentText", comment.CommentText);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a comment
        public void DeleteComment(int commentId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM Comments_arc WHERE CommentId = @CommentId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CommentId", commentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddDocument(int taskId, string documentPath)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO TaskDocuments_arc (TaskId, DocumentPath) VALUES (@TaskId, @DocumentPath)", connection);
                command.Parameters.AddWithValue("@TaskId", taskId);
                command.Parameters.AddWithValue("@DocumentPath", documentPath);
                command.ExecuteNonQuery();
            }
        }

        public List<Document> GetDocumentsByTaskId(int taskId)
        {
            List<Document> documents = new List<Document>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Documents_arc WHERE TaskId = @TaskId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            documents.Add(new Document
                            {
                                DocumentId = (int)reader["DocumentId"],
                                TaskId = (int)reader["TaskId"],
                                DocumentPath = reader["DocumentPath"].ToString(),
                                UploadedAt = (DateTime)reader["UploadedAt"]
                            });
                        }
                    }
                }
            }

            return documents;
        }

        public Document GetDocumentById(int documentId)
        {
            Document document = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Documents_arc WHERE DocumentId = @DocumentId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DocumentId", documentId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            document = new Document
                            {
                                DocumentId = (int)reader["DocumentId"],
                                TaskId = (int)reader["TaskId"],
                                DocumentPath = reader["DocumentPath"].ToString(),
                                UploadedAt = (DateTime)reader["UploadedAt"]
                            };
                        }
                    }
                }
            }

            return document;
        }


        public void DeleteDocument(int documentId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Documents_arc WHERE DocumentId = @DocumentId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DocumentId", documentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTaskCompletion(int taskId, bool isCompleted)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Tasks_arc SET IsCompleted = @IsCompleted WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IsCompleted", isCompleted);
                    command.Parameters.AddWithValue("@Id", taskId);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
