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

        /// <summary>
        /// Ensure ArgumentNullException thrown when no IDbGetSomeNumbers implementation is provided
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetNumbersAndAddThem_Constructor_NullIDbGetSomeNumbers()
        {
            // Arrange / Act / Assert
            Mock<INumberFunctions> mockNumberFunctions = new Mock<INumberFunctions>();
            GetNumbersAndAddThem obj = new GetNumbersAndAddThem(null, mockNumberFunctions.Object);
        }

        /// <summary>
        /// Ensure ArgumentNullException thrown when no NumberFunction implementation is provided
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetNumbersAndAddThem_Constructor_NullNumberFunctions()
        {
            // Arranage / Act / Assert
            Mock<IDbGetSomeNumbers> mockIDbGetSomeNumbers = new Mock<IDbGetSomeNumbers>();
            GetNumbersAndAddThem obj = new GetNumbersAndAddThem(mockIDbGetSomeNumbers.Object, null);
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

            Mock<IDbGetSomeNumbers> mockIDbGetSomeNumbers = new Mock<IDbGetSomeNumbers>();
            mockIDbGetSomeNumbers.Setup(s => s.GetSomeNumbers()).Returns(numbersToUse);

            Mock<INumberFunctions> mockNumberFunctions = new Mock<INumberFunctions>();
            mockNumberFunctions.Setup(s => s.AddNumbers(It.IsAny<double[]>())).Returns(expected);

            GetNumbersAndAddThem obj = new GetNumbersAndAddThem(mockIDbGetSomeNumbers.Object, mockNumberFunctions.Object);

            // Act
            var result = obj.Execute();

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
