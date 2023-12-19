using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.Users.Entities;
using TV_program.DataAccess.Entities;
using TV_program.DataAccess;
using AutoMapper;

namespace TV_program.BL.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IRepository<UserEntity> _usersRepository;
        private readonly IMapper _mapper;
        public UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public UserModel CreateUser(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            _usersRepository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }
        public void DeleteUser(Guid id)
        {
            var entity = _usersRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("User not found");
            _usersRepository.Delete(entity);
        }
        public UserModel UpdateUser(Guid id, UpdateUserModel model)
        {
            var entity = _usersRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("User not found");
            entity.PasswordHash = model.PasswordHash;
            entity.Username = model.Username;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            _usersRepository.Save(entity);
            return _mapper.Map<UserModel>(entity);
        }
    }
}
