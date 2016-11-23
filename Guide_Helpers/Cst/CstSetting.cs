using Code_Helpers;
using System.Configuration;

namespace Guide_Helpers.CstSetting
{
	namespace ApplicationName
	{
		/// <summary>
		/// </summary>
		public static class AppSeting
		{
			#region Public Properties

			/// <summary>
			/// </summary>
			public static int AppExampleValue {
				get {
					return SCode.ConvertAs<int>(
						ConfigurationManager.AppSettings[AppExampleValue]
					);
				}
			}

			#endregion Public Properties
		}
	}
}