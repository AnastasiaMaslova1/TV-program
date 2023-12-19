using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.TVShow.Entities;
using TV_program.DataAccess.Entities;
using TV_program.DataAccess;
using AutoMapper;

namespace TV_program.BL.TVShow
{
    public class TVShowProvider : ITVShowProvider
    {
        private readonly IRepository<TVShowEntity> _TVShowRepository;
        private readonly IMapper _mapper;

        public TVShowProvider(IRepository<TVShowEntity> TVShowRepository, IMapper mapper)
        {
            _TVShowRepository = TVShowRepository;
            _mapper = mapper;
        }

        public IEnumerable<TVShowModel> GetTVShow(TVShowModelFilter modelFilter = null)
        {
            var title = modelFilter.Title;
            var durationInMinutes = modelFilter.DurationInMinutes;
            var idChannel = modelFilter.IdChannel;
            var broadcastDate = modelFilter.BroadcastDate;
            var broadcastTime = modelFilter.BroadcastTime;

            var products = _TVShowRepository.GetAll(x =>
            (title == null || title == x.Title) &&
            (durationInMinutes == 0 || durationInMinutes == x.DurationInMinutes) &&
            (idChannel == 0 || idChannel == x.IdChannel) &&
            (broadcastDate == null || broadcastDate == x.BroadcastDate) &&
            (broadcastTime == null || broadcastTime == x.BroadcastTime));



            return _mapper.Map<IEnumerable<TVShowModel>>(products);
        }

        public TVShowModel GetTVShowInfo(Guid id)
        {
            var product = _TVShowRepository.GetById(id);
            if (product is null)
                throw new ArgumentException("TVShow not found.");

            return _mapper.Map<TVShowModel>(product);
        }
    }
}
