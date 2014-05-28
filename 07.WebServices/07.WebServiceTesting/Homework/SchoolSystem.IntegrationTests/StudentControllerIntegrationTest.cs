using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Places.Services.IntergrationTests;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace SchoolSystem.IntegrationTests
{
    [TestClass]
    public class StudentControllerIntegrationTest
    {
       [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                Age = 10,
                FirstName = "Nikolay",
                LastName = "Kostadinov",
                Grade = 4
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/Student");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);    
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostStudent_WhenNameIsNull_ShouldReturnStatusCode400()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository
                .Add(Arg.Matches<Student>(st => st.FirstName == null)))
                .Throws<NullReferenceException>();


            var server =
                new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreatePostRequest("api/Student",
                new Student()
                );

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
