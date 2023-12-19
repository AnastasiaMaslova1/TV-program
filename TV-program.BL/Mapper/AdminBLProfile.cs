using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.Admins.Entities;
using TV_program.DataAccess.Entities;
using AutoMapper;

namespace TV_program.BL.Mapper
{
    public class AdminBLProfile : Profile
    {
        public AdminBLProfile()
        {
            CreateMap<AdminEntity, AdminModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateAdminModel, AdminEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
