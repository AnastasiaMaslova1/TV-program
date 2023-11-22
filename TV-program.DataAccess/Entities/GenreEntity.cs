using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("genre")]
    public class GenreEntity : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<ShowGenreEntity> ShowGenre { get; set; }

    }
}
