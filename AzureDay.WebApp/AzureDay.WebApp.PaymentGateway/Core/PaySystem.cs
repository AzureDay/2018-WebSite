namespace AzureDay.WebApp.PaymentGateway.Core
{
    /// <summary>
    /// Payment system information
    /// </summary>
    public class PaySystem
    {
        /// <summary>
        /// Payment system Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Payment system name
        /// </summary>
        public string PaySystemName { get; set; }


        /// <summary>
        /// Payment system tag(use for css style). Sample: webMoney,VisaMc,liqPay, etc
        /// </summary>
        public string PaySystemTag { get; set; }
    }
}
