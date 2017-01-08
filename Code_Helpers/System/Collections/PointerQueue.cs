using System;

namespace CodeHelpers.System.Collections
{
	public class PointerQueue<T> : IDisposable
	{
		#region Private Fields

		private readonly object FIRST_NODE_THREAD_LOCK = new object();

		private readonly object LAST_NODE_THREAD_LOCK = new object();

		private int _count;

		private QueueNode<T> _firstNode;

		private QueueNode<T> _lastNode;

		#endregion Private Fields

		#region Public Properties

		public int Count
		{
			get { return _count; }
		}

		public bool IsEmpty
		{
			get
			{
				if (_firstNode.IsNull())
					return true;
				return false;
			}
		}

		#endregion Public Properties

		#region Public Methods

		public void Add(T value)
		{
			if (IsEmpty)
			{
				lock (FIRST_NODE_THREAD_LOCK)
				{
					lock (LAST_NODE_THREAD_LOCK)
					{
						_firstNode = new QueueNode<T>(value);
						_lastNode = _firstNode;
						_count++;
					}
				}
				return;
			}

			lock (LAST_NODE_THREAD_LOCK)
			{
				_lastNode.NextNode = new QueueNode<T>(_lastNode, value);
				_lastNode = _lastNode.NextNode;
				_count++;
			}
		}

		public void Dispose()
		{
			while (!IsEmpty)
				ExtractFirst();
		}

		public T ExtractFirst()
		{
			if (IsEmpty)
				throw new Exception("Queue is Empty");

			T value;
			lock (FIRST_NODE_THREAD_LOCK)
			{
				value = _firstNode.NodeValue;
				lock (LAST_NODE_THREAD_LOCK)
				{
					if (_count < 2)
					{
						_firstNode.Dispose();
						_lastNode = _firstNode = null;
						_count--;
						return value;
					}
				}

				QueueNode<T> temp = _firstNode;
				_firstNode = _firstNode.NextNode;
				temp.Dispose();
				temp = null;
				_count--;
			}
			return value;
		}

		#endregion Public Methods

		#region Private Classes

		private class QueueNode<TValue> : IDisposable
		{
			#region Private Fields

			private QueueNode<TValue> _nextNode;

			private TValue _nodeValue;

			private QueueNode<TValue> _prevNode;

			#endregion Private Fields

			#region Public Constructors

			public QueueNode() : this(default(TValue))
			{
			}

			public QueueNode(TValue value) : this(null, value)
			{
			}

			public QueueNode(QueueNode<TValue> prevNode, TValue value) : this(prevNode, value, null)
			{
			}

			public QueueNode(QueueNode<TValue> prevNode, TValue value, QueueNode<TValue> nextNode)
			{
				_prevNode = prevNode;
				_nodeValue = value;
				_nextNode = nextNode;
			}

			#endregion Public Constructors

			#region Public Properties

			public QueueNode<TValue> NextNode
			{
				get { return _nextNode; }
				set { _nextNode = value; }
			}

			public TValue NodeValue
			{
				get { return _nodeValue; }
			}

			public QueueNode<TValue> PrevNode
			{
				get { return _prevNode; }
				set { _prevNode = value; }
			}

			#endregion Public Properties

			#region Public Methods

			public void Dispose()
			{
				_nextNode = null;
				_prevNode = null;

				using (IDisposable myDispose = _nodeValue as IDisposable) { }

				_nodeValue = default(TValue);
			}

			#endregion Public Methods
		}

		#endregion Private Classes
	}
}