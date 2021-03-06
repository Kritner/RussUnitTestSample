﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RussUnitTestSample.Business.Database;
using RussUnitTestSample.Business.Interface;

namespace RussUnitTestSample.Business.Tests.Database
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DbGetSomeNumbersTests
    {

        #region Private
        private Mock<IBaseDatabaseConnection> _baseDb;
        private Mock<IDbConnection> _dbConnection;
        private Mock<IDbCommand> _dbCommand;
        private Mock<IDataReader> _dataReader;
        #endregion Private

        #region Public methods

        /// <summary>
        /// Initialize test mocks.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _baseDb = new Mock<IBaseDatabaseConnection>();
            _dbConnection = new Mock<IDbConnection>();
            _dbCommand = new Mock<IDbCommand>();
            _dataReader = new Mock<IDataReader>();
        }

        /// <summary>
        /// Ensure exception thrown when BaseDb not provided
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DbGetSomeNumbers_ConstructorDbCommandNull()
        {
            // Arrange / Act / Assert
            DbGetSomeNumbers obj = new DbGetSomeNumbers(null);
        }

        /// <summary>
        /// Get data test
        /// </summary>
        [TestMethod]
        public void DbGetSomeNumbers_Execute()
        {
            // Arrange
            _baseDb.Setup(s => s.GetDatabaseConnection()).Returns(_dbConnection.Object);
            _dbConnection.Setup(s => s.CreateCommand()).Returns(_dbCommand.Object);
            _dbCommand.Setup(s => s.ExecuteReader()).Returns(_dataReader.Object);
            _dataReader.Setup(s => s.Read())
              .Returns(new Queue<bool>(new[] { true, true, false }).Dequeue);

            DbGetSomeNumbers obj = new DbGetSomeNumbers(_baseDb.Object);

            // Act
            var results = obj.GetSomeNumbers();

            // Assert
            Assert.IsInstanceOfType(results, typeof(double[]));
        }

        #endregion Public methods

    }
}
