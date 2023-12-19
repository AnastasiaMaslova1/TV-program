using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.Admins.Entities;
using TV_program.DataAccess.Entities;
using TV_program.DataAccess;
using AutoMapper;

namespace TV_program.BL.Admins
{
    public class AdminsProvider : IAdminsProvider
    {
        private readonly IRepository<AdminEntity> _adminRepository;
        private readonly IMapper _mapper;

        public AdminsProvider(IRepository<AdminEntity> adminsRepository, IMapper mapper)
        {
            _adminRepository = adminsRepository;
            _mapper = mapper;
        }

        public IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null)
        {
            var username = modelFilter.Username;
            var phoneNumber = modelFilter.PhoneNumber;
            var email = modelFilter.Email;

            var admins = _adminRepository.GetAll(x =>
            (username == null || username == x.Username) &&
            (phoneNumber == null || phoneNumber == x.PhoneNumber) &&
            (email == null || email == x.Email));


            return _mapper.Map<IEnumerable<AdminModel>>(admins);
        }

        public AdminModel GetAdminInfo(Guid id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin is null)
                throw new ArgumentException("Admin not found.");

            return _mapper.Map<AdminModel>(admin);
        }
    }
}
