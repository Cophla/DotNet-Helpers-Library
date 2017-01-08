using System;

namespace CodeHelpers.ObjectHelper
{
	public class DataPagingHelper
	{
		#region Private Fields

		private int _currentPage;

		private int _endPage;

		private int _pageSize;

		private int _startPage;

		private int _totalItems;

		private int _totalPages;

		#endregion Private Fields

		#region Public Constructors

		public DataPagingHelper(int totalItems, int? page, int pageSize = 10)
		{
			int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
			int currentPage = page ?? 1;
			int startPage = currentPage - 5;
			int endPage = currentPage + 4;

			if (startPage <= 0)
			{
				endPage -= (startPage - 1);
				startPage = 1;
			}

			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
					startPage = endPage - 9;
			}

			_totalItems = totalItems;
			_currentPage = currentPage;
			_pageSize = pageSize;
			_totalPages = totalPages;
			_startPage = startPage;
			_endPage = endPage;
		}

		#endregion Public Constructors

		#region Public Properties

		public int CurrentPage
		{
			get { return _currentPage; }
		}

		public int EndPage
		{
			get { return _endPage; }
		}

		public int PageSize
		{
			get { return _pageSize; }
		}

		public int StartPage
		{
			get { return _startPage; }
		}

		public int TotalItems
		{
			get { return _totalItems; }
		}

		public int TotalPages
		{
			get { return _totalPages; }
		}

		#endregion Public Properties
	}
}