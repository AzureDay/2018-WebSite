namespace AzureDay.WebApp.PaymentGateway.Core
{
    /// <summary>
    /// Base information object
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Error code. 0 - if success, otherwise - fail
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Debug message information.
        /// </summary>
        public string DebugMessage { get; set; }
    }
}