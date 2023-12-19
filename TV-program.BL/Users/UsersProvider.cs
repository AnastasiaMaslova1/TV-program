using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.DataAccess.Entities;
using TV_program.DataAccess;
using AutoMapper;
using TV_program.BL.Users.Entities;

namespace TV_program.BL.Users
{
    public class UsersProvider : IUsersProvider
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _userRepository = usersRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserModel> GetUsers(UserModelFilter modelFilter = null)
        {
            var username = modelFilter.Username;
            var phoneNumber = modelFilter.PhoneNumber;

            var users = _userRepository.GetAll(x =>
            (username == null || username == x.Username) &&
            (phoneNumber == null || phoneNumber == x.PhoneNumber));


            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public UserModel GetUserInfo(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
                throw new ArgumentException("User not found.");

            return _mapper.Map<UserModel>(user);
        }
    }
}
