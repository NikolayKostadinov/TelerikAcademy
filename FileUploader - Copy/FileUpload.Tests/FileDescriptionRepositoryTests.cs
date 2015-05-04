using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using FileUpload.Data;
using FileUpload.Data.Concrete;
using FileUpload.Models.FileModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileUpload.Tests
{
    [TestClass]
    public class FileDescriptionRepositoryTests
    {
        public DbContext dbContext { get; set; }

        public IRepository<FileDescription, int> fd;

        private static TransactionScope tranScope;

        public FileDescriptionRepositoryTests()
        {
            this.dbContext = new ApplicationDbContext();
            this.fd = new FileDescriptionRepository(this.dbContext);
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
        public void AddSingleFileDescription()
        {
            //arrange
            string filename = "TestFileDescription" + DateTime.Today;

            //act
            var fileDescription = new FileDescription()
            {
                FileName = filename,
                Size = 1,
                UploadTime = DateTime.Now
            };
            fd.Add(fileDescription);
            dbContext.SaveChanges();

            //assert
            Assert.IsFalse(fileDescription.Id == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddSingleFileDescriptionWithoutFileName()
        {
            //arrange
            string filename = "TestFileDescription" + DateTime.Today;

            //act
            var fileDescription = new FileDescription()
            {
                FileName = null,
                Size = 1,
                UploadTime = DateTime.Now
            };
            fd.Add(fileDescription);
            dbContext.SaveChanges();

            //assert
            Assert.IsFalse(fileDescription.Id == 0);
        }

        [TestMethod]
        public void BulkInsert10FileDescriptionReceive10recordsTest()
        {
            string filename = "TestFileDescription" + DateTime.Today;

            //arrange
            var fileDescriptions = new List<FileDescription>();
            for (int i = 0; i < 10; i++)
            {
                var fileDescription = new FileDescription()
                {
                    FileName = filename,
                    Size = 1,
                    UploadTime = DateTime.Now
                };
                fileDescriptions.Add(fileDescription);
            }
            //act
            fd.BulkInsert(fileDescriptions);

            dbContext.SaveChanges();

            //assert
            var actualFileDescriptionsInDataBase = fd.All().Where(x => (x.FileName == filename)).ToList();
            Assert.AreEqual(10, actualFileDescriptionsInDataBase.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void InsertFileDescriptionRecordWithoutNameShouldThrowExceptionTest()
        {
            //arrange
            var fileDescription = new FileDescription()
            {
                FileName = null,
                Size = 1,
                UploadTime = DateTime.Now
            };
            //act
            fd.Add(fileDescription);
            dbContext.SaveChanges();
        }
    }
}