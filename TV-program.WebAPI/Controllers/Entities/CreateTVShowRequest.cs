using System.ComponentModel.DataAnnotations;

namespace TV_program.WebAPI.Controllers.Entities
{
    public class CreateTVShowRequest
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        public string Desctiption { get; set; }

        [Required]
        public int DurationInMinutes { get; set; }

        [Required]
        public DateTime BroadcastDate { get; set; }

        [Required]
        public TimeSpan BroadcastTime { get; set; }
    }
}
