using System;

namespace AzureDay.WebApp.Database.Enums
{
    [Flags]
	public enum PartnerType
	{
		VIP = 2,
		Gold = 4,
		Silver = 8,
		Bronze = 16,
		Raffle = 32,
		Info = 64,
		Speaker = 128,
		Tech = 256,
		Workshop = 512
	}

	public static class PartnerTypeExtension
	{
		public static string ToDisplayStringCategory(this PartnerType type)
		{
			switch (type)
			{
				case PartnerType.VIP:
					return Localization.Host.Views.Home.PartnerCategoryType.VIP;
				case PartnerType.Gold:
					return Localization.Host.Views.Home.PartnerCategoryType.Gold;
				case PartnerType.Silver:
					return Localization.Host.Views.Home.PartnerCategoryType.Silver;
				case PartnerType.Bronze:
					return Localization.Host.Views.Home.PartnerCategoryType.Bronze;
				case PartnerType.Raffle:
					return Localization.Host.Views.Home.PartnerCategoryType.Raffle;
				case PartnerType.Info:
					return Localization.Host.Views.Home.PartnerCategoryType.Info;
				case PartnerType.Speaker:
					return Localization.Host.Views.Home.PartnerCategoryType.Speaker;
				case PartnerType.Tech:
					return Localization.Host.Views.Home.PartnerCategoryType.Tech;
				case PartnerType.Workshop:
					return Localization.Host.Views.Home.PartnerCategoryType.Workshop;
				default:
					return string.Empty;
			}
		}

		public static string ToDisplayStringPartner(this PartnerType type)
		{
			switch (type)
			{
				case PartnerType.VIP:
					return Localization.Host.Views.Home.PartnerType.VIP;
				case PartnerType.Gold:
					return Localization.Host.Views.Home.PartnerType.Gold;
				case PartnerType.Silver:
					return Localization.Host.Views.Home.PartnerType.Silver;
				case PartnerType.Bronze:
					return Localization.Host.Views.Home.PartnerType.Bronze;
				case PartnerType.Raffle:
					return Localization.Host.Views.Home.PartnerType.Raffle;
				case PartnerType.Info:
					return Localization.Host.Views.Home.PartnerType.Info;
				case PartnerType.Speaker:
					return Localization.Host.Views.Home.PartnerType.Speaker;
				case PartnerType.Tech:
					return Localization.Host.Views.Home.PartnerType.Tech;
				case PartnerType.Workshop:
					return Localization.Host.Views.Home.PartnerType.Workshop;
				default:
					return string.Empty;
			}
		}
	}
}