using System.ComponentModel.DataAnnotations.Schema;


namespace TV_program.DataAccess.Entities
{
    [Table("show-genre")]
    public class ShowGenreEntity : BaseEntity
    {
        public int IdShow { get; set; }
        public TVShowEntity TVShow { get; set; }
        public int IdGenre { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
