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
    public class SchoolRepositoryTests
    {
        public DbContext dbContext { get; set; }
        private static TransactionScope tranScope;

        public SchoolRepositoryTests()
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
        public void AddSchoolWithStudent()
        {
            //arrange
            var student = new Student()
            {
                Age = 10,
                FirstName = "Pesho",
                LastName = "Trojkata",
                Grade = 4,
            };

            var school = new School()
            {
                Location = "Меден Рудник",
                Name = "Петко Росен",
                Students = new HashSet<Student>() { student },
            };

            dbContext.Set<Student>().Add(student);
            dbContext.SaveChanges();
            //act
            dbContext.Set<School>().Add(school);
            dbContext.SaveChanges();
            //assert
            Assert.AreEqual(student, school.Students.ToList<Student>()[0]);
        }
    }
}
