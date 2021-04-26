using NUnit.Framework;
using MIVisitorCenter;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using MIVisitorCenter.Data.Abstract;
using Moq;


namespace MIVisitorCenter.Tests
{
    [TestFixture]
    public class UploadImageVerify
    {
        private static IFormFile MakeInvalidFile()
        {
            IFormFile file = new FormFile(
                new MemoryStream(
                    Encoding.UTF8.GetBytes("This is a faked file")),
                    0,
                    0,
                    "Data",
                    "dummy.file");
            return file;
        }

        private static Business MakeValidBusiness()
        {
            return new Business
            {
                Name = "MI Business",
                Description = "Lorem ipsum dolor",
                Phone = "503-555-1234",
                Website = "www.business.com",
                PictureFileName = null
            };
        }

        [Test]
        public void Image_FromFactoryShouldBeInvalid_False()
        {
            // Arrange
            IFormFile invalidFile = MakeInvalidFile();
            Mock<IBusinessRepository> mock = new();
            IBusinessRepository businessRepo = mock.Object;

            // Act
            bool isImage = businessRepo.formFileIsImage(invalidFile);

            // Assert
            Assert.IsFalse(isImage);

        }

        [Test]
        public void BusinessOwner_UploadsFileThatIsNotAnImageDoesntChangeProfilePicture_True()
        {
            // Arrange
            IFormFile invalidFile = MakeInvalidFile();
            Mock<IBusinessRepository> mock = new();
            IBusinessRepository businessRepo = mock.Object;
            Business b = MakeValidBusiness();

            // Act
            businessRepo.UpdateBusiness(b, invalidFile, null);

            // Assert
            Assert.That(b.PictureFileName == null);
        }

    }
}