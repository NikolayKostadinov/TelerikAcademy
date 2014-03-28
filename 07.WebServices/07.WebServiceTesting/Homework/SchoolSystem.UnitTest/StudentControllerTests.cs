using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.Repository.Models;
using SchoolSystem.WebApi.Controllers;
using Telerik.JustMock;
using System.Web.Http;

namespace SchoolSystem.UnitTest
{
    [TestClass]
    public class StudentControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/Student");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "Student");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void StudentControllerAddSingleRecordTest()
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
        public void Add_WhenNameIsValid_ShouldAddTheStudent()
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
                .DoInstead(() => { isItemAdded = true; studentModel.StudentId = 1; })
                .Returns(studentEntity);

            var controller = new StudentController(repository);
            SetupController(controller);
            
            //act
            var httpResponse = controller.Post(studentModel);

            var header = httpResponse.Headers.Where(x => x.Key == "Location").First().Value.First();
            var expected = "http://localhost/api/Student/1";
            //Assert.IsTrue(isItemAdded);
            Assert.AreEqual(expected, header);
            
        }
    }
}
