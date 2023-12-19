using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.DataAccess.Entities;

namespace TV_program.BL.TVShow.Entities
{
    public class TVShowModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime BroadcastDate { get; set; }
        public TimeSpan BroadcastTime { get; set; }
        public int IdChannel { get; set; }
    }
}
