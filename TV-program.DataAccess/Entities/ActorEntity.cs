using System.ComponentModel.DataAnnotations.Schema;

namespace TV_program.DataAccess.Entities
{
    [Table("actor")]
    public class ActorEntity : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ShowActorEntity> ShowActor { get; set; }
    }
}