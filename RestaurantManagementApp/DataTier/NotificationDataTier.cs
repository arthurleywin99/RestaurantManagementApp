using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;

namespace RestaurantManagementApp.DataTier
{
    public class NotificationDataTier
    {
        public static bool PushNotification(Notification notification)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Notifications.Add(notification);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static Notification FetchNotification(string Screen)
        {
            using (var context = new Context())
            {
                return context.Notifications.FirstOrDefault(p => p.Screen.Equals(Screen));
            }
        }

        public static bool ClearNotification(string Screen)
        {
            using (var context = new Context())
            {
                try
                {
                    var notification = context.Notifications.FirstOrDefault(p => p.Screen.Equals(Screen));
                    context.Notifications.Remove(notification);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
