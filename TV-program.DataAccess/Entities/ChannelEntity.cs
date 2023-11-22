using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("channel")]
    public class ChannelEntity : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<UserChannelEntity> UserChannel { get; set; }
        public ICollection<TVShowEntity> TVShow { get; set; }
    }
}
