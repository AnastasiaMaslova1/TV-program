using TV_program.WebAPI.Controllers.Entities;
using AutoMapper;
using TV_program.BL.Users.Entities;

namespace TV_program.WebAPI.Mapper
{
    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile() 
        {
            CreateMap<UserFilter, UserModelFilter>();
            CreateMap<CreateUserRequest, CreateUserModel>();
            CreateMap<UpdateUserRequest, UpdateUserModel>();
        }
    }
}
