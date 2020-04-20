using Microsoft.Extensions.Logging;
using Shared.Common;
using Shared.Events.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Notifier
{
    public class NotificationController
    {
        private static NotificationController _notificationController = null;
        /// <summary>
        /// key: subscribeId;
        /// </summary>
        public ConcurrentDictionary<string, ConcurrentQueue<NotificationEvent>> NotificationDictionary { get; set; }
            = new ConcurrentDictionary<string, ConcurrentQueue<NotificationEvent>>();
        public int Limatation { get; set; } = 1;

        static NotificationController()
        {
            _notificationController = new NotificationController();
        }
        public static NotificationController GetInstance()
        {
            return _notificationController;
        }
    }
}
