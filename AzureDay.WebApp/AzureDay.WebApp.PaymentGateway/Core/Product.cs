namespace AzureDay.WebApp.PaymentGateway.Core
{
    /// <summary>
    /// Product info
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product items num
        /// </summary>
        public decimal ProductItemsNum { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Merchants cms product unique id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Merchants cms product unique id
        /// </summary>
        public string ProductImageUrl { get; set; }
    }
}
