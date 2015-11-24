using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RussUnitTestSample.Business.Interface;

namespace RussUnitTestSample.Business.Database
{
    public class DbGetSomeNumbers : IDbGetSomeNumbers
    {

        private readonly IDbConnection _dbConnection;
        private readonly IDbCommand _dbCommand;

        /// <summary>
        /// Constructor - takes in dependencies
        /// </summary>
        /// <param name="dbConnection">The database connection to use.</param>
        /// <param name="dbCommand">The database command to use</param>
        public DbGetSomeNumbers(IDbConnection dbConnection, IDbCommand dbCommand)
        {
            if (dbConnection == null)
                throw new ArgumentNullException(nameof(dbConnection));
            if (dbCommand == null)
                throw new ArgumentNullException(nameof(dbCommand));

            this._dbConnection = dbConnection;
            this._dbCommand = dbCommand;
        }

        public double[] GetSomeNumbers()
        {
            List<double> results = new List<double>();
            
            _dbConnection.Open();
            _dbCommand.Connection = _dbConnection;

            IDataReader rdr = _dbCommand.ExecuteReader();
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("columnName")))
                    results.Add(rdr.GetDouble(rdr.GetOrdinal("columnName")));
            }

            _dbCommand.Dispose();
            _dbConnection.Close();
            _dbConnection.Dispose();

            return results.ToArray();            
        }

    }
}
