using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TV_program.WebAPI.Mapper;

namespace TV_program.BL.UnitTests.Mapper
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(typeof(AdminsServiceProfile));
                x.AddProfile(typeof(UsersServiceProfile));
                x.AddProfile(typeof(TVShowServiceProfile));
            });
            Mapper = new AutoMapper.Mapper(config);
        }

        public static IMapper Mapper { get; }
    }
}
