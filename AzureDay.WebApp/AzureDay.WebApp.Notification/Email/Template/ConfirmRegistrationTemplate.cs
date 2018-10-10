using AzureDay.WebApp.Notification.Email.Ext;

namespace AzureDay.WebApp.Notification.Email.Template
{
    public sealed class ConfirmRegistrationTemplate
    {
        public static string Text =>
                            @"<html>
                            <head>
                                <meta http-equiv=""Content-Type"" content=""text/html;charset=utf-8"" />
                            </head>
                            <body>
                                <div style=""font-family:Tahoma,Geneva,sans-serif;color:#f90;font-size:1.3em;font-weight:bold;padding-bottom:10px;"">Подтверждение регистрации</div>
                                <p style=""font-family:Tahoma,Geneva,sans-serif;"">
                                    Пожалуйста, подтвердите ваш адрес электронной почты для регистрации на AzureDay, пройдя по этой<a style=""color:#090;font-weight:bold;""target=""blank"" href=""{host}/Profile/ConfirmRegistration/{confirmationCode}"">ссылке</a>.
                                </p>
                            </body>
                            </html>";

        public string GetTemplate(ConfirmRegistration confirmRegistration)
        {
            return Text.Replace("{host}", confirmRegistration.Host).Replace("{confirmationCode}", confirmRegistration.ConfirmationCode);
        }
    }
}