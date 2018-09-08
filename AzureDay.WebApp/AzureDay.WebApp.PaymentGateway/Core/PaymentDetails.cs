namespace AzureDay.WebApp.PaymentGateway.Core
{
    /// <summary>
    /// Payment details
    /// </summary>
    public class PaymentDetails
    {
        /// <summary>
        /// Merchant cms internal payment id
        /// </summary>
        public string MerchantInternalPaymentId { get; set; }

        /// <summary>
        /// Merchant internal user id
        /// </summary>
        public string MerchantInternalUserId { get; set; }

        /// <summary>
        /// Client email. Required
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Client phone number. Required
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Merchant cms custom information
        /// </summary>
        public string CustomMerchantInfo { get; set; }

        /// <summary>
        /// Status URL. Used for status delivery
        /// </summary>
        public string StatusUrl { get; set; }

        /// <summary>
        /// Return Url. User will be redirected here after payment processing
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Delivery Type from cart
        /// </summary>
        public string DeliveryType { get; set; }

        public string BuyerLastname { get; set; }
        public string BuyerFirstname { get; set; }
        public string BuyerPatronymic { get; set; }
        public string BuyerStreet { get; set; }
        public string BuyerCity { get; set; }
        public string BuyerZone { get; set; }
        public string BuyerZip { get; set; }
        public string BuyerCountry { get; set; }

        public string DeliveryLastname { get; set; }
        public string DeliveryFirstname { get; set; }
        public string DeliveryPatronymic { get; set; }
        public string DeliveryStreet { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryZone { get; set; }
        public string DeliveryZip { get; set; }
        public string DeliveryCountry { get; set; }
    }
}
