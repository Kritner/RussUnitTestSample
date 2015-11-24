using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RussUnitTestSample.Business.Database;

namespace RussUnitTestSample.Business.Tests.Database
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DbGetSomeNumbersTests
    {

        private Mock<IDbConnection> _dbConnection;
        private Mock<IDbCommand> _dbCommand;
        private Mock<IDataReader> _dataReader;

        /// <summary>
        /// Initialize test mocks.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _dbConnection = new Mock<IDbConnection>();
            _dbCommand = new Mock<IDbCommand>();
            _dataReader = new Mock<IDataReader>();

            _dataReader.Setup(r => r.Read())
              .Returns(new Queue<bool>(new[] { true, true, false }).Dequeue);
            _dbCommand.Setup(s => s.ExecuteReader()).Returns(_dataReader.Object);
            _dbConnection.Setup(s => s.CreateCommand()).Returns(_dbCommand.Object);
        }

        /// <summary>
        /// Ensure exception thrown when DBConnection not provided
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DbGetSomeNumbers_ConstructorDbConnectionNull()
        {
            // Arrange / Act / Assert
            DbGetSomeNumbers obj = new DbGetSomeNumbers(null, _dbCommand.Object);
        }

        /// <summary>
        /// Ensure exception thrown when DBConnection not provided
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DbGetSomeNumbers_ConstructorDbCommandNull()
        {
            // Arrange / Act / Assert
            DbGetSomeNumbers obj = new DbGetSomeNumbers(_dbConnection.Object, null);
        }

        /// <summary>
        /// Get data test
        /// </summary>
        [TestMethod]
        public void DbGetSomeNumbers_Execute()
        {
            // Arrange
            DbGetSomeNumbers obj = new DbGetSomeNumbers(_dbConnection.Object, _dbCommand.Object);

            // Act
            var results = obj.GetSomeNumbers();

            // Assert
            Assert.IsInstanceOfType(results, typeof(double[]));
        }
    }
}
