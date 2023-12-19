using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TV_program.BL.Users.Entities;
using TV_program.DataAccess.Entities;

namespace TV_program.BL.Mapper
{
    public class UserBLProfile : Profile
    {
        public UserBLProfile()
        {
            CreateMap<AdminEntity, UserModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateUserModel, UserEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
