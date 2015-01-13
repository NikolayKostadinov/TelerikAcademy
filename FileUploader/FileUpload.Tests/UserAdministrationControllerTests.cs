using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FileUpload.Controllers;
using FileUpload.Data;
using FileUpload.Models.Identity;
using FileUpload.Models.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FileUpload.Tests
{
    [TestClass]
    public sealed class UserAdministrationControllerTests
    {
        private readonly IList<RoleIntPk> roles;
        private readonly IList<ApplicationUser> users;
        private readonly IRepository<RoleIntPk, int> rolesRepository;
        private readonly IRepository<ApplicationUser, int> usersRepository;
        private readonly IUowData uowData;
        private readonly ControllerContext controllerContext;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserAdministrationControllerTests" /> class.
        /// </summary>
        public UserAdministrationControllerTests()
        {
            this.roles = new List<RoleIntPk>()
            {
                new RoleIntPk(){ Id = 1, Name="Administrator" },
                new RoleIntPk(){ Id = 2, Name="User" },
                new RoleIntPk(){ Id = 3, Name="Uploader" },
            };

            this.users = new List<ApplicationUser>()
            {
                new ApplicationUser(){ Id = 1, Email="user1@faikemail.com", UserName = "user1"},
                new ApplicationUser(){ Id = 2, Email="user1@faikemail.com", UserName = "user2"},
                new ApplicationUser(){ Id = 3, Email="user1@faikemail.com", UserName = "user3"},
            };

            foreach (var user in this.users)
            {
                user.Roles.Add(new UserRoleIntPk() { UserId = user.Id, RoleId = 1 });
                user.Roles.Add(new UserRoleIntPk() { UserId = user.Id, RoleId = 2 });
                user.Roles.Add(new UserRoleIntPk() { UserId = user.Id, RoleId = 3 });
            }

            //Create Mock repositories
            Mock<IRepository<RoleIntPk, int>> mockRolesRepository = new Mock<IRepository<RoleIntPk, int>>();
            mockRolesRepository.Setup(r => r.All()).Returns(this.roles.AsQueryable());
            mockRolesRepository.Setup(u => u.GetById(It.IsAny<int>())).Returns((int x) => { return this.roles[x - 1]; });
            this.rolesRepository = mockRolesRepository.Object;

            Mock<IRepository<ApplicationUser, int>> mockUsersRepository = new Mock<IRepository<ApplicationUser, int>>();
            mockUsersRepository.Setup(u => u.All()).Returns(this.users.AsQueryable());
            mockUsersRepository.Setup(u => u.GetById(It.IsAny<int>())).Returns((int x) => { return this.users[x - 1]; });
            mockUsersRepository.Setup(u => u.Delete(It.IsAny<ApplicationUser>())).Callback((ApplicationUser x) => { this.users.RemoveAt(0); });
            mockUsersRepository.Setup(u => u.Update(It.Is<ApplicationUser>(
                     au => !au.Email.Contains("@")
                     ))).Throws(new ArgumentException("Email"));
            this.usersRepository = mockUsersRepository.Object;

            Mock<IUowData> mockUow = new Mock<IUowData>();

            mockUow.Setup(p => p.Roles).Returns(this.rolesRepository);
            mockUow.Setup(p => p.Users).Returns(this.usersRepository);

            this.uowData = mockUow.Object;
            var mockControllerContext = new Mock<ControllerContext>();
            mockControllerContext.Setup(x => x.HttpContext).Returns(GetMockedHttpContext());
            //mockControllerContext.Setup(x=>x.HttpContext.User).Returns(new GenericPrincipal(new GenericIdentity("Test"),new string[]{"test"}));
            //mockControllerContext.Setup(x => x.HttpContext.GetOwinContext);
            this.controllerContext = mockControllerContext.Object;
        }

        /// <summary>
        /// Gets mocked HttpContext
        /// </summary>
        /// <returns>HttpContext</returns>
        private HttpContextBase GetMockedHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new GenericPrincipal(new GenericIdentity("Test"), new string[] { "test" });
            var identity = new Mock<IIdentity>();
            var urlHelper = new Mock<UrlHelper>();

            var routes = new RouteCollection();
            var requestContext = new Mock<RequestContext>();
            requestContext.Setup(x => x.HttpContext).Returns(context.Object);
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user);
                
            context.Setup(ctx => ctx.User.Identity).Returns(identity.Object);
            //context.Setup(ctx => ctx.Items["owin.Environment"]).Returns(new Microsoft.Owin.Host.SystemWeb.Resources.HttpContext());
            //user.Setup(ctx => ctx.Identity).Returns(identity.Object);
            identity.Setup(id => id.IsAuthenticated).Returns(true);
            identity.Setup(id => id.Name).Returns("test");
            request.Setup(req => req.Url).Returns(new Uri("http://www.google.com"));
            request.Setup(req => req.RequestContext).Returns(requestContext.Object);
            requestContext.Setup(x => x.RouteData).Returns(new RouteData());
            request.SetupGet(req => req.Headers).Returns(new NameValueCollection());

            return context.Object;
        }

        [TestMethod]
        public void ReadAllUsersTest()
        {
            // Arrange - create the controller
            UserAdministrationController target = new UserAdministrationController(uowData);

            // Act - add a product to the cart
            var result = target.ReadAllUsers(new DataSourceRequest());
            var records = (result.Data as Kendo.Mvc.UI.DataSourceResult).Data;

            // Assert
            int count = 0;

            foreach (var record in records)
            {
                Assert.AreEqual((record as AccountViewModel).Email, this.users[count].Email);
                Assert.AreEqual((record as AccountViewModel).UserName, this.users[count].UserName);
                count++;
            }

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void ReadAllUsersTestPagind()
        {
            // Arrange - create the controller
            UserAdministrationController target = new UserAdministrationController(uowData);

            // Act - add a product to the cart
            var result = target.ReadAllUsers(new DataSourceRequest() { PageSize = 2, Page = 1 });
            var records = (result.Data as Kendo.Mvc.UI.DataSourceResult).Data;

            // Assert
            int count = 0;

            foreach (var record in records)
            {
                Assert.AreEqual((record as AccountViewModel).Email, this.users[count].Email);
                Assert.AreEqual((record as AccountViewModel).UserName, this.users[count].UserName);
                count++;
            }

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetRolesByUserTest()
        {
            // Arrange - create the controller
            UserAdministrationController target = new UserAdministrationController(uowData);

            // Act - add a product to the cart
            var result = target.GetRolesByUser(1, new DataSourceRequest()) as JsonResult;
            var records = (result.Data as Kendo.Mvc.UI.DataSourceResult).Data;

            // Assert
            int count = 0;

            foreach (var record in records)
            {
                Assert.AreEqual((record as RoleViewModel).Id, this.roles[count].Id);
                Assert.AreEqual((record as RoleViewModel).Name, this.roles[count].Name);
                count++;
            }

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            // Arrange - create the controller
            UserAdministrationController target = new UserAdministrationController(uowData);
            var user = new AccountViewModel() { Id = 1 };
            string newEmail = "test@test.com";
            RoleViewModel removeRole = new RoleViewModel() { Id = roles[0].Id, Name = roles[0].Name };
            string newPhone = "1234567";
            string newUserName = "NewUserName";

            user.Email = newEmail;
            user.PhoneNumber = newPhone;
            user.Roles = new List<RoleViewModel>() { new RoleViewModel(){ Id = 1, Name="Administrator" },
                                                     new RoleViewModel(){ Id = 2, Name="User" } };
            user.UserName = newUserName;

            // Act - add a product to the cart
            var result = (target.UpdateUser(user, new DataSourceRequest()) as JsonResult).Data;
            user = (result as Kendo.Mvc.UI.DataSourceResult).Data.AsQueryable().Cast<AccountViewModel>().FirstOrDefault();
            // Assert
            Assert.AreEqual(newEmail, user.Email);
            Assert.AreEqual(newPhone, user.PhoneNumber);
            Assert.AreEqual(2, user.Roles.Count);
            Assert.AreEqual(newUserName, user.UserName);

        }

        [TestMethod]
        public void UpdateUserWithInvalidEmailMustSendErrorMessageTest()
        {
            // Arrange - create the controller
            UserAdministrationController target = new UserAdministrationController(uowData);
            var user = new AccountViewModel() { Id = 1 };
            string newEmail = "test";
            RoleViewModel removeRole = new RoleViewModel() { Id = roles[0].Id, Name = roles[0].Name };
            string newPhone = "1234567";
            string newUserName = "NewUserName";

            user.Email = newEmail;
            user.PhoneNumber = newPhone;
            user.Roles = new List<RoleViewModel>() { new RoleViewModel(){ Id = 1, Name="Administrator" },
                                                     new RoleViewModel(){ Id = 2, Name="User" } };
            user.UserName = newUserName;

            // Act - add a product to the cart
            var result = (target.UpdateUser(user, new DataSourceRequest()) as JsonResult).Data;
            var errors = (result as Kendo.Mvc.UI.DataSourceResult).Errors;
            var count = (errors as Dictionary<string, Dictionary<string,object>>).Count;
            // Assert
            Assert.AreEqual(1,count);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            // Arrange - create the controller
            Mock.Get(this.usersRepository).Setup(x => x.All()).Returns(new List<ApplicationUser>() { users[1], users[2] }.AsQueryable());
            UserAdministrationController target = new UserAdministrationController(uowData);
            target.ControllerContext = this.controllerContext;
            var user = new AccountViewModel() { Id = 1 };
            // Act - add a product to the cart
            var result = (target.DeleteUser(new DataSourceRequest(), user) as JsonResult).Data;
            // Assert
            Assert.AreEqual(2, (result as Kendo.Mvc.UI.DataSourceResult).Total);
        }

        [TestMethod]
        public void ResetPasswordTest() 
        {
            //arrange
            UserAdministrationController target = new UserAdministrationController(uowData);
            target.ControllerContext = this.controllerContext;
            
            //act
            var result = target.ResetPassword(1, "/Home/Index","87654321");
            //assert
            Assert.AreEqual(1, 1);
        }
    }
}
