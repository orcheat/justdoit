// Models/LoginViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
