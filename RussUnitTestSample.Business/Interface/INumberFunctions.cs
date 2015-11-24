using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussUnitTestSample.Business.Interface
{

    /// <summary>
    /// Interface for number functions
    /// </summary>
    public interface INumberFunctions
    {
        /// <summary>
        /// Add numbers together
        /// </summary>
        /// <param name="numbers">The numbers to add.</param>
        /// <returns>The sum</returns>
        double AddNumbers(double[] numbers);
    }
}
