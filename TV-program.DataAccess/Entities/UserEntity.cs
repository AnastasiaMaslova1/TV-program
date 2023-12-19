using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("user")]
    public class UserEntity : IdentityUser<int>, IBaseEntity
    {
        public Guid ExternalId { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public DateTime Registration { get; set; }
        public DateTime LastEntry { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserChannelEntity> UserChannel { get; set; }
    }

    public class UserRoleEntity : IdentityRole<int>
    {
    }
}