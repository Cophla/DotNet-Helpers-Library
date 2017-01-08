using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelpers.System.Collections
{
	public class PointerQueue<T>
	{

		private class QueueNode<T>
		{
			private QueueNode<T> _firstNode;

			public QueueNode<T> FirstNode
			{
				get { return _firstNode; }
				set { _firstNode = value; }
			}

			private QueueNode<T> _lastNode;

			public QueueNode<T> LastNode
			{
				get { return _lastNode; }
				set { _lastNode = value; }
			}

		}
	}
}
