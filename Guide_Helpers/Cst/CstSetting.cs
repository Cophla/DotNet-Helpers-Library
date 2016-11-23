using System.Configuration;
using Code_Helpers;

namespace Guide_Helpers.CstSetting
{
	namespace ApplicationName
	{
		/// <summary>
		/// </summary>
		public static class AppSeting
		{
			/// <summary>
			/// </summary>
			public static int AppExampleValue {
				get {
					return SCode.ConvertAs<int>(
						ConfigurationManager.AppSettings[AppExampleValue]
					);
				}
			}
		}
	}
}