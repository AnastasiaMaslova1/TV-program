using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("TV show")]
    public class TVShowEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime BroadcastDate { get; set; }
        public TimeSpan BroadcastTime { get; set; }
        public int IdChannel { get; set; }
        public ChannelEntity Channel { get; set; }
        public ICollection<ShowGenreEntity> ShowGenre { get; set; }
        public ICollection<ShowActorEntity> ShowActor { get; set; }
    }
}
