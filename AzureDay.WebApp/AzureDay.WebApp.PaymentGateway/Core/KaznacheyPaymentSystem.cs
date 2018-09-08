using System;
using System.Globalization;
using RestSharp;

namespace AzureDay.WebApp.PaymentGateway.Core
{
    /// <summary>
    /// Kaznachey service client implementation
    /// </summary>
    public class KaznacheyPaymentSystem: IPaymentSystem
    {
        public static readonly string ApiUrl = "https://api.assetpayments.com/api/PaymentInterface";

		private readonly Guid _merchantGuid;
        private readonly string _merchantSecretKey;
        private readonly string _baseUrl;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="merchantGuid">Merchant GUID</param>
        /// <param name="merchantSecretKey">Merchant secret key</param>
        public KaznacheyPaymentSystem(Guid merchantGuid, string merchantSecretKey)
            : this(merchantGuid, merchantSecretKey, ApiUrl) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="merchantGuid">Merchant GUID</param>
        /// <param name="merchantSecretKey">Mechant secret key</param>
        /// <param name="apiUrl">Api url</param>
        private KaznacheyPaymentSystem(Guid merchantGuid, string merchantSecretKey, string apiUrl)
        {
            _merchantGuid = merchantGuid;
            _merchantSecretKey = merchantSecretKey;
            _baseUrl = apiUrl;
        }

        /// <summary>
        /// Gets merchants payment system information
        /// </summary>
        /// <returns>MerchantInfoResponse represents payment systems information</returns>
        public MerchantInfoResponse GetMerchantInformation()
        {
            var signature = (_merchantGuid.ToString("D") + _merchantSecretKey).ToUpper().GetMd5Hash();
            var request = CreateRequest("GetMerchatInformation");
            request.AddParameter("MerchantGuid", _merchantGuid);
            request.AddParameter("Signature", signature);

            return Execute<MerchantInfoResponse>(request);
        }

        private static IRestRequest CreateRequest(string resource)
        {
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.POST,
                RequestFormat = DataFormat.Json,
                JsonSerializer = { ContentType = "application/json; charset=utf-8" }
            };
            return request;
        }

        private T Execute<T>(IRestRequest request) where T : new()
        {
            var client = new RestClient(_baseUrl);

            var response = client.Execute<T>(request);

	        if (response.ErrorException == null)
	        {
		        return response.Data;
	        }

	        const string message = "Error retrieving response. Check inner details for more info.";
            throw new ApplicationException(message, response.ErrorException);
        }

        /// <summary>
        /// Send request create payment 
        /// </summary>
        /// <param name="payment">Payment information</param>
        /// <returns>CreatePaymentResponse represent object from service</returns>
        public CreatePaymentResponse CreatePayment(PaymentRequest payment)
        {
            var signature = CalculatePaymentSignature(payment);

            var request = CreateRequest("CreatePaymentEx");
            request.AddBody(new
            {
                payment.SelectedPaySystemId,
                payment.Products,
                PaymentDetails = payment.PaymentDetail,
                MerchantGuid = _merchantGuid,
                Signature = signature,
                Currency = payment.Currency,
                Language = payment.Language
            });

            return Execute<CreatePaymentResponse>(request);
        }

        /// <summary>
        /// Check responce from Kaznachey server api
        /// </summary>
        /// <param name="response">Payment responce object</param>
        /// <returns>True if signature valid, false - otherwise</returns>
        public bool ValidateResponse(PaymentResponse response)
        {
            var sourceStr = response.ErrorCode.ToString(CultureInfo.InvariantCulture) 
                + response.OrderId
                + response.MerchantInternalPaymentId
                + response.MerchantInternalUserId
                + response.OrderSum.ToString("0.00", CultureInfo.InvariantCulture)
                + response.Sum.ToString("0.00", CultureInfo.InvariantCulture)
                + response.Currency.ToUpper()
                + response.CustomMerchantInfo
                + _merchantSecretKey.ToUpper();
            return sourceStr.GetMd5Hash() == response.SignatureEx;
        }

        private string CalculatePaymentSignature(PaymentRequest payment)
        {
            var totalSumm = decimal.Zero;

            foreach (var product in payment.Products)
            {
                totalSumm += product.ProductPrice * (decimal)product.ProductItemsNum;
            }

            var signatureString = _merchantGuid.ToString("D").ToUpper()
                          + totalSumm.ToString("F2", NumberFormatInfo.InvariantInfo)
                          + payment.SelectedPaySystemId
                          + payment.PaymentDetail.EMail
                          + payment.PaymentDetail.PhoneNumber
                          + payment.PaymentDetail.MerchantInternalUserId
                          + payment.PaymentDetail.MerchantInternalPaymentId
                          + payment.Language.ToUpper()
                          + payment.Currency.ToUpper()
                          + _merchantSecretKey.ToUpper();

            return signatureString.GetMd5Hash();
        }
    }
}
