using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Helpers.GDb.GTbl.GCommon
{
	/// <summary>
	/// </summary>
	/// <typeparam name="T">
	/// </typeparam>
	public abstract class GTblAbstract<T> : GTblGeneric<T>, IGTbl<T>
	{
		#region Public Methods

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public abstract bool Delete();

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Delete(SqlConnection connection);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Delete(SqlConnection connection, SqlTransaction transaction);

		/// <summary>
		/// </summary>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Delete(out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Delete(SqlConnection connection, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Delete(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public abstract bool Exists();

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Exists(SqlConnection connection);

		/// <summary>
		/// </summary>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Exists(out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Exists(SqlConnection connection, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="dataReader">
		/// </param>
		public abstract void Fill(SqlDataReader dataReader);

		/// <summary>
		/// </summary>
		/// <param name="dataRow">
		/// </param>
		public abstract void Fill(DataRow dataRow);

		/// <summary>
		/// </summary>
		/// <param name="primaryKey">
		/// </param>
		public abstract void Fill(T primaryKey);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="dataRow">
		/// </param>
		public abstract void Fill(SqlConnection connection, DataRow dataRow);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="dataReader">
		/// </param>
		public abstract void Fill(SqlConnection connection, SqlDataReader dataReader);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="primaryKey">
		/// </param>
		public abstract void Fill(SqlConnection connection, T primaryKey);

		/// <summary>
		/// </summary>
		/// <param name="primaryKey">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		public abstract void Fill(T primaryKey, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="primaryKey">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		public abstract void Fill(SqlConnection connection, T primaryKey, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="dataReader">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		public abstract void Fill(SqlDataReader dataReader, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="dataRow">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		public abstract void Fill(DataRow dataRow, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="dataReader">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		public abstract void Fill(SqlConnection connection, SqlDataReader dataReader, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="dataRow">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		public abstract void Fill(SqlConnection connection, DataRow dataRow, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public abstract bool Insert();

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Insert(SqlConnection connection);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction);

		/// <summary>
		/// </summary>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Insert(out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Insert(SqlConnection connection, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Insert(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public abstract bool IsUsed();

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool IsUsed(SqlConnection connection);

		/// <summary>
		/// </summary>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool IsUsed(out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool IsUsed(SqlConnection connection, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public SqlDataReader SelectAll()
		{
			string errorMsg;
			return SelectAll(out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="commandBehavior">
		/// </param>
		/// <returns>
		/// </returns>
		public SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior)
		{
			string errorMsg;
			return SelectAll(connection, commandBehavior, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public SqlDataReader SelectAll(out string errorMsg)
		{
			errorMsg = string.Empty;
			SqlDataReader dataReader = null;
			SqlConnection connection = GDbManager.GetSqlInstance();
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

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public SqlDataReader SelectAll(SqlConnection connection, out string errorMsg)
		{
			return SelectAll(connection, CommandBehavior.Default, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="commandBehavior">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public SqlDataReader SelectAll(SqlConnection connection, CommandBehavior commandBehavior, out string errorMsg)
		{
			errorMsg = string.Empty;
			return null;// AdoProvider.GetDataReaderFromStoredProcedure(connection, selectAllStoredProcdureName, commandBehavior, out errorMsg);
		}

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public SqlDataReader SelectAll(SqlConnection connection)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// </summary>
		/// <returns>
		/// </returns>
		public abstract bool Update();

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Update(SqlConnection connection);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Update(SqlConnection connection, SqlTransaction transaction);

		/// <summary>
		/// </summary>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Update(out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Update(SqlConnection connection, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool Update(SqlConnection connection, SqlTransaction transaction, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="tableName">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName);

		/// <summary>
		/// </summary>
		/// <param name="tableName">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool UpdateEnabilityStatus(string tableName);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="tableName">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, string tableName);

		/// <summary>
		/// </summary>
		/// <param name="tableName">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool UpdateEnabilityStatus(string tableName, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="tableName">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, string tableName, out string errorMsg);

		/// <summary>
		/// </summary>
		/// <param name="connection">
		/// </param>
		/// <param name="transaction">
		/// </param>
		/// <param name="tableName">
		/// </param>
		/// <param name="errorMsg">
		/// </param>
		/// <returns>
		/// </returns>
		public abstract bool UpdateEnabilityStatus(SqlConnection connection, SqlTransaction transaction, string tableName, out string errorMsg);

		#region IDisposable Support

		private bool disposedValue = false;

		// This code added to correctly implement the disposable pattern.
		/// <summary>
		/// </summary>
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above. GC.SuppressFinalize(this);
		}

		/// <summary>
		/// </summary>
		/// <param name="disposing">
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// To detect redundant calls
		// TODO: override a finalizer only if Dispose(bool
		// disposing) above has code to free unmanaged resources. ~GTblAbstract() { // Do not change
		// this code. Put cleanup code in Dispose(bool disposing) above. Dispose(false); }

		#endregion IDisposable Support

		#endregion Public Methods
	}
}