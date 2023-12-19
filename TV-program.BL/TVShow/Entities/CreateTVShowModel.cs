using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_program.BL.TVShow.Entities
{
    public class CreateTVShowModel
    {
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime BroadcastDate { get; set; }
        public TimeSpan BroadcastTime { get; set; }
    }
}
