using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Data;
using SchoolSystem.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Transactions;

namespace SchoolSystem.UnitTest
{
    [TestClass]
    public class StudentRepositoryTests
    {
        public DbContext dbContext { get; set; }
        private static TransactionScope tranScope;

        public StudentRepositoryTests()
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
            dbContext.Set<Student>().Add(student);
            dbContext.SaveChanges();

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

        [TestMethod]
        public void AddingSingleStudentEntryWithSchoolTest()
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

            var school = new School()
            {
                Name = "Petko Rosen",
                Location = "Meden Rudnik",
            };

            var student = new Student()
            {
                Age = Age,
                FirstName = FirstName,
                LastName = LastName,
                Grade = Grade,
                Marks = new List<Mark>() { mark },
                School = school,
            };

            school.Students.Add(student);

            //act
            dbContext.Set<School>().Add(school);
            dbContext.Set<Student>().Add(student);
            dbContext.SaveChanges();

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

        [TestMethod]
        public void AddingSingleStudentEntryWithSchoolThanDeleteStudentTest()
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

            var school = new School()
            {
                Name = "Petko Rosen",
                Location = "Meden Rudnik",
            };

            var student = new Student()
            {
                Age = Age,
                FirstName = FirstName,
                LastName = LastName,
                Grade = Grade,
                Marks = new List<Mark>() { mark },
                School = school,
            };

            school.Students.Add(student);

            dbContext.Set<School>().Add(school);
            dbContext.Set<Student>().Add(student);
            dbContext.SaveChanges();
            
            //act

            var actual = dbContext.Set<Student>().Where(x => x.StudentId == student.StudentId).FirstOrDefault();

            Assert.AreEqual(student, actual);

            dbContext.Set<Student>().Remove(student);
            dbContext.SaveChanges();
            
            //assert


            actual = dbContext.Set<Student>().Where(x => x.StudentId == student.StudentId).FirstOrDefault();   
            Assert.AreEqual(null, actual);
        }
    }
}
