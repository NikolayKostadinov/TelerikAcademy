using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using FileUpload.Data;
using FileUpload.Data.Abstract;
using FileUpload.Models.FileModels;
using FileUpload.Models.LogModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileUpload.Tests
{
    [TestClass]
    public class GenerycRepositoryTests
    {
        public DbContext dbContext { get; set; }

        public IRepository<TraceLogMessage, int> tlm;

        private static TransactionScope tranScope;

        public GenerycRepositoryTests()
        {
            this.dbContext = new ApplicationDbContext();
            this.tlm = new GenericRepository<TraceLogMessage, int>(this.dbContext);
        }

        [TestInitialize]
        public void InitializeTest()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void AddSingleTracelogMessageTest()
        {
            //arrange
            string filename = "TestFileDescription" + DateTime.Today;
            var traceLogMessage = new TraceLogMessage()
                        {
                            Action = "Action",
                            Controller = "Controller",
                            Message = "Test",
                            Status = Status.Ok,
                            TimeStamp = DateTime.Now,
                            UserName = "TestUser"
                        };
            //act

            this.tlm.Add(traceLogMessage);
            dbContext.SaveChanges();

            //assert
            Assert.IsFalse(traceLogMessage.Id == 0);
        }

        [TestMethod]
        public void BulkInsert10TracelogMessageсReceive10recordsTest()
        {
            var traceLogMessages = new List<TraceLogMessage>();
            for (int i = 0; i < 10; i++)
            {
                var traceLogMessage = new TraceLogMessage()
                {
                    Action = "Action",
                    Controller = "Controller",
                    Message = "Test",
                    Status = Status.Ok,
                    TimeStamp = DateTime.Now,
                    UserName = "TestUser"
                };
               
                traceLogMessages.Add(traceLogMessage);
            }
            //act
            tlm.BulkInsert(traceLogMessages);

            dbContext.SaveChanges();

            //assert
            var actualTraceLogMessagesInDataBase = tlm.All().Where(x=>x.Action == "Action").ToList();
            Assert.AreEqual(10, actualTraceLogMessagesInDataBase.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void InsertTracelogMessageRecordWithoutControllerNameThrowExceptionTest()
        {
            //arrange
            var traceLogMessage = new TraceLogMessage()
            {
                Action = "Action",
                Controller = null,
                Message = "Test",
                Status = Status.Ok,
                TimeStamp = DateTime.Now,
                UserName = "TestUser"
            };
            //act
            tlm.Add(traceLogMessage);
            dbContext.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void InsertTracelogMessageRecordWithoutMessageThrowExceptionTest()
        {
            //arrange
            var traceLogMessage = new TraceLogMessage()
            {
                Action = "Action",
                Controller = "Controller",
                Message = null,
                Status = Status.Ok,
                TimeStamp = DateTime.Now,
                UserName = "TestUser"
            };
            //act
            tlm.Add(traceLogMessage);
            dbContext.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void InsertTracelogMessageRecordWithoutTimeStampThrowExceptionTest()
        {
            //arrange
            var traceLogMessage = new TraceLogMessage()
            {
                Action = null,
                Controller = "Controller",
                Message = "Test",
                Status = Status.Ok,
                UserName = "TestUser"
            };
            //act
            tlm.Add(traceLogMessage);
            dbContext.SaveChanges();
        }
    }
}
