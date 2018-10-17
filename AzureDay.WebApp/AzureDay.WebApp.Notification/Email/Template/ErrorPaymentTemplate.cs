using AzureDay.WebApp.Notification.Email.Ext;

namespace AzureDay.WebApp.Notification.Email.Template
{
    public sealed class ErrorPaymentTemplate
    {
        public static string Text =>
                            @"<html>
                            <head>
                                <meta http-equiv=""Content-Type"" content=""text/html;charset=utf-8"" />
                            </head>
                            <body>
                                <div style=""font-family:Tahoma,Geneva,sans-serif;color:#f90;font-size:1.3em;font-weight:bold;padding-bottom:10px;"">Ошибка оплаты</div>
                                <p style=""font-family:Tahoma,Geneva,sans-serif;"">
                                    Простите, но в момент оплаты произошла ошибка. Возможно, на карте было недостаточно денег для проведения оплаты. Попробуйте повторить оплату.
                                </p>
                                <p style=""font-family:Tahoma,Geneva,sans-serif;padding-top:20px;"">
                                    Если у вас есть вопросы по оплате, то, пожалуйста, свяжитесь с организаторами конференции.
                                </p>
                            </body>
                            </html>";

        public string GetTemplate(ErrorPayment errorPayment)
        {
            return Text;
        }
    }
}
