using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystem.Services
{
    public class UserRoles
    {
        public static string CUSTOMER = "CUSTOMER";
        public static string EMPLOYEE = "EMPLOYEE";
        public static string ADMIN = "ADMIN";

        public static bool isUserRole(string text)
        {
            var roles = new List<string> {
                CUSTOMER,
                EMPLOYEE,
                ADMIN
            };
            return roles.Contains(text);
        }
    }
}
