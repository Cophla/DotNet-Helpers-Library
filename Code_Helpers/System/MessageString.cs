using System;
using System.Globalization;
using System.Text;

namespace CodeHelpers.System
{
	public class MessageString : IDisposable
	{
		#region Public Constructors

		public MessageString()
		{
		}

		public MessageString(int capacity)
		{
			messageBuilder.Capacity = capacity;
		}

		public MessageString(string value)
		{
			messageBuilder.Append(value);
		}

		#endregion Public Constructors

		#region Public Properties

		public int Length
		{
			get { return messageBuilder.Length; }
			set { messageBuilder.Length = value; }
		}

		public int MaxCapacity
		{
			get { return messageBuilder.MaxCapacity; }
		}

		#endregion Public Properties

		#region Public Methods

		public static implicit operator string(MessageString ms)
		{
			return ms.ToString();
		}

		public static MessageString operator +(MessageString ms1, MessageString ms2)
		{
			MessageString ms = new MessageString(ms1.Length + ms2.Length);
			ms.Append(ms1.ToString());
			ms.Append(ms2.ToString());
			return ms;
		}

		public MessageString Append<T>(T value) where T : IConvertible
		{
			messageBuilder.Append(value);
			return this;
		}

		public MessageString Append(string value)
		{
			return Append<string>(value);
		}

		public MessageString Append(MessageString ms)
		{
			return Append(ms.ToString());
		}

		public MessageString AppendFormat(string format, params object[] args)
		{
			messageBuilder.AppendFormat(CultureInfo.InvariantCulture, format, args);
			return this;
		}

		public MessageString AppendLine()
		{
			messageBuilder.AppendLine();
			return this;
		}

		public MessageString AppendLine(string value)
		{
			messageBuilder.AppendLine(value);
			return this;
		}

		public MessageString AppendLine(MessageString ms)
		{
			messageBuilder.AppendLine(ms.ToString());
			return this;
		}

		public MessageString AppendLine<T>(T value) where T : IConvertible
		{
			Append<T>(value);
			AppendLine();
			return this;
		}

		public MessageString Clear()
		{
			messageBuilder.Clear();
			return this;
		}

		public void Dispose()
		{
			messageBuilder.Clear();
			messageBuilder = null;
		}

		public int EnsureCapacity(int capacity)
		{
			return messageBuilder.EnsureCapacity(capacity);
		}

		public bool Equals(MessageString ms)
		{
			return Equals(ms.ToString());
		}

		public bool Equals(StringBuilder sb)
		{
			return messageBuilder.Equals(sb);
		}

		public bool Equals(string value)
		{
			return Equals(new StringBuilder(value));
		}

		public MessageString Insert<T>(int index, T value)
		{
			messageBuilder.Insert(index, value);
			return this;
		}

		public MessageString Remove(int startIndex, int length)
		{
			messageBuilder.Remove(startIndex, length);
			return this;
		}

		public MessageString Replace(char oldChar, char newChar)
		{
			messageBuilder.Replace(oldChar, newChar);
			return this;
		}

		public MessageString Replace(string oldValue, string newValue)
		{
			messageBuilder.Replace(oldValue, newValue);
			return this;
		}

		public MessageString Replace(char oldChar, char newChar, int startIndex, int count)
		{
			messageBuilder.Replace(oldChar, newChar, startIndex, count);
			return this;
		}

		public MessageString Replace(string oldValue, string newValue, int startIndex, int count)
		{
			messageBuilder.Replace(oldValue, newValue, startIndex, count);
			return this;
		}

		public override string ToString()
		{
			return messageBuilder.ToString();
		}

		public string ToString(int startIndex, int length)
		{
			return messageBuilder.ToString(startIndex, length);
		}

		#endregion Public Methods

		#region Protected Fields

		protected StringBuilder messageBuilder = new StringBuilder();

		#endregion Protected Fields
	}
}