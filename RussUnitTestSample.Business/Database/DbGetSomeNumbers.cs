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

    /// <summary>
    /// Get some numbers from the database
    /// </summary>
    public class DbGetSomeNumbers : IDbGetSomeNumbers
    {

        #region consts
        const string SQL_GET_NUMBERS_COMMAND = "SELECT convert(float, 1) as columnName UNION SELECT 2 as columnName UNION SELECT 3 as columnName";
        #endregion consts

        #region Privates
        private readonly IBaseDatabaseConnection _baseDb;
        #endregion Privates
        
        #region ctor
        /// <summary>
        /// Constructor - takes in database dependencies
        /// </summary>
        /// <param name="baseDb">The database connection</param>
        public DbGetSomeNumbers(IBaseDatabaseConnection baseDb)
        {
            if (baseDb == null)
                throw new ArgumentNullException(nameof(baseDb));

            this._baseDb = baseDb;
        }
        #endregion ctor

        #region Public methods

        /// <summary>
        /// Get some numbers from the database
        /// </summary>
        /// <returns>array of numbers</returns>
        public double[] GetSomeNumbers()
        {
            List<double> results = new List<double>();

            using (IDbConnection conn = _baseDb.GetDatabaseConnection())
            {
                conn.Open();

                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SQL_GET_NUMBERS_COMMAND;
                    cmd.CommandType = CommandType.Text;
                    
                    using (IDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("columnName")))
                                results.Add(rdr.GetDouble(rdr.GetOrdinal("columnName")));
                        }
                    }
                }
            }

            return results.ToArray();            
        }

        #endregion Public methods

    }
}
