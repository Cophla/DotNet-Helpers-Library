using System;
using CodeHelpers.ModelHelper.NoneStatic;

namespace MVCHelpers.System.Web.Mvc
{
	public class GViewsModel : GlobalModel
	{
		public GViewsModel() : this(typeof(GViewsModel)) { }
		protected GViewsModel(Type type): base(type) { }
	}
}