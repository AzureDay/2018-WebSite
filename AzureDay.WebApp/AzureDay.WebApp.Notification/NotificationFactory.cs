using AzureDay.WebApp.Notification.Email.Service;
using System;

namespace AzureDay.WebApp.Notification
{
    public static class NotificationFactory
    {
        public static readonly Lazy<AttendeeNotificationService> AttendeeNotificationService = new Lazy<AttendeeNotificationService>(() => new AttendeeNotificationService());
    }
}