using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_program.BL.Users.Entities
{
    public class RegisterUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public DateTime Registration { get; set; }
        public DateTime LastEntry { get; set; }
        public string PasswordHash { get; set; }
    }
}
