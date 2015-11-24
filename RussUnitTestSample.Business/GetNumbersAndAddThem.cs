using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RussUnitTestSample.Business.Interface;

namespace RussUnitTestSample.Business
{

    /// <summary>
    /// Get numbers and then add them together
    /// </summary>
    public class GetNumbersAndAddThem
    {

        #region Private
        private readonly IDbGetSomeNumbers _dbGetSomeNumbers;
        private readonly INumberFunctions _numberFunctions;
        #endregion Private

        #region ctor

        /// <summary>
        /// Constructor - provide dependencies
        /// </summary>
        /// <param name="dbGetSomeNumbers">THe IDbGetSomeNumbers implementation.</param>
        /// <param name="numberFunctions">The INumberFunctions implementation.</param>
        public GetNumbersAndAddThem(IDbGetSomeNumbers dbGetSomeNumbers, INumberFunctions numberFunctions)
        {
            if (dbGetSomeNumbers == null)
                throw new ArgumentNullException(nameof(dbGetSomeNumbers));

            if (numberFunctions == null)
                throw new ArgumentNullException(nameof(numberFunctions));

            this._dbGetSomeNumbers = dbGetSomeNumbers;
            this._numberFunctions = numberFunctions;
        }

        #endregion ctor

        #region Public methods

        /// <summary>
        /// Get the numbers and add them.
        /// </summary>
        /// <returns></returns>
        public double Execute()
        {
            var numbers = _dbGetSomeNumbers.GetSomeNumbers();

            return _numberFunctions.AddNumbers(numbers);
        }

        #endregion Public methods

    }

}
