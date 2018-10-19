using AzureDay.WebApp.Config;

namespace Microsoft.AspNetCore.Authentication
{
    public class AzureAdB2COptions
    {
        public const string PolicyAuthenticationProperty = "Policy";

        private string _clientId;
        public string ClientId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_clientId))
                {
                    _clientId = Configuration.ADB2C_ClientId;
                    if (string.IsNullOrWhiteSpace(_clientId))
                    {
                        _clientId = "4206e3b6-911c-4421-bf23-3b5d8652568d";
                    }
                }

                return _clientId;
            }
        }

        public string Instance { get; set; }

        public string Domain { get; set; }

        public string EditProfilePolicyId { get; set; }

        public string SignUpSignInPolicyId { get; set; }

        public string ResetPasswordPolicyId { get; set; }

        public string CallbackPath { get; set; }

        public string DefaultPolicy => SignUpSignInPolicyId;
    }
}