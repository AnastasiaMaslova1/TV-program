using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.TVShow.Entities;

namespace TV_program.BL.TVShow
{
    public interface ITVShowProvider
    {
        IEnumerable<TVShowModel> GetTVShow(TVShowModelFilter modelFilter = null);
        TVShowModel GetTVShowInfo(Guid id);
    }
}
