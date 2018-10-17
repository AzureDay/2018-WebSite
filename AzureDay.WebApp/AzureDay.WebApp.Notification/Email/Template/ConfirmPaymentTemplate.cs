using AzureDay.WebApp.Notification.Email.Ext;

namespace AzureDay.WebApp.Notification.Email.Template
{
    public sealed class ConfirmPaymentTemplate
    {
        public static string Text =>
                        @"<html>
                            <head>
                                <meta http-equiv=""Content-Type"" content=""text/html;charset=utf-8"" />
                            </head>
                        <body>
                            <div style = ""font-family:Tahoma,Geneva,sans-serif;color:#f90;font-size:1.3em;font-weight:bold;padding-bottom:10px;"">Оплата прошла успешно</div>
                            <p style=""font-family:Tahoma,Geneva,sans-serif;"">
                                Большое спасибо, ваш платеж прошел успешно. Мы с нетерпением ждем вас на AzureDay {year}.
                            </p>
                            <p style=""font-family:Tahoma,Geneva,sans-serif;padding-top:20px;"">
                                Для того, чтобы прийти на AzureDay, вам не нужно печатать билет.
                            </p>
                            <p style=""font-family:Tahoma,Geneva,sans-serif;padding-top:20px;"">
                                Вместо этого вам необходимо запомнить, какие ФИО и какой адрес электронной почты вы вводили при регистрации на конференцию. Эту информацию вам необходимо будет предоставить при входе на конференцию.
                            </p>
                        </body>
                        </html>";

        public string GetTemplate(ConfirmPayment confirmPayment)
        {
            return Text.Replace("{year}", confirmPayment.Year);
        }
    }
}