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
    class UserBusinessTier
    {
        public static string GetFullName(string username)
        {
            return UserDataTier.GetFullNameByUsername(username);
        }

        public static List<User> GetUsers()
        {
            return UserDataTier.GetAllUsers();
        }

        public static User GetUserByUsername(string username)
        {
            return UserDataTier.GetUserByUserName(username);
        }

        public static string LoadImage(string username)
        {
            return UserDataTier.LoadImage(username);
        }

        public static bool IsActivated(string username)
        {
            return UserDataTier.IsActivated(username);
        }

        public static bool AddUser(User user, out string error)
        {
            return UserDataTier.AddUser(user, out error);
        }

        public static bool ActiveUser(string username, bool value, string error)
        {
            return UserDataTier.ActiveUser(username, value, out error);
        }

        public static bool UpdateUser(string username, User user, out string error)
        {
            return UserDataTier.UpdateUser(username, user, out error);
        }

        public static bool DeleteUser(string username, out string error)
        {
            return UserDataTier.DeleteUser(username, out error);
        }

        public static bool IsUserExisted(string username)
        {
            return UserDataTier.IsUserExisted(username);
        }

        public static List<User> GetEmployeeList()
        {
            return UserDataTier.GetEmployeeList();
        }

        public static string GetFullNameByUserID(int UserID)
        {
            return UserDataTier.GetFullNameByUserID(UserID);
        }
    }
}
