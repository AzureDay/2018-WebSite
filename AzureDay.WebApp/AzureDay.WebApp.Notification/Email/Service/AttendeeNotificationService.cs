using System.Net.Mail;
using System.Threading.Tasks;
using AzureDay.WebApp.Config;
using SendGrid;
using SendGrid.Helpers.Mail;
using TeamSpark.AzureDay.WebSite.Notification.Email.Model;
using TeamSpark.AzureDay.WebSite.Notification.Email.Template;

namespace TeamSpark.AzureDay.WebSite.Notification.Email.Service
{
	public sealed class AttendeeNotificationService
	{
		private async Task SendEmail(SendGridMessage message)
		{
			var sendgrid = new SendGridClient(Configuration.SendGridApiKey);

			await sendgrid.SendEmailAsync(message);
		}

		public async Task SendRegistrationConfirmationEmailAsync(ConfirmRegistrationMessage model)
		{
			var template = new ConfirmRegistration();
			template.ConfirmationCode = model.Token;

			var text = template.TransformText();

			var message = new SendGridMessage();
			message.AddTo(model.Email, model.FullName);
			message.Subject = $"Подтверждение регистрации на AZUREday {Configuration.Year}";
			message.HtmlContent = text;
			message.From = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
			message.ReplyTo = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);

			await SendEmail(message);
		}

		public async Task SendPaymentConfirmationEmailAsync(ConfirmPaymentModel model)
		{
			var template = new ConfirmPayment();
			
			var text = template.TransformText();

			var message = new SendGridMessage();
			message.AddTo(model.Email, model.FullName);
			message.Subject = $"Подтверждение оплаты билета на AZUREday {Configuration.Year}";
			message.HtmlContent = text;
			message.From = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
			message.ReplyTo = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);

			await SendEmail(message);
		}

		public async Task SendPaymentErrorEmailAsync(ErrorPaymentModel model)
		{
			var template = new ErrorPayment();

			var text = template.TransformText();

			var message = new SendGridMessage();
			message.AddTo(model.Email, model.FullName);
			message.Subject = $"Ошибка оплаты билета на AZUREday {Configuration.Year}";
			message.HtmlContent = text;
			message.From = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
			message.ReplyTo = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);

			await SendEmail(message);
		}

		public async Task SendRestorePasswordEmailAsync(RestorePasswordMessage model)
		{
			var template = new RestorePassword();
			template.ConfirmationCode = model.Token;

			var text = template.TransformText();

			var message = new SendGridMessage();
			message.AddTo(model.Email, model.FullName);
			message.Subject = $"Восстановление пароля на AZUREday {Configuration.Year}";
			message.HtmlContent = text;
			message.From = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
			message.ReplyTo = new EmailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);

			await SendEmail(message);
		}
	}
}
