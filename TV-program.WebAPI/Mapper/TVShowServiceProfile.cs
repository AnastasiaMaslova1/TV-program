using TV_program.WebAPI.Controllers.Entities;
using AutoMapper;
using TV_program.BL.TVShow.Entities;

namespace TV_program.WebAPI.Mapper
{
    public class TVShowServiceProfile : Profile
    {
        public TVShowServiceProfile() 
        {
            CreateMap<TVShowFilter, TVShowModelFilter>();
            CreateMap<CreateTVShowRequest, CreateTVShowModel>();
            CreateMap<UpdateTVShowRequest, UpdateTVShowModel>();
        }
    }
}
