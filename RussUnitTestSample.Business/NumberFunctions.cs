using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RussUnitTestSample.Business.Interface;

namespace RussUnitTestSample.Business
{

    /// <summary>
    /// Number functions
    /// </summary>
    public class NumberFunctions : INumberFunctions
    {

        #region Public methods

        /// <summary>
        /// Add numbers together
        /// </summary>
        /// <param name="numbers">The numbers to add.</param>
        /// <returns>The sum</returns>
        public double AddNumbers(double[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            if (numbers.Length == 0)
                throw new ArgumentException("numbers provided must be greater than 0");

            return numbers.Sum();
        }

        #endregion Public methods

    }
}
