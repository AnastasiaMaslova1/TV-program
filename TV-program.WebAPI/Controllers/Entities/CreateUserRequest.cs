using System.ComponentModel.DataAnnotations;

namespace TV_program.WebAPI.Controllers.Entities
{
    public class CreateUserRequest
    {
        [Required]
        [MinLength(2)]
        public string Username { get; set; }

        [Required]
        [MinLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(10)]
        public string PasswordHash { get; set; }
    }
}
