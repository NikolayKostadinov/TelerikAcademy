using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FileUpload.Controllers;
using FileUpload.Data;
using FileUpload.Models.FileModels;
using FileUpload.Models.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FileUpload.Tests
{
    [TestClass]
    public class FileUploadControllerTests
    {
        private IUowData uowData;
        private IRepository<FileDescription, int> fileRepository;
        private IRepository<UploadResult, int> uploadResultsRepository;
        private IList<FileDescription> files;
        private ICollection<UploadResult> uploadResults;
        public FileUploadControllerTests()
        {
            this.files = new List<FileDescription>()
            {
                new FileDescription(){ Id = 1, FileName="File1", Size = 1, UserId = 1, ApplicationUser = new ApplicationUser(){ UserName = "test1"}},
                new FileDescription(){ Id = 2, FileName="File2", Size = 1, UserId = 2, ApplicationUser = new ApplicationUser(){ UserName = "test2"}},
                new FileDescription(){ Id = 3, FileName="File3", Size = 1, UserId = 1, ApplicationUser = new ApplicationUser(){ UserName = "test1"}},
            };

            this.uploadResults = new List<UploadResult>();
            
            int id = 1;
            foreach (var file in this.files)
	        {
		        this.uploadResults.Add(new UploadResult(){ Id=id++, FileId = file.Id, File = file, Message="UploadDescription1", RowNumber=1, Status=Status.Ok});
                this.uploadResults.Add(new UploadResult(){ Id=id++, FileId = file.Id, File = file, Message="UploadDescription2", RowNumber=2, Status=Status.Warning});
                this.uploadResults.Add(new UploadResult(){ Id=id++, FileId = file.Id, File = file, Message="UploadDescription3", RowNumber=3, Status=Status.Error});
	        }

            foreach (var ur in this.uploadResults)
            {
                this.files[ur.FileId-1].UploadResults.Add(ur);
            }

            //Create Mock repositories
            Mock<IRepository<FileDescription, int>> mockFileDescriptionRepository = new Mock<IRepository<FileDescription, int>>();
            mockFileDescriptionRepository.Setup(r => r.All()).Returns(this.files.AsQueryable());
            mockFileDescriptionRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns((int x) => (this.files[x - 1]));
            Mock<IRepository<UploadResult,int>> mockUploadResultRepository = new Mock<IRepository<UploadResult,int>>();
            mockUploadResultRepository.Setup(r => r.All()).Returns(this.uploadResults.AsQueryable());

            //initializing repositories
            this.fileRepository = mockFileDescriptionRepository.Object;
            this.uploadResultsRepository = mockUploadResultRepository.Object;

            //Create UowData
            Mock<IUowData> mockUow = new Mock<IUowData>();
            mockUow.Setup(uow => uow.FileDescriptions).Returns(this.fileRepository);
            mockUow.Setup(uow => uow.UploadResults).Returns(this.uploadResultsRepository);
            this.uowData = mockUow.Object;
        }

        /// <summary>
        /// Applications the user.
        /// </summary>
        /// <returns></returns>
        private ApplicationUser ApplicationUser()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetAllFilesTest()
        {
            //arrange
            FileUpploadController target = new FileUpploadController(this.uowData);
            //act
            var result = target.GetUploadedFiles(new Kendo.Mvc.UI.DataSourceRequest()) as JsonResult;
            var files = (Kendo.Mvc.UI.DataSourceResult)result.Data;
            int filesCount = 0;
            foreach (var file in files.Data)
            {
                filesCount++;
            }
            //assert
            Assert.AreEqual(3, filesCount);
        }

        [TestMethod]
        public void GetUploadedFileDetailsTest()
        {
            FileUpploadController target = new FileUpploadController(this.uowData);
            //act
            var result = target.GetUploadedFileDetails(new Kendo.Mvc.UI.DataSourceRequest(), 3) as JsonResult;

            var results = (Kendo.Mvc.UI.DataSourceResult)result.Data;
            int filesCount = 0;
            foreach (var upploadResult in results.Data)
            {
                filesCount++;
            }
            //assert
            Assert.AreEqual(3, filesCount);
        }

        [TestMethod]
        public void GetUploadedFileResultsTest()
        {
            FileUpploadController target = new FileUpploadController(this.uowData);
            //act
            var result = target.GetUploadResults(new Kendo.Mvc.UI.DataSourceRequest(), 3) as JsonResult;

            var results = (Kendo.Mvc.UI.DataSourceResult)result.Data;
            int filesCount = 0;
            foreach (var upploadResult in results.Data)
            {
                filesCount++;
            }
            //assert
            Assert.AreEqual(3, filesCount);
        }
    }
}
