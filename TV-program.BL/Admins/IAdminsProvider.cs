using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_program.BL.Admins.Entities;

namespace TV_program.BL.Admins
{
    public interface IAdminsProvider
    {
        IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null);
        AdminModel GetAdminInfo(Guid id);
    }
}
