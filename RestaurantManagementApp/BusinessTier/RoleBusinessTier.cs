using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;
using RestaurantManagementApp.UtilityMethod;

namespace RestaurantManagementApp.BusinessTier
{
    public class RoleBusinessTier
    {
        public static string GetRoleNameByRoleID(int RoleID)
        {
            return RoleDataTier.GetRoleNameByID(RoleID);
        }

        public static int GetRoleIDByRoleName(string RoleName)
        {
            return RoleDataTier.GetRoleIDByName(RoleName);
        }

        public static string GetUserRoleName(string username, string password)
        {
            User user = UserDataTier.GetUserByUsernameAndPassword(username, Utility.MD5Hash(password));
            if (user == null)
            {
                return string.Empty;
            }
            else
            {
                return RoleDataTier.GetRoleNameByID(Convert.ToInt32(user.RoleID));
            }
        }

        public static List<Role> GetRoles()
        {
            return RoleDataTier.GetAllRoles();
        }
    }
}
