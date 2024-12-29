using System.ComponentModel.DataAnnotations;

namespace Currere.Service.Authentication.Models
{
    public class LoginCredentials
    {
        [EmailAddress]
        [Required(ErrorMessage = "The user's email address is required.")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "The user's password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
