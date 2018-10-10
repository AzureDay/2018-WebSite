using AzureDay.WebApp.Notification.Email.Ext;

namespace AzureDay.WebApp.Notification.Email.Template
{
    public sealed class RestorePasswordTemplate
    {
        public static string Text =>
                            @"<html>
                            <head>
                                <meta http-equiv=""Content-Type"" content=""text/html;charset=utf-8"" />
                            </head>
                            <body>
                                <div style=""font-family:Tahoma,Geneva,sans-serif;color:#f90;font-size:1.3em;font-weight:bold;padding-bottom:10px;"">Восстановление пароля</div>
                                <p style=""font-family:Tahoma,Geneva,sans-serif;"">
                                    Для смены пароля вашей учатной записи, пройдите по этой <a style=""color:#090;font-weight:bold;"" target=""_blank"" href=""{host}/Redirect?QuickAuthToken={confirmationCode}&RedirectUrl={host}/Profile/My""> ссылке</a>.
                                </p>
                            </body>
                            </html>";

        public string GetTemplate(RestorePassword restorePassword)
        {
            return Text.Replace("{host}", restorePassword.Host).Replace("{confirmationCode}", restorePassword.ConfirmationCode);
        }
    }
}
