using System;
using System.Data.Entity;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.UnitTest
{
    [TestClass]
    public class MarkRepositoryTests
    {
        public DbContext dbContext { get; set; }
        private static TransactionScope tranScope;
        
        public MarkRepositoryTests()
        {
            this.dbContext = new SchoolContext();
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
        public void AddingSingleMarkEntryTest()
        {
            //arrange
            const string SUBJECT = "Math";
            const decimal VALUE = 2.00m;
            var mark = new Mark() 
            {
                Subject = SUBJECT,
                Value = VALUE
            };
            
            //act
            dbContext.Set<Mark>().Add(mark);
            dbContext.SaveChanges();

            //assert
            var actual = (mark.Subject == SUBJECT && mark.Value == VALUE && mark.MarkId > 0);
            var expected = true;
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingSingleMarkWithENullSubjectMustThrowArgumentExceptionTest()
        {
            const decimal VALUE = 2.00m;
            var mark = new Mark()
            {
                Subject = null,
                Value = VALUE
            };

            //act
            dbContext.Set<Mark>().Add(mark);
            dbContext.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingSingleMarkWithEmptySubjectMustThrowArgumentExceptionTest()
        {
            
            const decimal VALUE = 6.00m;
            var mark = new Mark()
            {
                Subject = null,
                Value = VALUE
            };

            //act
            dbContext.Set<Mark>().Add(mark);
            dbContext.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingSingleMarkWithOutOfHighRangeValueMustThrowArgumentExceptionTest()
        {
            const string SUBJECT = "Math";
            const decimal VALUE = 6.50m;
            var mark = new Mark()
            {
                Subject = SUBJECT,
                Value = VALUE
            };

            //act
            dbContext.Set<Mark>().Add(mark);
            dbContext.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingSingleMarkWithOutOfLowRangeValueMustThrowArgumentExceptionTest()
        {
            const string SUBJECT = "Math";
            const decimal VALUE = 1.99m;
            var mark = new Mark()
            {
                Subject = SUBJECT,
                Value = VALUE
            };

            //act
            dbContext.Set<Mark>().Add(mark);
            dbContext.SaveChanges();
        }
    }
}
