using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.Users.Entities;

namespace TV_program.BL.Users
{
    public interface IUsersManager
    {
        UserModel CreateUser(CreateUserModel model);
        void DeleteUser(Guid id);
        UserModel UpdateUser(Guid id, UpdateUserModel model);
    }
}
