using AutoMapper;
using TV_program.BL.Admins.Entities;
using TV_program.WebAPI.Controllers.Entities;

namespace TV_program.WebAPI.Mapper
{
    public class AdminsServiceProfile : Profile
    {
        public AdminsServiceProfile()
        {
            CreateMap<AdminsFilter, AdminModelFilter>();
            CreateMap<CreateAdminRequest, CreateAdminModel>();
            CreateMap<UpdateAdminRequest, UpdateAdminModel>();
        }
    }
}

