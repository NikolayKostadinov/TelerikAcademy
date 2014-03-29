using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.Repository.Models;
using SchoolSystem.WebApi.Controllers;
using Telerik.JustMock;

namespace SchoolSystem.UnitTest
{
    [TestClass]
    public class StudentControllerTests
    {
        const string BaseUrl = "http://localhost/api/";
        const string ControllerName = "Student";

        readonly Student studentModel = new Student()
        {
            Age = 10,
            Grade = 4,
            FirstName = "Nikolay",
            LastName = "Kostadinov",
            Marks = new List<Mark>
            {
                new Mark
                {
                    Subject = "Math",
                    Value = 6,
                }
            },
        };

        [TestMethod]
        public void StudentControllerGetAllRecordsTest()
        {
            //arrange
            var mockRepository = Mock.Create<IRepository<Student>>();
            var studentToAdd = new Student()
            {
                Age = 10,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
            };

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentToAdd);

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => studentEntities.AsQueryable());

            var studentController = new StudentController(mockRepository);

            var expected = 1;
            //act
            var actual = studentController.Get();

            // assert
            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod]
        public void StudentControllerGetSingleRecordTest()
        {
            //arrange
            var mockRepository = Mock.Create<IRepository<Student>>();
            var studentToAdd = new Student()
            {
                Age = 10,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
            };

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentToAdd);

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => studentEntities.AsQueryable());

            var studentController = new StudentController(mockRepository);
            var studentModels = studentEntities.AsQueryable().Select(StudentDetailedModel.FormStudent).First();
            var expected = studentModels;
            //act
            var actual = studentController.Get(0);

            // assert
            Assert.AreEqual(expected.FirstName, actual.FirstName);
        }
        
        [TestMethod]
        public void StudentControllerGetAllWithMarksGreaterThan5RecordTest()
        {
            //arrange
            var mockRepository = Mock.Create<IRepository<Student>>();
            
            var studentToAdd2 = new Student()
            {
                Age = 10,
                Grade = 4,
                FirstName = "Pencho",
                LastName = "Penchev",
                Marks = new List<Mark>
                {
                    new Mark
                    {
                        Subject = "Math",
                        Value = 4,
                    }
                },
            };

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentModel);
            studentEntities.Add(studentToAdd2);

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => studentEntities.AsQueryable());

            var studentController = new StudentController(mockRepository);
            var studentModels = studentEntities.AsQueryable().Select(StudentDetailedModel.FormStudent).First();
            var expected = studentModels;
            
            //act
            var result = studentController.Get("Math", 5);
            var actual = result.First();

            // assert
            Assert.IsTrue(result.Count() == 1);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
        }

        [TestMethod]
        public void StudentControllerGetStudentsBySchoolRecordTest()
        {
            //arrange
            var mockRepository = Mock.Create<IRepository<Student>>();
            var studentToAdd = new Student()
            {
                Age = 10,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
                School = new School()
                {
                    Location = "Lazur",
                    Name = "Wasil aprilov",
                    SchoolId = 1,
                }
            };

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentToAdd);

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => studentEntities.AsQueryable());

            var studentController = new StudentController(mockRepository);
            //act
            var actual = studentController.GetStudentBySchool(1);

            // assert
            Assert.AreEqual(1, actual.Count());
        }

        [TestMethod]
        public void Add_WhenStudentIsValid_ShouldAddTheStudent()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new Student()
            {
                Age = 10,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
            };

            var studentEntity = new Student()
            {
                StudentId = 1,
                Age = 10,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => { isItemAdded = true; })
                .Returns(studentEntity);

            var controller = new StudentController(repository);
            controller.SetupControllerForTest(HttpMethod.Post, BaseUrl, ControllerName);

            //act
            var httpResponse = controller.Post(studentModel);

            var header = httpResponse.Headers.Location.AbsoluteUri;
            var expected = BaseUrl + ControllerName + "/1";
            Assert.IsTrue(isItemAdded);
            Assert.AreEqual(expected, header);
        }

        [TestMethod]
        public void Add_WhenStudentIsInValid_ShouldAddTheStudent()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new Student()
            {
                Age = 10,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
            };

            var studentEntity = new Student()
            {
                StudentId = 1,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .Throws<ArgumentException>("Grade");

            var controller = new StudentController(repository);
            controller.SetupControllerForTest(HttpMethod.Post, BaseUrl, ControllerName);
            
            var expected = HttpStatusCode.BadRequest;

            //act
            var httpResponse = controller.Post(studentModel);
            var actual = httpResponse.StatusCode;

            ///assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Update_WhenStudentIsValid_ShouldUpdateTheStudent()
        {
            bool isItemUpdated = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new Student()
            {
                Age = 10,
                Grade = 4,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
            };

            Mock.Arrange(() => repository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                .DoInstead(() => { isItemUpdated = true; });

            var controller = new StudentController(repository);
            controller.SetupControllerForTest(HttpMethod.Put, BaseUrl, ControllerName);

            //act
            var httpResponse = controller.Put(1, studentModel);

            var actual = httpResponse.StatusCode;
            var expected = HttpStatusCode.Accepted;

            Assert.IsTrue(isItemUpdated);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_WhenStudentIsValid_ShouldDeleteTheStudent()
        {
            bool isItemDeleted = false;
            var repository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => repository.Delete(Arg.AnyInt))
                .DoInstead(() => { isItemDeleted = true; });

            var controller = new StudentController(repository);
            controller.SetupControllerForTest(HttpMethod.Delete, BaseUrl, ControllerName);

            //act
            var httpResponse = controller.Delete(0);

            var actual = httpResponse.StatusCode;
            var expected = HttpStatusCode.Accepted;

            Assert.IsTrue(isItemDeleted);
            Assert.AreEqual(expected, actual);
        }
    }
}