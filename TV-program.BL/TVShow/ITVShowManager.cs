using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.TVShow.Entities;

namespace TV_program.BL.TVShow
{
    public interface ITVShowManager
    {
        TVShowModel CreateTVShow(CreateTVShowModel model);
        void DeleteTVShow(Guid id);
        TVShowModel UpdateTVShow(Guid id, UpdateTVShowModel model);
    }
}
