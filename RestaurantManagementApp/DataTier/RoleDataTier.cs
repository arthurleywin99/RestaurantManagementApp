using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class RoleDataTier
    {
        public static string GetRoleNameByID(int RoleID)
        {
            using (var context = new Context())
            {
                return context.Roles.FirstOrDefault(p => p.RoleID == RoleID).RoleName;
            }
        }

        public static int GetRoleIDByName(string RoleName)
        {
            using (var context = new Context())
            {
                return context.Roles.SingleOrDefault(p => p.RoleName.Equals(RoleName)).RoleID;
            }
        }

        public static List<Role> GetAllRoles()
        {
            using (var context = new Context())
            {
                return context.Roles.ToList();
            }
        }
    }
}
