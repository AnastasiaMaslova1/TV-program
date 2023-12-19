namespace TV_program.WebAPI.Controllers.Entities
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
