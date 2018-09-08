namespace AzureDay.WebApp.PaymentGateway.Core
{
    public interface IPaymentSystem
    {
        MerchantInfoResponse GetMerchantInformation();

        CreatePaymentResponse CreatePayment(PaymentRequest payment);

        bool ValidateResponse(PaymentResponse resp);
    }
}
