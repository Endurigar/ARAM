using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(fileName = "NotificationList", menuName = "ARAM/NotificationList")]
    public class NotificationList: ScriptableObject
    {
        public List<Notification> Notifications;

        public Notification GetNotificationByName(string name)
        {
            return Notifications.First((notification => notification.Name == name));
        }
    }
}
