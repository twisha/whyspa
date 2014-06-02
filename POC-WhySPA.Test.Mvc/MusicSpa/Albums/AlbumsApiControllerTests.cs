using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using POC_WhySPA.Areas.MusicSpa.Controllers;
using POC_WhySPA.Areas.MusicSpa.Models.Albums;

namespace POC_WhySPA.Test.Mvc.MusicSpa.Albums
{
    [TestFixture]
    public class AlbumsApiControllerTests
    {
        private AlbumsApiController _apiController = null;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _apiController = new AlbumsApiController();
        }

        [Test]
        public void GetAlbum_ByValidId_ShouldReturnAlbum()
        {
            //Arrange
            var mockAlbumsRepository = new Mock<IAlbumsRepository>();
            _apiController.AlbumsRepository = mockAlbumsRepository.Object;

            const int testAlbumId = 2;
            var testAlbum = new AlbumDetail
            {
                Id = testAlbumId,
                Title = "Test Album",
                Price = (decimal)2.56,
                Artist = new KeyValuePair<int, string>(1, "Artist 1"),
                Genre = new KeyValuePair<int, string>(2, "Genre 2")
            };
            mockAlbumsRepository.Setup(x => x.Get(testAlbumId)).Returns(testAlbum);
            //Act
            var album = _apiController.Get(testAlbumId);
            //Assert
            Assert.IsNotNull(album);
            Assert.AreEqual(testAlbum, album);
            mockAlbumsRepository.Verify(x => x.Get(It.Is<int>(a => a == testAlbumId)), Times.Once, "Missing mandatory call to repository to get album");
        }

        [Test]
        [ExpectedException(typeof(HttpResponseException))]
        public void GetAlbum_ByInvalidId_ShouldThrowHttpNotFoundExpection()
        {
            //Arrange
            var mockAlbumsRepository = new Mock<IAlbumsRepository>();
            _apiController.AlbumsRepository = mockAlbumsRepository.Object;

            const int testAlbumId = 2;
            mockAlbumsRepository.Setup(x => x.Get(testAlbumId)).Returns((AlbumDetail) null);
            //Act
            try
            {
                _apiController.Get(testAlbumId);
                //Assert
                mockAlbumsRepository.Verify(x => x.Get(It.Is<int>(a => a == testAlbumId)), Times.Once, "Missing mandatory call to repository to get album");
            }
            catch (HttpResponseException ex)
            {
                //Assert
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.NotFound);
                throw;
            }
        }

        [Test]
        public void PutAlbum_WhenExists_ShouldUpdateAlbum()
        {
            //Arrange
            var mockAlbumsRepository = new Mock<IAlbumsRepository>();
            _apiController.AlbumsRepository = mockAlbumsRepository.Object;

            const int testAlbumId = 2;
            var testAlbum = new AlbumDetail
            {
                Id = testAlbumId,
                Title = "Test Album",
                Price = (decimal)2.56,
                Artist = new KeyValuePair<int, string>(1, "Artist 1"),
                Genre = new KeyValuePair<int, string>(2, "Genre 2")
            };
            mockAlbumsRepository.Setup(x => x.CheckAlbumExists(testAlbumId)).Returns(true);
            mockAlbumsRepository.Setup(x => x.Save(testAlbum));
            //Act
            _apiController.Put(testAlbumId, testAlbum);
            //Assert
            mockAlbumsRepository.Verify(x => x.CheckAlbumExists(It.Is<int>(a => a == testAlbumId)), Times.Once,
               "Missing mandatory call to repository to check whether album exists");
            mockAlbumsRepository.Verify(x => x.Save(It.Is<AlbumDetail>(a => a == testAlbum)), Times.Once,
                "Missing mandatory call to repository to save album");
        }

        [Test]
        [ExpectedException(typeof(HttpResponseException))]
        public void PutAlbum_WhenNotExists_ShouldThrowHttpNotFoundException()
        {
            //Arrange
            var mockAlbumsRepository = new Mock<IAlbumsRepository>();
            _apiController.AlbumsRepository = mockAlbumsRepository.Object;

            const int testAlbumId = 2;
            mockAlbumsRepository.Setup(x => x.CheckAlbumExists(testAlbumId)).Returns(false);
            //Act
            try
            {
                _apiController.Put(testAlbumId, null);
                //Assert
                mockAlbumsRepository.Verify(x => x.CheckAlbumExists(It.Is<int>(a => a == testAlbumId)), Times.Once,
                    "Missing mandatory call to repository to check whether album exists");
            }
            catch (HttpResponseException ex)
            {
                //Assert
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.NotFound);
                throw;
            }
        }
    }
}
