using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RussUnitTestSample.Business.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NumberFunctionTests
    {

        #region Public methods

        /// <summary>
        /// Test exception thrown when numbers provided is null
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddNumbers_NullParameterNumbers()
        {
            // Arrange / Act / Assert
            NumberFunctions nf = new NumberFunctions();
            var result = nf.AddNumbers(null);
        }

        /// <summary>
        /// Test exception thrown when 0 numbers provided in array
        /// </summary>
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddNumbers_EmptyArrayNumbers()
        {
            // Arrange / Act / Assert
            NumberFunctions nf = new NumberFunctions();
            var result = nf.AddNumbers(new double[] { });
        }

        /// <summary>
        /// Add two positive numbers
        /// </summary>
        [TestMethod]
        public void AddNumbers_TwoNumbers()
        {
            // Arrange
            double[] numbers = { 1, 2 };
            NumberFunctions nf = new NumberFunctions();

            // Act
            var result = nf.AddNumbers(numbers);

            // Assert
            Assert.AreEqual(numbers.Sum(), result);
        }

        /// <summary>
        /// Add 10 numbers mixed positive and negative
        /// </summary>
        [TestMethod]
        public void AddNumbers_TenNumbersWithPositiveAndNegatives()
        {
            // Arrange
            double[] numbers = { 1, -2, 3, 4, -5, 6, 7, -8, 9, 10 };
            NumberFunctions nf = new NumberFunctions();

            // Act
            var result = nf.AddNumbers(numbers);

            // Assert
            Assert.AreEqual(numbers.Sum(), result);
        }

        [TestMethod]
        public void AddNumbers_ProvideOneNumber()
        {
            // Arrange
            double[] numbers = { 1 };
            NumberFunctions nf = new NumberFunctions();

            // Act
            var result = nf.AddNumbers(numbers);

            // Assert
            Assert.AreEqual(numbers.Sum(), result);
        }
        
        #endregion Public methods
    }
}
