using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_program.BL.Admins.Entities
{
    public class AdminModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public DateTime Registration { get; set; }
        public DateTime LastEntry { get; set; }
        public string PasswordHash { get; set; }
    }
}
