using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("user-channel")]
    public class UserChannelEntity : BaseEntity
    {
        public int IdUser { get; set; }
        public UserEntity User { get; set; }
        public int IdChannel { get; set; }
        public ChannelEntity Channel { get; set; }
    }
}