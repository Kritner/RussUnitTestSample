using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RussUnitTestSample.Business.ServiceReference1;

namespace RussUnitTestSample.Business.Tests.WCF
{

    /// <summary>
    /// Unit tests for Service1
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Service1Tests
    {

        #region Private
        private Mock<IService1> _service;
        #endregion Private

        #region Public methods
        /// <summary>
        /// initialize the mocks
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this._service = new Mock<IService1>();
        }

        /// <summary>
        /// Exception thrown when IService implementation is not provided
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Service1_NullIService1InConstructor_ThrowsException()
        {
            // Arrange / Act
            Business.WCF.Service1 service = new Business.WCF.Service1(null);
        }

        /// <summary>
        /// Object properly constructed when implementation of IService1 provided
        /// </summary>
        [TestMethod]
        public void Service1_ConstructorWithProvidedIService1_NewsCorrectly()
        {
            // Arrange / Act
            Business.WCF.Service1 service = new Business.WCF.Service1(_service.Object);

            // Assert
            Assert.IsInstanceOfType(service, typeof(Business.WCF.Service1));
        }

        /// <summary>
        /// Ensure that a string is returned from Service1 when calling GetData
        /// </summary>
        [TestMethod]
        public void Service1_GetDataTest()
        {
            // Arrange
            this._service.Setup(s => s.GetData(It.IsAny<int>())).Returns("test");
            Business.WCF.Service1 service = new Business.WCF.Service1(_service.Object);

            // Act
            var result = service.GetData(It.IsAny<int>());

            // Assert
            Assert.IsInstanceOfType(result, typeof(string));
        }

        #endregion Public methods

    }
}
