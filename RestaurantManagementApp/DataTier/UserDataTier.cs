using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.UtilityMethod;
namespace RestaurantManagementApp.DataTier
{
    public class UserDataTier
    {
        public static User GetUserByUsernameAndPassword(string username, string password)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(p => p.Username.Equals(username) && p.Password.Equals(password));
            }
        }

        public static string GetFullNameByUsername(string username)
        {
            using (var context = new Context())
            {
                return context.Users.SingleOrDefault(p => p.Username.Equals(username)).FullName;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (var context = new Context())
            {
                return context.Users.ToList();
            }
        }

        public static User GetUserByUserName(string username)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(p => p.Username.Equals(username));
            }
        }

        public static bool IsActivated(string username)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(p => p.Username.Equals(username)).IsActivated;
            }
        }

        public static string LoadImage(string username)
        {
            using (var context = new Context())
            {
                return context.Users.SingleOrDefault(p => p.Username.Equals(username)).Images;
            }
        }

        public static bool AddUser(User user, out string error)
        {
            using (var context = new Context())
            {
                error = string.Empty;
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool ActiveUser(string username, bool value, out string error)
        {
            using (var context = new Context())
            {
                error = string.Empty;
                try
                {
                    var user = context.Users.FirstOrDefault(p => p.Username.Equals(username));
                    user.IsActivated = value;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool UpdateUser(string username, User NewUser, out string error)
        {
            using (var context = new Context())
            {
                error = string.Empty;
                try
                {
                    var user = context.Users.FirstOrDefault(p => p.Username.Equals(username));
                    user.FullName = NewUser.FullName;
                    user.DateOfBirth = NewUser.DateOfBirth;
                    user.Gender = NewUser.Gender;
                    user.Address = NewUser.Address;
                    user.IDCard = NewUser.IDCard;
                    if (NewUser.Password != null)
                    {
                        user.Password = Utility.MD5Hash(NewUser.Password);
                    }
                    user.RoleID = NewUser.RoleID;
                    user.Images = NewUser.Images;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool DeleteUser(string username, out string error)
        {
            using (var context = new Context())
            {
                error = string.Empty;
                try
                {
                    var user = context.Users.FirstOrDefault(p => p.Username.Equals(username));
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                    return false;
                }
            }
        }

        public static bool IsUserExisted(string username)
        {
            using (var context = new Context())
            {
                return context.Users.Any(p => p.Username.ToUpper().Equals(username.ToUpper()));
            }
        }

        public static List<User> GetEmployeeList()
        {
            using (var context = new Context())
            {
                int id = RoleDataTier.GetRoleIDByName("employee");
                return context.Users.Where(p => p.RoleID == id).ToList();
            }
        }

        public static string GetFullNameByUserID(int UserID)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(p => p.UserID == UserID).FullName;
            }
        }
    }
}
