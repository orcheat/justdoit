using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using todolist.Data;
using todolist.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using todolist.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace todolist.Controllers
{
  //  [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskRepository _repository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string _connectionString;
        private readonly UserRepository _userRepository;
        
        public TaskController(TaskRepository repository, CategoryRepository categoryRepository, IConfiguration configuration, UserRepository userRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _userRepository = userRepository;
        }



        public IActionResult Index(string category)
        {
            var tasks = _repository.GetAllTasks();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                tasks = tasks.Where(t => t.Category == category).ToList();
            }

            ViewBag.SelectedCategory = category;

            return View(tasks);
        }



        //public IActionResult ClientView(string category)
        //{
        //    var tasks = _repository.GetAllTasks();

        //    if (!string.IsNullOrEmpty(category) && category != "All")
        //    {
        //        tasks = tasks.Where(t => t.Category == category).ToList();
        //    }

        //    ViewBag.SelectedCategory = category;

        //    return View(tasks); // Return the ClientView instead of Index view
        //}

        //public IActionResult ClientView(int userId, string category)
        //{
        //    // Get all tasks assigned to the current user
        //    var tasks = _repository.GetAllTasks()
        //                           .Where(t => t.UserId == userId || t.UserId == 0) // Include tasks assigned to no one if applicable
        //                           .ToList();

        //    // Further filter by category if provided
        //    if (!string.IsNullOrEmpty(category) && category != "All")
        //    {
        //        tasks = tasks.Where(t => t.Category == category).ToList();
        //    }

        //    ViewBag.SelectedCategory = category;
        //    ViewBag.Categories = _categoryRepository.GetAllCategories(); // Ensure this is populated

        //    return View(tasks);
        //}

        public IActionResult ClientView(string category)
        {
            // Retrieve the logged-in user's ID from the session
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                // Handle the case where the user is not logged in or session has expired
                return RedirectToAction("Login", "Account");
            }

            // Get all tasks assigned to the current user
            var tasks = _repository.GetAllTasks().Where(t => t.UserId == userId.Value).ToList();

            // Further filter by category if provided
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                tasks = tasks.Where(t => t.Category == category).ToList();
            }

            ViewBag.SelectedCategory = category;
            ViewBag.Categories = _categoryRepository.GetAllCategories(); // Ensure this is populated

            return View(tasks); // Return the ClientView
        }



        public IActionResult Create()
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    return Forbid(); // Clients cannot create tasks
            //}
            ViewBag.Users = _userRepository.GetUsers();

            ViewBag.Categories = _categoryRepository.GetAllCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    return Forbid(); // Clients cannot create tasks
            //}

            if (ModelState.IsValid)
            {
                _repository.AddTask(task);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Users = _userRepository.GetUsers();
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            return View(task);
        }

        public IActionResult Edit(int id)
        {

            //if (!User.IsInRole("Admin"))
            //{
            //    return Forbid(); // Clients cannot create tasks
            //}
            var task = _repository.GetTaskById(id);
            

            if (task == null)
            {
                return NotFound();
            }
            ViewBag.Users = _userRepository.GetUsers();
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    return Forbid(); // Clients cannot create tasks
            //}

            if (ModelState.IsValid)
            {
                _repository.UpdateTask(task);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = _userRepository.GetUsers();
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    return Forbid(); 
            //}

            var task = _repository.GetTaskById(id);
           
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    return Forbid(); 
            //}

            _repository.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var task = _repository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            task.Comments = _repository.GetCommentsByTaskId(id);
            task.Documents = _repository.GetDocumentsByTaskId(id); 
            ViewBag.CategoryName = _categoryRepository.GetCategoryNameById(task.CategoryId);
            return View(task);
        }

        public IActionResult DetailsClient(int id)
        {
            var task = _repository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            task.Comments = _repository.GetCommentsByTaskId(id);
            task.Documents = _repository.GetDocumentsByTaskId(id);
            ViewBag.CategoryName = _categoryRepository.GetCategoryNameById(task.CategoryId);
            return View(task);
        }


        [HttpPost]
        public IActionResult AddComment(int taskId, string commentText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO Comments_arc (TaskId, CommentText, CreatedAt) VALUES (@TaskId, @CommentText, @CreatedAt)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TaskId", taskId);
                        cmd.Parameters.AddWithValue("@CommentText", commentText);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Details", new { id = taskId });
            }
            catch (SqlException sqlEx)
            {
                
                Debug.WriteLine($"SQL Error: {sqlEx.Message}");

               
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = sqlEx.Message });
            }
            catch (Exception ex)
            {
          
                Debug.WriteLine($"Error adding comment: {ex.Message}");

                // Return an error view with the general exception message
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult EditComment(int commentId)
        {
            var comment = _repository.GetCommentById(commentId);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        public IActionResult EditComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateComment(comment);
                return RedirectToAction("Details", new { id = comment.TaskId });
            }
            return View(comment);
        }

        // Action to delete a comment
        [HttpPost]
        public IActionResult DeleteComment(int commentId, int taskId)
        {
            _repository.DeleteComment(commentId);
            return RedirectToAction("Details", new { id = taskId });
        }

        [HttpPost]
      
        public IActionResult UploadDocument(int taskId, IFormFile document)
        {
            if (document != null && document.Length > 0)
            {
                // Set the directory path
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "documents");

                // Check if the directory exists, if not, create it
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Get the file name and combine it with the directory path
                var fileName = Path.GetFileName(document.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    document.CopyTo(stream);
                }

                // Save document info to the database
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Documents_arc (TaskId, DocumentPath, UploadedAt) VALUES (@TaskId, @DocumentPath, @UploadedAt)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TaskId", taskId);
                        cmd.Parameters.AddWithValue("@DocumentPath", $"/documents/{fileName}"); // Save relative path
                        cmd.Parameters.AddWithValue("@UploadedAt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            return RedirectToAction("Details", new { id = taskId });
        }

        [HttpPost]

        public IActionResult DeleteDocument(int documentId, int taskId)
        {
            try
            {
                // Retrieve the document details from the database
                var document = _repository.GetDocumentById(documentId);
                if (document == null)
                {
                    // Handle the case where the document was not found in the database
                    return NotFound();
                }

                // Delete from the database
                _repository.DeleteDocument(documentId);

                // Ensure DocumentPath is not null or empty
                if (string.IsNullOrEmpty(document.DocumentPath))
                {
                    // Log a warning or handle the case where DocumentPath is missing
                    Console.WriteLine("DocumentPath is null or empty");
                    return RedirectToAction("Details", new { id = taskId });
                }


                return RedirectToAction("Details", new { id = taskId });
            }
            catch (Exception ex)
            {
                // Log the exception and show an error view
                Console.WriteLine(ex); // or use a logger
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpPost]
        public IActionResult ToggleComplete(TaskItem task)
        {
            _repository.UpdateTaskCompletion(task.Id, task.IsCompleted);
            return RedirectToAction("DetailsClient", new { id = task.Id });
        }






    }
}
