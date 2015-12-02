using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RussUnitTestSample.Wcf.Tests
{

    /// <summary>
    /// Unit tests for service1
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Service1Tests
    {

        /// <summary>
        /// Get data works as expected with a positive number
        /// </summary>
        [TestMethod]
        public void Service1_GetData_PositiveNumber()
        {
            // Arrange
            Wcf.Service1 service = new Wcf.Service1();
            int num = 55;
            var expected = string.Format("You entered: {0}", num);

            // Act
            var result = service.GetData(num);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Get data works as expected with a negative number
        /// </summary>
        [TestMethod]
        public void Service1_GetData_NegativeNumber()
        {
            // Arrange
            Wcf.Service1 service = new Wcf.Service1();
            int num = -42;
            var expected = string.Format("You entered: {0}", num);

            // Act
            var result = service.GetData(num);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Get data works as expected with zero
        /// </summary>
        [TestMethod]
        public void Service1_GetData_Zero()
        {
            // Arrange
            Wcf.Service1 service = new Wcf.Service1();
            int num = 0;
            var expected = string.Format("You entered: {0}", num);

            // Act
            var result = service.GetData(num);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// An exception is thrown when the CompositeType is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Service1_GetDataUsingDataContract_ExceptionThrownWhenCompositeTypeNull()
        {
            // Arrange
            Wcf.Service1 service = new Service1();

            // Act
            var result = service.GetDataUsingDataContract(null);
        }

        /// <summary>
        /// When BoolValue is false, do not append "Suffix" to StringValue
        /// </summary>
        [TestMethod]
        public void Service1_GetDataUsingDataContract_CompositTypeBoolValueFalse_DoNotAppendSuffix()
        {
            // Arrange
            Wcf.Service1 service = new Service1();
            string testString = "Test";
            CompositeType ct = new CompositeType()
            {
                BoolValue = false,
                StringValue = testString
            };

            // Act
            var result = service.GetDataUsingDataContract(ct);

            // Assert
            Assert.AreEqual(testString, result.StringValue);
        }

        /// <summary>
        /// When BoolValue is true, append "Suffix" to StringValue
        /// </summary>
        [TestMethod]
        public void Service1_GetDataUsingDataContract_CompositTypeBoolValueTrue_AppendSuffix()
        {
            // Arrange
            Wcf.Service1 service = new Service1();
            string testString = "Test";
            CompositeType ct = new CompositeType()
            {
                BoolValue = true,
                StringValue = testString
            };

            var expected = testString + "Suffix";

            // Act
            var result = service.GetDataUsingDataContract(ct);

            // Assert
            Assert.AreEqual(expected, result.StringValue);
        }

    }
}
