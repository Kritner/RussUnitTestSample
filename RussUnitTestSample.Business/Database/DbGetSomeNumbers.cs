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
        private readonly IBaseDatabaseConnection _baseDb;

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

        public double[] GetSomeNumbers()
        {
            List<double> results = new List<double>();

            using (IDbConnection conn = _baseDb.GetDatabaseConnection())
            {
                conn.Open();

                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "usp_someStoredProc";
                    cmd.CommandType = CommandType.StoredProcedure;

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

    }
}
