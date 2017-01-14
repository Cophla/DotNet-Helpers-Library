﻿using System;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	public class TableGenericModel : GlobalModel
	{
		#region Protected Fields

		protected string _deleteStoredProcdureName;

		protected string _insertStoredProcdureName;

		protected string _selectAllStoredProcdureName;

		protected string _updateStoredProcdureName;

		#endregion Protected Fields

		#region Public Constructors

		public TableGenericModel() : this(typeof(TableGenericModel))
		{
		}

		protected TableGenericModel(Type type) : base(type)
		{
		}

		#endregion Public Constructors

		#region Public Methods

		public override void Dispose()
		{
			_deleteStoredProcdureName = null;
			_insertStoredProcdureName = null;
			_selectAllStoredProcdureName = null;
			_updateStoredProcdureName = null;
		}

		#endregion Public Methods
	}

	public class TableGenericModel<T> : TableGenericModel
	{
		#region Protected Fields

		protected T _primaryKey;

		#endregion Protected Fields

		#region Public Constructors

		public TableGenericModel() : this(typeof(TableGenericModel<T>))
		{
		}

		#endregion Public Constructors

		#region Protected Constructors

		protected TableGenericModel(Type type) : base(type)
		{
		}

		#endregion Protected Constructors

		#region Public Properties

		public T PrimaryKey
		{
			get { return _primaryKey; }
			set { _primaryKey = value; }
		}

		#endregion Public Properties

		#region Public Methods

		public override void Dispose()
		{
			base.Dispose();
			_primaryKey = default(T);
		}

		#endregion Public Methods
	}
}