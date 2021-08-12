using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JutaAPi.Infrastructure.Repositories
{
    public class ConnectionBase : IDbConnection
    {
        protected ConnectionBase(IDbConnection connection)
        {
            Connection = connection;
        }
        protected IDbConnection Connection { get; private set; }       
        #region "IDbConnection implementation"

        public string ConnectionString
        {
            get
            {
                return Connection.ConnectionString;
            }

            set
            {
                Connection.ConnectionString = value;
            }
        }

        public int ConnectionTimeout
        {
            get
            {
                return Connection.ConnectionTimeout;
            }
        }

        public string Database
        {
            get
            {
                return Connection.Database;
            }
        }

        public ConnectionState State
        {
            get
            {
                return Connection.State;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }



        public void Close()
        {
            Connection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return Connection.CreateCommand();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }

        public void Open()
        {
            Connection.Open();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
