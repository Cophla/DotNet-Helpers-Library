using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Code_Helpers.System.Collections
{
	/// <summary>
	/// </summary>
	/// <typeparam name="TKey">
	/// </typeparam>
	/// <typeparam name="TValue">
	/// </typeparam>
	internal sealed class DictionaryReadOnlyDebugView<TKey, TValue>
	{
		/// <summary>
		/// </summary>
		/// <param name="dictionary">
		/// </param>
		public DictionaryReadOnlyDebugView(
			DictionaryReadOnly<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException(nameof(dictionary));
			}

			dict = dictionary;
		}

		/// <summary>
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyValuePair<TKey, TValue>[] Items {
			get {
				KeyValuePair<TKey, TValue>[] array =
					new KeyValuePair<TKey, TValue>[dict.Count];
				dict.CopyTo(array, 0);
				return array;
			}
		}

		/// <summary>
		/// </summary>
		private IDictionary<TKey, TValue> dict;
	}
}