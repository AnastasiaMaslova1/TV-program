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
    public class TVShowManager : ITVShowManager
    {
        private readonly IRepository<TVShowEntity> _TVShowRepository;
        private readonly IMapper _mapper;
        public TVShowManager(IRepository<TVShowEntity> TVShowRepository, IMapper mapper)
        {
            _TVShowRepository = TVShowRepository;
            _mapper = mapper;
        }

        public TVShowModel CreateTVShow(CreateTVShowModel model)
        {
            var entity = _mapper.Map<TVShowEntity>(model);

            _TVShowRepository.Save(entity);

            return _mapper.Map<TVShowModel>(entity);
        }
        public void DeleteTVShow(Guid id)
        {
            var entity = _TVShowRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("TVShow not found");
            _TVShowRepository.Delete(entity);
        }
        public TVShowModel UpdateTVShow(Guid id, UpdateTVShowModel model)
        {
            var entity = _TVShowRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("TVShow not found");
            entity.Title = model.Title;
            entity.Desctiption = model.Desctiption;
            entity.DurationInMinutes = model.DurationInMinutes;
            entity.BroadcastDate = model.BroadcastDate;
            entity.BroadcastTime = model.BroadcastTime;
            _TVShowRepository.Save(entity);
            return _mapper.Map<TVShowModel>(entity);
        }
    }
}
