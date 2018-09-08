namespace AzureDay.WebApp.PaymentGateway.Core
{
    /// <summary>
    /// PaymentResponse represent information about payment processing
    /// </summary>
    public class PaymentResponse: BaseResponse
    {
        public PaymentResponse()
        {
            Currency = "UAH";
        }

        /// <summary>
        /// Order id 
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Merchant internal payment id
        /// </summary>
        public string MerchantInternalPaymentId { get; set; }

        /// <summary>
        /// Merchant user internal id 
        /// </summary>
        public string MerchantInternalUserId { get; set; }

        /// <summary>
        /// Sum
        /// </summary>
        public decimal Sum { get; set; }


        /// <summary>
        /// Sum of merchant order
        /// </summary>
        public decimal OrderSum { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Custom merchant info
        /// </summary>
        public string CustomMerchantInfo { get; set; }

        /// <summary>
        /// Should be validated. Example:
        /// 
        ///        Request.ErrorCode.ToString(CultureInfo.InvariantCulture)
        ///              + Request.OrderId
        ///              + Request.MerchantInternalPaymentId
        ///              + Request.MerchantInternalUserId
        ///              + Request.OrderSum.ToString('N')
        ///              + Request.Sum.ToString('N')
        ///              + Request.Currency.ToUpper()
        ///              + Request.CustomMerchantInfo
        ///              + MerchantSecretKey.ToString().ToUpper();
        /// </summary>
        public string SignatureEx { get; set; }
    }
}
