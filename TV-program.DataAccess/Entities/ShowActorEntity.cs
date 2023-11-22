using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("show-actor")]
    public class ShowActorEntity : BaseEntity
    {
        public int IdShow { get; set; }
        public TVShowEntity TVShow { get; set; }
        public int IdActor { get; set; }
        public ActorEntity Actor { get; set; }
    }
}
