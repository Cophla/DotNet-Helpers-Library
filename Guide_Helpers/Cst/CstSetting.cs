using System.Configuration;

namespace GuideHelpers.CstSetting
{
	namespace ApplicationName
	{
		
		
		public static class AppSeting
		{
			#region Public Properties

			
			
			public static int AppExampleValue
			{
				get
				{
					return int.Parse(
						ConfigurationManager.AppSettings[AppExampleValue]
					);
				}
			}

			#endregion Public Properties
		}
	}
}