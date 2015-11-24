using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussUnitTestSample.Business.Interface
{

    /// <summary>
    /// Provides a means of retrieving an IDbConnection
    /// </summary>
    public interface IBaseDatabaseConnection
    {

        /// <summary>
        /// Get an IDbConnection to use
        /// </summary>
        /// <returns></returns>
        IDbConnection GetDatabaseConnection();
    }
}
