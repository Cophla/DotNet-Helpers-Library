using System;
using System.Data;
using System.Data.SqlClient;

namespace CodeHelpers.ModelHelper.NoneStatic.TableModel
{
	
	
	public abstract class TableAbstractModel<T> : TableGenericModel<T>, ITableModel<T>
	{
		#region Public Methods

		
		
		public abstract bool Delete();

		
		
		
		public abstract bool Delete(SqlConnection connection);

		
		
		
		
		public abstract bool Delete(SqlConnection connection, SqlTransaction transaction);

		
		
		
		public abstract bool Delete(out string errorMsg);

		
		
		
		
		public abstract bool Delete(SqlConnection connection, out string errorMsg);

		
		
		
		
		
		public abstract bool Delete(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		
		
		public abstract bool Exists();

		
		
		
		public abstract bool Exists(SqlConnection connection);

		
		
		
		public abstract bool Exists(out string errorMsg);

		
		
		
		
		public abstract bool Exists(SqlConnection connection, out string errorMsg);

		
		
		public abstract void Fill(SqlDataReader dataReader);

		
		
		public abstract void Fill(DataRow dataRow);

		
		
		public abstract void Fill(T primaryKey);

		
		
		
		public abstract void Fill(SqlConnection connection, DataRow dataRow);

		
		
		
		public abstract void Fill(SqlConnection connection, SqlDataReader dataReader);

		
		
		
		public abstract void Fill(SqlConnection connection, T primaryKey);

		
		
		
		public abstract void Fill(T primaryKey, out string errorMsg);

		
		
		
		
		public abstract void Fill(SqlConnection connection, T primaryKey, out string errorMsg);

		
		
		
		public abstract void Fill(SqlDataReader dataReader, out string errorMsg);

		
		
		
		public abstract void Fill(DataRow dataRow, out string errorMsg);

		
		
		
		
		public abstract void Fill(SqlConnection connection, SqlDataReader dataReader, out string errorMsg);

		
		
		
		
		public abstract void Fill(SqlConnection connection, DataRow dataRow, out string errorMsg);

		
		
		public abstract bool Insert();

		
		
		
		public abstract bool Insert(SqlConnection connection);

		
		
		
		
		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction);

		
		
		
		public abstract bool Insert(out string errorMsg);

		
		
		
		
		public abstract bool Insert(SqlConnection connection, out string errorMsg);

		
		
		
		
		
		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		
		
		public abstract bool IsUsed();

		
		
		
		public abstract bool IsUsed(SqlConnection connection);

		
		
		
		public abstract bool IsUsed(out string errorMsg);

		
		
		
		
		public abstract bool IsUsed(SqlConnection connection, out string errorMsg);

		
		
		public SqlDataReader SelectAll()
		{
			string errorMsg;
			return SelectAll(out errorMsg);
		}

		
		
		
		
		public SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior)
		{
			string errorMsg;
			return SelectAll(connection, commandBehavior, out errorMsg);
		}

		
		
		
		public SqlDataReader SelectAll(out string errorMsg)
		{
			errorMsg = string.Empty;
			SqlDataReader dataReader = null;
			SqlConnection connection = null;// GDbManager.GetSqlInstance();
			{
				try
				{
					connection.Open();
					dataReader = SelectAll(connection, out errorMsg);
				}
				catch (Exception) { }
				finally
				{
					if (dataReader == null)
					{
						connection.Dispose();
					}
				}
			}
			return dataReader;
		}

		
		
		
		
		public SqlDataReader SelectAll(SqlConnection connection, out string errorMsg)
		{
			return SelectAll(connection, CommandBehavior.Default, out errorMsg);
		}

		
		
		
		
		
		public SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg)
		{
			errorMsg = string.Empty;
			return null;// AdoProvider.GetDataReaderFromStoredProcedure(connection, selectAllStoredProcdureName, commandBehavior, out errorMsg);
		}

		
		
		
		public SqlDataReader SelectAll(SqlConnection connection)
		{
			throw new NotImplementedException();
		}

		
		
		public abstract bool Update();

		
		
		
		public abstract bool Update(SqlConnection connection);

		
		
		
		
		public abstract bool Update(SqlConnection connection, SqlTransaction transaction);

		
		
		
		public abstract bool Update(out string errorMsg);

		
		
		
		
		public abstract bool Update(SqlConnection connection, out string errorMsg);

		
		
		
		
		
		public abstract bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		
		
		
		
		
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName);

		
		
		
		public abstract bool UpdateEnabilityStatus(string tableName);

		
		
		
		
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, string tableName);

		
		
		
		
		public abstract bool UpdateEnabilityStatus(string tableName, out string errorMsg);

		
		
		
		
		
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, string tableName, out string errorMsg);

		
		
		
		
		
		
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg);

		#endregion Public Methods
	}
}