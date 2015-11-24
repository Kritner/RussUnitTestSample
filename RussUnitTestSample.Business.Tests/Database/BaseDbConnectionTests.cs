using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RussUnitTestSample.Business.Database;

namespace RussUnitTestSample.Business.Tests.Database
{

    /// <summary>
    /// Tets for BaseDbConnection
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BaseDbConnectionTests
    {

        #region consts
        const string TEST_BAD_CONNECTION_STRING = "bad connection string";
        const string TEST_GOOD_CONNECTION_STRING = "Data Source=192.168.50.4,1515;Initial Catalog=MBES;Persist Security Info=True;Integrated Security=true;";
        #endregion consts

        #region Public

        /// <summary>
        /// Tests exception is thrown if connection string not provided
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BaseDbConnection_ConstructorParamNull()
        {
            // Arrange / Act / Assert
            BaseDbConnection obj = new BaseDbConnection("");
        }

        /// <summary>
        /// Test that badly formatted connection string throws exception
        /// </summary>
        [TestMethod]
        public void BaseDbConnection_IDbConnectionGetsConnectionString()
        {
            // Arrange
            BaseDbConnection obj = new BaseDbConnection(TEST_GOOD_CONNECTION_STRING);

            // Act
            var result = obj.GetDatabaseConnection();

            // Assert
            Assert.AreEqual(TEST_GOOD_CONNECTION_STRING, result.ConnectionString);
        }

        /// <summary>
        /// Test that badly formatted connection string throws exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BaseDbConnection_BadConnectionString()
        {
            // Arrange
            BaseDbConnection obj = new BaseDbConnection(TEST_BAD_CONNECTION_STRING);

            // Act
            var result = obj.GetDatabaseConnection();
        }

        #endregion Public
    }
}
