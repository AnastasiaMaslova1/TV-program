using TV_program.DataAccess.Entities;

namespace TV_program.WebAPI.Controllers.Entities
{
    public class TVShowFilter
    {
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime BroadcastDate { get; set; }
        public TimeSpan BroadcastTime { get; set; }
    }
}
