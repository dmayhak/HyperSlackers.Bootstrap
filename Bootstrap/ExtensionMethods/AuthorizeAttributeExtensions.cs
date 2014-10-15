using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class AuthorizeAttributeExtensions
    {
        public static bool IsAuthorized(this AuthorizeAttribute authorizeAttribbute, IPrincipal user)
        {
            Contract.Requires<ArgumentNullException>(authorizeAttribbute != null, "authorizeAttribbute");
            Contract.Requires<ArgumentNullException>(user != null, "user");

            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }

            var users = authorizeAttribbute.Users.SplitString();

            if (users.Length > 0 && users.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }

            var roles = authorizeAttribbute.Roles.SplitString();

            if (roles.Length > 0 && roles.Any(user.IsInRole))
            {
                return true;
            }

            return false;
        }
    }
}
