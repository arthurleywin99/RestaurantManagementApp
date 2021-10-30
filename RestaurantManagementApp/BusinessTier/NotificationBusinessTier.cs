using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementApp.Model;
using RestaurantManagementApp.DataTier;

namespace RestaurantManagementApp.BusinessTier
{
    public class NotificationBusinessTier
    {
        public static bool PushNotification(Notification notification)
        {
            return NotificationDataTier.PushNotification(notification);
        }

        public static Notification FetchNotification(string Screen)
        {
            return NotificationDataTier.FetchNotification(Screen);
        }

        public static bool ClearNotification(string Screen)
        {
            return NotificationDataTier.ClearNotification(Screen);
        }
    }
}
