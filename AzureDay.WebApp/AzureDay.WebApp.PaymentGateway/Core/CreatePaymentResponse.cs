using System;
using System.Text;

namespace AzureDay.WebApp.PaymentGateway.Core
{
    /// <summary>
    /// Represent response from CreatePayment operation
    /// </summary>
    public class CreatePaymentResponse: BaseResponse
    {
        public string ExternalForm { get; set; }

	    public string ExternalFormHtml
		{
		    get
		    {
				byte[] data = Convert.FromBase64String(ExternalForm);
			    string decodedString = Encoding.UTF8.GetString(data);

			    return decodedString;
		    }
	    }
    }
}
