using AutoMapper;
using TV_program.BL.TVShow.Entities;
using TV_program.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_program.BL.Mapper
{
    public class TVShowBLProfile : Profile
    {
        public TVShowBLProfile()
        {
            CreateMap<TVShowEntity, TVShowModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
                .ForMember(x => x.Title, y => y.MapFrom(src => src.Title));

            CreateMap<CreateTVShowModel, TVShowEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.Title, y => y.MapFrom(src => src.Title))
                .ForMember(x => x.Desctiption, y => y.MapFrom(src => src.Desctiption));
        }
    }
}
