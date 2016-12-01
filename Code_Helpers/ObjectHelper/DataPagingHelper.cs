using System;

namespace Code_Helpers.ObjectHelper
{
	public class DataPagingHelper
	{
		public DataPagingHelper(int totalItems, int? page, int pageSize = 10)
		{
			// calculate total, start and end pages
			var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
			var currentPage = page != null ? (int)page : 1;
			var startPage = currentPage - 5;
			var endPage = currentPage + 4;
			if (startPage <= 0)
			{
				endPage -= (startPage - 1);
				startPage = 1;
			}
			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			TotalItems = totalItems;
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
		}


		#region Public Properties

		/// <summary>
		/// </summary>
		public int CurrentPage { get; private set; }

		/// <summary>
		/// </summary>
		public int EndPage { get; private set; }

		/// <summary>
		/// </summary>
		public int PageSize { get; private set; }

		/// <summary>
		/// </summary>
		public int StartPage { get; private set; }

		/// <summary>
		/// </summary>
		public int TotalItems { get; private set; }

		/// <summary>
		/// </summary>
		public int TotalPages { get; private set; }

		#endregion Public Properties
	}
}