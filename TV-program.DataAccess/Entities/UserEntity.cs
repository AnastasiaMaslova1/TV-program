using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("user")]
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public DateTime Registration { get; set; }
        public DateTime LastEntry { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserChannelEntity> UserChannel { get; set; }
    }
}