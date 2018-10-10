using AzureDay.WebApp.Config;
using System.Threading.Tasks;
using System.Net.Mail;
using SendGrid;
using AzureDay.WebApp.Notification.Email.Model;
using AzureDay.WebApp.Notification.Email.Ext;

namespace AzureDay.WebApp.Notification.Email.Service
{
    public sealed class AttendeeNotificationService
    {
        private async Task SendEmail(SendGridMessage message)
        {
            var transportWeb = new Web(Configuration.SendGridApiKey);

            await transportWeb.DeliverAsync(message);
        }

        public async Task SendRegistrationConfirmationEmailAsync(ConfirmRegistrationMessage model)
        {
            var template = new ConfirmRegistration();
            template.ConfirmationCode = model.Token;

            var text = string.Empty; //template.TransformText();

            var message = new SendGridMessage();
            message.To = new[] { new MailAddress(model.Email, model.FullName) };
            message.Subject = $"Подтверждение регистрации на AZUREday {Configuration.Year}";
            message.Html = text;
            message.From = new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
            message.ReplyTo = new[] { new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName) };

            await SendEmail(message);
        }

        public async Task SendPaymentConfirmationEmailAsync(ConfirmPaymentModel model)
        {
            var template = new ConfirmPayment();

            var text = string.Empty; //template.TransformText();

            var message = new SendGridMessage();
            message.To = new[] { new MailAddress(model.Email, model.FullName) };
            message.Subject = $"Подтверждение оплаты билета на AZUREday {Configuration.Year}";
            message.Html = text;
            message.From = new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
            message.ReplyTo = new[] { new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName) };

            await SendEmail(message);
        }

        public async Task SendPaymentErrorEmailAsync(ErrorPaymentModel model)
        {
            var template = new ErrorPayment();

            var text = string.Empty; //template.TransformText();

            var message = new SendGridMessage();
            message.To = new[] { new MailAddress(model.Email, model.FullName) };
            message.Subject = $"Ошибка оплаты билета на AZUREday {Configuration.Year}";
            message.Html = text;
            message.From = new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
            message.ReplyTo = new[] { new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName) };

            await SendEmail(message);
        }

        public async Task SendRestorePasswordEmailAsync(RestorePasswordMessage model)
        {
            var template = new RestorePassword();
            template.ConfirmationCode = model.Token;

            var text = string.Empty; //template.TransformText();

            var message = new SendGridMessage();
            message.To = new[] { new MailAddress(model.Email, model.FullName) };
            message.Subject = $"Восстановление пароля на AZUREday {Configuration.Year}";
            message.Html = text;
            message.From = new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
            message.ReplyTo = new[] { new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName) };

            await SendEmail(message);
        }
    }
}
