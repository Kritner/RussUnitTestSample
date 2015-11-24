using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussUnitTestSample.Business.Interface
{

    /// <summary>
    /// Interface to get some numbers from the database
    /// </summary>
    public interface IDbGetSomeNumbers
    {

        /// <summary>
        /// Get an array of doubles from the database
        /// </summary>
        /// <returns></returns>
        double[] GetSomeNumbers();
    }
}
