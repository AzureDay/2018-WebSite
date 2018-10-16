using System;
using TeamSpark.AzureDay.WebSite.Notification.Email.Service;

namespace TeamSpark.AzureDay.WebSite.Notification
{
	public static class NotificationFactory
	{
		public static readonly Lazy<AttendeeNotificationService> AttendeeNotificationService = new Lazy<AttendeeNotificationService>(() => new AttendeeNotificationService());
	}
}
