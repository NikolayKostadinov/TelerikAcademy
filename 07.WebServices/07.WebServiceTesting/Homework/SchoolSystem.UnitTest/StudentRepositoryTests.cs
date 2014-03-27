using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.UnitTest
{

    [TestClass]
    class StudentRepositoryTests
    {
        public DbContext DbContext { get; set; }
        private static TransactionScope tranScope;

        public StudentRepositoryTests()
        {
            this.DbContext = new SchoolContext();
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
        public void AddingSingleStudentEntryTest()
        {
            //arrange
            const string Subject = "Math";
            const decimal Value = 2.00m;
            const int Age = 10;
            const string FirstName = "Nikolay";
            const string LastName = "Kostadinov";
            const int Grade = 4;
            var mark = new Mark()
            {
                Subject = Subject,
                Value = Value
            };

            var student = new Student()
            {
                Age = Age,
                FirstName = FirstName,
                LastName = LastName,
                Grade = Grade,
                Marks = new List<Mark>() { mark },
            };

            //act
            DbContext.Set<Student>().Add(student);
            DbContext.SaveChanges();

            //assert
            var studentMarks = student.Marks.ToList();
            var actual =
                student.Age == Age &&
                student.Grade == Grade &&
                student.FirstName == FirstName &&
                student.LastName == LastName &&
                student.Marks.Count == 1 &&
                studentMarks[0].Subject == mark.Subject &&
                studentMarks[0].Value == mark.Value;
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
