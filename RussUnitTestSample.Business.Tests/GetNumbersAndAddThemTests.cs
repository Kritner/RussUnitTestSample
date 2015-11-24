using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RussUnitTestSample.Business.Interface;

namespace RussUnitTestSample.Business.Tests
{

    /// <summary>
    /// Unit tests for GetNumbersAndAddThem
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GetNumbersAndAddThemTests
    {

        #region Private
        Mock<INumberFunctions> _mockNumberFunctions;
        Mock<IDbGetSomeNumbers> _mockIDbGetSomeNumbers;
        #endregion Private

        #region Public methods

        /// <summary>
        /// Setup mock objects
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mockNumberFunctions = new Mock<INumberFunctions>();
            _mockIDbGetSomeNumbers = new Mock<IDbGetSomeNumbers>();
        }

        /// <summary>
        /// Ensure ArgumentNullException thrown when no IDbGetSomeNumbers implementation is provided
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetNumbersAndAddThem_Constructor_NullIDbGetSomeNumbers()
        {
            // Arrange / Act / Assert
            GetNumbersAndAddThem obj = new GetNumbersAndAddThem(null, _mockNumberFunctions.Object);
        }

        /// <summary>
        /// Ensure ArgumentNullException thrown when no NumberFunction implementation is provided
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetNumbersAndAddThem_Constructor_NullNumberFunctions()
        {
            // Arranage / Act / Assert
            GetNumbersAndAddThem obj = new GetNumbersAndAddThem(_mockIDbGetSomeNumbers.Object, null);
        }

        /// <summary>
        /// Tests that GetNumbersAndAddThem.Execute gets numbers and then adds them.
        /// </summary>
        [TestMethod]
        public void GetNumbersAndAddThem_Execute()
        {
            // Arrange
            double[] numbersToUse = { 1, 2, 3, 4, 5 };
            double expected = numbersToUse.Sum();

            _mockIDbGetSomeNumbers.Setup(s => s.GetSomeNumbers()).Returns(numbersToUse);
            _mockNumberFunctions.Setup(s => s.AddNumbers(It.IsAny<double[]>())).Returns(expected);

            GetNumbersAndAddThem obj = new GetNumbersAndAddThem(_mockIDbGetSomeNumbers.Object, _mockNumberFunctions.Object);

            // Act
            var result = obj.Execute();

            // Assert
            Assert.AreEqual(expected, result);
        }

        #endregion Public methods

    }
}
