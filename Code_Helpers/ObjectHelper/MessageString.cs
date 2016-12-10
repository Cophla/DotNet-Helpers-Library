using System;
using System.Globalization;
using System.Text;

namespace Code_Helpers.ObjectHelper
{
	public class MessageString : IDisposable
	{
		protected StringBuilder messageBuilder = new StringBuilder();

		public MessageString()
		{
		}

		public MessageString(int capacity)
		{
			messageBuilder.Capacity = capacity;
		}

		public MessageString Append<T>(T value)
		{
			messageBuilder.Append(value);
			return this;
		}

		public MessageString Append(string value)
		{
			return Append<string>(value);
		}

		public MessageString AppendFormat(string format, params object[] args)
		{
			messageBuilder.AppendFormat(CultureInfo.InvariantCulture, format, args);
			return this;
		}

		public MessageString Clear()
		{
			messageBuilder.Clear();
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

		public MessageString AppendLine<T>(T value)
		{
			Append<T>(value);
			AppendLine();
			return this;
		}

		public int EnsureCapacity(int capacity)
		{
			return messageBuilder.EnsureCapacity(capacity);
		}

		public override string ToString()
		{
			return messageBuilder.ToString();
		}

		public string ToString(int startIndex, int length)
		{
			return messageBuilder.ToString(startIndex, length);
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

		public MessageString Remove(int startIndex, int length)
		{
			messageBuilder.Remove(startIndex, length);
			return this;
		}

		public MessageString Insert<T>(int index, T value)
		{
			messageBuilder.Insert(index, value);
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

		public int MaxCapacity
		{
			get { return messageBuilder.MaxCapacity; }
		}

		public int Length
		{
			get { return messageBuilder.Length; }
			set { messageBuilder.Length = value; }
		}

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		private void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					messageBuilder.Clear();
					messageBuilder = null;
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~MessageString() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion IDisposable Support
	}
}