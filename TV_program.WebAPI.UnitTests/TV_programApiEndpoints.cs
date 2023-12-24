using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_program.WebAPI.UnitTests
{
    public static class TV_programApiEndpoints
    {
        public const string AuthorizeUserEndpoint = "auth/login";
        public const string RegisterUserEndpoint = "auth/register";
        public const string GetAllAdminsEndpoint = "admins";
        public const string GetAllTVShowEndpoint = "shows";
    }
}
