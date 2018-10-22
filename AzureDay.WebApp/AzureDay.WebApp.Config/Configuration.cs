using System;
using Microsoft.Extensions.Configuration;

namespace AzureDay.WebApp.Config
{
	public static class Configuration
	{
		private static IConfiguration _config;

		public static void SetConfiguration(IConfiguration configuration)
		{
			_config = configuration;
		}

		#region general

		public static string Year => "2018";
		public static string Host => "https://azureday.net";

		#endregion

		#region cdn

		public static string CdnEndpointWeb => GetConfigVariable("CdnEndpointWeb");

		public static string CdnEndpointStorage => GetConfigVariable("CdnEndpointStorage");

		#endregion

		#region azure storage

		public static string AzureStorageAccountName => _config["AzureStorageAccountName"];
		public static string AzureStorageAccountKey => _config["AzureStorageAccountKey"];

		#endregion

		#region application insight

		public static string ApplicationInsightInstrumentationKey => GetConfigVariable("ApplicationInsightInstrumentationKey");
		public static string ApplicationInsightEnvironmentTag => GetConfigVariable("ApplicationInsightEnvironmentTag");

		#endregion

		#region sendgrid

		public static string SendGridApiKey => GetConfigVariable("SendGridApiKey");
		public static string SendGridFromEmail => GetConfigVariable("SendGridFromEmail");
		public static string SendGridFromName => GetConfigVariable("SendGridFromName");

		#endregion

		#region kaznachey

		public static Guid KaznacheyMerchantId => Guid.Parse(GetConfigVariable("KaznacheyMerchantId"));
		public static string KaznacheyMerchantSecreet => GetConfigVariable("KaznacheyMerchantSecreet");

		#endregion

		#region tickets

		public static decimal TicketRegular => 750;
		public static decimal TicketWorkshop => 1750;

		#endregion

		#region ad b2c

		public static string ADB2C_ClientId => GetConfigVariable("ADB2C.ClientId");

		#endregion

		private static string GetConfigVariable(string name)
		{
			var value = Environment.GetEnvironmentVariable(name);

//			if (string.IsNullOrEmpty(value))
//			{
//				value = _config[name];
//			}

			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}

			return value;
		}
	}
}
