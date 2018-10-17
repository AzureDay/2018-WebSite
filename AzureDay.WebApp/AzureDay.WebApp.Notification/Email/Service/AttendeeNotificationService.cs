using AzureDay.WebApp.Config;
using System.Threading.Tasks;
using System.Net.Mail;
using SendGrid;
using AzureDay.WebApp.Notification.Email.Model;
using AzureDay.WebApp.Notification.Email.Ext;
using AzureDay.WebApp.Notification.Email.Template;

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

            var text = new ConfirmRegistrationTemplate().GetTemplate(template);

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

            var text = new ConfirmPaymentTemplate().GetTemplate(template);

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

            var text = new ErrorPaymentTemplate().GetTemplate(template);

            var message = new SendGridMessage();
            message.To = new[] { new MailAddress(model.Email, model.FullName) };
            message.Subject = $"Ошибка оплаты билета на AZUREday {Configuration.Year}";
            message.Html = text;
            message.From = new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
            message.ReplyTo = new[] { new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName) };

            await SendEmail(message);
        }
    }
}