using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RussUnitTestSample.Business.Interface;

namespace RussUnitTestSample.Business.Database
{

    /// <summary>
    /// Implementation of base database connection
    /// </summary>
    public class BaseDbConnection : IBaseDatabaseConnection
    {

        #region Private
        private readonly string _connectionString;
        #endregion Private

        #region ctor

        /// <summary>
        /// constructor - takes in connection string to be used.
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        public BaseDbConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(nameof(connectionString));

            this._connectionString = connectionString;
        }

        #endregion ctor

        #region Public methods

        public IDbConnection GetDatabaseConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _connectionString;

            return conn;
        }

        #endregion Public methods
    }
}
