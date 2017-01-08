using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace CodeHelpers.System.Collections
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(DictionaryReadOnlyDebugView<,>))]
	public class DictionaryReadOnly<TKey, TValue> : IDictionary<TKey, TValue>,
		ICollection
	{
		#region Private Fields

		private readonly IDictionary<TKey, TValue> source;

		private object syncRoot;

		#endregion Private Fields

		#region Public Constructors

		public DictionaryReadOnly(IDictionary<TKey, TValue> dictionaryToWrap)
		{
			if (dictionaryToWrap == null)
			{
				throw new ArgumentNullException(nameof(dictionaryToWrap));
			}

			this.source = dictionaryToWrap;
		}

		#endregion Public Constructors

		#region Public Properties

		public int Count
		{
			get { return this.source.Count; }
		}

		public ICollection<TKey> Keys
		{
			get { return this.source.Keys; }
		}

		public ICollection<TValue> Values
		{
			get { return this.source.Values; }
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
		{
			get { return true; }
		}

		bool ICollection.IsSynchronized
		{
			get { return false; }
		}

		object ICollection.SyncRoot
		{
			get
			{
				if (this.syncRoot == null)
				{
					ICollection collection = this.source as ICollection;

					if (collection != null)
					{
						this.syncRoot = collection.SyncRoot;
					}
					else
					{
						Interlocked.CompareExchange(ref this.syncRoot, new object(), null);
					}
				}

				return this.syncRoot;
			}
		}

		#endregion Public Properties

		#region Public Indexers

		public TValue this[TKey key]
		{
			get { return this.source[key]; }
			set { ThrowNotSupportedException(); }
		}

		#endregion Public Indexers

		#region Public Methods

		public bool ContainsKey(TKey key)
		{
			return this.source.ContainsKey(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.source.TryGetValue(key, out value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(
							KeyValuePair<TKey, TValue> item)
		{
			ThrowNotSupportedException();
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			ThrowNotSupportedException();
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			ThrowNotSupportedException();
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(
			KeyValuePair<TKey, TValue> item)
		{
			ICollection<KeyValuePair<TKey, TValue>> collection = this.source;

			return collection.Contains(item);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			ICollection collection =
				new List<KeyValuePair<TKey, TValue>>(this.source);

			collection.CopyTo(array, index);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(
			KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			ICollection<KeyValuePair<TKey, TValue>> collection = this.source;
			collection.CopyTo(array, arrayIndex);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.source.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>>
			IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			IEnumerable<KeyValuePair<TKey, TValue>> enumerator = this.source;

			return enumerator.GetEnumerator();
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			ThrowNotSupportedException();
			return false;
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			ThrowNotSupportedException();
			return false;
		}

		#endregion Public Methods

		#region Private Methods

		private static void ThrowNotSupportedException()
		{
			throw new NotSupportedException("This Dictionary is read-only");
		}

		#endregion Private Methods
	}
}