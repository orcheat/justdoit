//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System.Security.Cryptography;
//using System.Text;
//using todolist.Models;
//using todolist.Data;
//using System;
//using System.Diagnostics;

//namespace todolist.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserRepository _userRepository;

//        public AccountController(UserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]


//        public IActionResult Login(LoginViewModel model)
//        {
//            try
//            {
//                var user = _userRepository.GetUserByUsername(model.Username);
//                if (user != null && VerifyPassword(model.Password, user.PasswordHash))
//                {
//                    // Log successful login attempt
//                    Debug.WriteLine("User authenticated successfully");

//                    HttpContext.Session.SetString("Username", user.Username);
//                    HttpContext.Session.SetString("Role", user.Role);

//                    // Log session details
//                    Debug.WriteLine($"Session Username: {HttpContext.Session.GetString("Username")}");
//                    Debug.WriteLine($"Session Role: {HttpContext.Session.GetString("Role")}");

//                    var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();
//                    Debug.WriteLine($"Return URL: {returnUrl}");
//                    if (string.IsNullOrEmpty(returnUrl))
//                    {
//                        returnUrl = Url.Action("Index", "Task");
//                    }
//                    return Redirect(returnUrl);

//                }
//                else
//                {
//                    ModelState.AddModelError("", "Invalid username or password.");
//                }

//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                Debug.WriteLine($"Login error: {ex.Message}");
//                ModelState.AddModelError("", "An error occurred while logging in.");
//            }
//            return View(model);
//        }



//        [HttpGet]
//        public IActionResult Logout()
//        {
//            HttpContext.Session.Clear();
//            return RedirectToAction("Login");
//        }

//        private bool VerifyPassword(string password, string storedHash)
//        {
//            using (var sha256 = SHA256.Create())
//            {
//                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
//                var hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
//                return hashString == storedHash;
//            }
//        }
//    }
//}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using todolist.Data;
using todolist.Models;
using System.Linq;
using System.Collections.Generic;

public class AccountController : Controller
{
    private readonly UserRepository _userRepository;

    public AccountController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    //public async Task<IActionResult> Login(string username, string password)
    //{
    //    var user = await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);
    //    if (user != null)
    //    {
    //        // Here you can set the authentication cookie or session
    //        // For example, using session:
    //        //HttpContext.Session.SetString("Username", user.Username);
    //        //HttpContext.Session.SetString("Role", user.Role);

    //        if (user.Role == "Admin")
    //        {
    //            return RedirectToAction("Index", "Task"); // Redirect to admin dashboard
    //        }
    //        else if (user.Role == "Client")
    //        {
    //            return RedirectToAction("ClientView", "Task"); // Redirect to client dashboard
    //        }
    //    }
    //    ModelState.AddModelError("", "Invalid username or password");
    //    return View();
    //}

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await ValidateUserAsync(model.Username, model.Password);
            if (user != null)
            {
                // Set userId in session
                HttpContext.Session.SetInt32("UserId", user.Id);

                // Redirect based on user role
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Task"); // Redirect to admin dashboard
                }
                else if (user.Role == "Client")
                {
                    return RedirectToAction("ClientView", "Task"); // Redirect to client dashboard
                }
            }
            ModelState.AddModelError("", "Invalid username or password.");
        }
        return View(model);
    }

    private async Task<User> ValidateUserAsync(string username, string password)
    {
        // Call the method from UserRepository to validate the user
        return await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ChangePassword(ChangePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var user = _userRepository.GetUserById(userId.Value);
                if (user != null && user.Password == model.OldPassword)
                {
                    user.Password = model.NewPassword;
                    _userRepository.UpdateUser(user);

                    TempData["Message"] = "Password changed successfully!";
                    return RedirectToAction("Login", "Account");
                }

                ModelState.AddModelError("", "The old password is incorrect.");
            }
        }

        return View(model);
    }

    public IActionResult ViewUsers()
    {
        var users = _userRepository.GetUsers();
        var filteredUsers = new List<User>();

        foreach (var user in users)
        {
            var role = _userRepository.GetUserRole(user.Username);
            if (role != "Admin")
            {
                filteredUsers.Add(user);
            }
        }

        return View(filteredUsers);
    }



    [HttpPost]
    public IActionResult DeleteUser(int id)
    {
        var message = _userRepository.DeleteUser(id);

        if (message == "User deleted successfully.")
        {
            return RedirectToAction("ViewUsers");
        }
        else
        {
            TempData["ErrorMessage"] = message;
            return RedirectToAction("ViewUsers");
        }
    }

    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddUser(User model)
    {
        if (ModelState.IsValid)
        {
            // Add the user to the database
            _userRepository.AddUser(model);

            // Redirect to the list of users after successful addition
            return RedirectToAction("ViewUsers");
        }

        // If the model is invalid, return the same view with validation messages
        return View(model);
    }

}
