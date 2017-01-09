using System;
using System.ComponentModel.DataAnnotations;

namespace CodeHelpers.System.ComponentModel.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class DateTimeFormatValidation : DataTypeAttribute
	{
		#region Public Fields

		public const string DATE_TIME_FORMAT = "yyyy-MM-dd hh:mm:ss tt";

		public const string IS_VALID_ERROR_MESSAGE = " ليس بالشكل الصحيح، عليك إعتماد هذا الشكل 2016-09-30 06:26:35 am";

		#endregion Public Fields

		#region Public Constructors

		public DateTimeFormatValidation() : base(DataType.DateTime)
		{
		}

		#endregion Public Constructors

		#region Public Methods

		public override string FormatErrorMessage(string name)
		{
			return string.Format("{0}{1}", name, IS_VALID_ERROR_MESSAGE);
		}

		public override bool IsValid(object value)
		{
			return ((value != null) && (value is DateTime));
		}

		#endregion Public Methods
	}
}