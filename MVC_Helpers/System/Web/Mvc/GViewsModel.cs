using System;
using CodeHelpers.ModelHelper.NoneStatic;

namespace MVCHelpers.System.Web.Mvc
{
	public class GViewsModel : GlobalModel
	{
		#region Public Constructors

		public GViewsModel() : this(typeof(GViewsModel))
		{
		}

		#endregion Public Constructors

		#region Protected Constructors

		protected GViewsModel(Type type) : base(type)
		{
		}

		#endregion Protected Constructors
	}
}