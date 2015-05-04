using System;
using FileUpload.Data;
using FileUpload.Data.Abstract;
using FileUpload.Data.Concrete;
using FileUpload.Models.FileModels;
using FileUpload.Models.Identity;
using FileUpload.Models.LogModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileUpload.Tests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void GetFileRepositoryTest()
        {
            //arrange
            using (IUowData uow = new UowData())
            {
                IRepository<FileDescription, int> fileRopository = new FileDescriptionRepository(new ApplicationDbContext());
                //act
                var uowRepository = uow.FileDescriptions;
                //assert
                Assert.AreEqual(fileRopository.GetType(), uowRepository.GetType());
            }
        }

        [TestMethod]
        public void GetUserRepositoryTest()
        {
            //arrange
            IUowData uow = new UowData();
            IRepository<ApplicationUser, int> userRepository = new GenericRepository<ApplicationUser, int>(new ApplicationDbContext());
            //act
            var uowRepository = uow.Users;
            //assert
            Assert.AreEqual(userRepository.GetType(), uowRepository.GetType());
        }

        [TestMethod]
        public void GetRoleRepositoryTest()
        {
            //arrange
            IUowData uow = new UowData();
            IRepository<RoleIntPk, int> roleRepository = new GenericRepository<RoleIntPk, int>(new ApplicationDbContext());
            //act
            var uowRepository = uow.Roles;
            //assert
            Assert.AreEqual(roleRepository.GetType(), uowRepository.GetType());
        }

        [TestMethod]
        public void GetUloadResultRepositoryTest()
        {
            //arrange
            IUowData uow = new UowData();
            IRepository<UploadResult, int> uploadResultRepository = new GenericRepository<UploadResult, int>(new ApplicationDbContext());
            //act
            var uowRepository = uow.UploadResults;
            //assert
            Assert.AreEqual(uploadResultRepository.GetType(), uowRepository.GetType());
        }
        
        [TestMethod]
        public void GetTraceLogMessageRepositoryTest()
        {
            //arrange
            IUowData uow = new UowData();
            IRepository<TraceLogMessage, int> traceLogMessageRepository = new GenericRepository<TraceLogMessage, int>(new ApplicationDbContext());
            //act
            var uowRepository = uow.TraceLogMessages;
            //assert
            Assert.AreEqual(traceLogMessageRepository.GetType(), uowRepository.GetType());
        }
    }
}
