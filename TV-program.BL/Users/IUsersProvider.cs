using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.Users.Entities;

namespace TV_program.BL.Users
{
    public interface IUsersProvider
    {
        IEnumerable<UserModel> GetUsers(UserModelFilter modelFilter = null);
        UserModel GetUserInfo(Guid id);
    }
}
