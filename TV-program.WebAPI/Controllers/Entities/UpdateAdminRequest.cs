namespace TV_program.WebAPI.Controllers.Entities
{
    public class UpdateAdminRequest
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
