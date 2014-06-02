using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using POC_WhySPA.Areas.MusicSpa.Controllers;
using POC_WhySPA.Areas.MusicSpa.Models.Albums;

namespace POC_WhySPA.Test.Mvc.MusicSpa.Albums
{
    [TestFixture]
    public class AlbumsSearchApiControllerTests
    {
        private AlbumsSearchApiController _apiController = null;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _apiController = new AlbumsSearchApiController();
        }

        [Test]
        public void GetAlbums_ByValidGenreId_ShouldReturnAlbums()
        {
            //Arrange
            var mockAlbumsRepository = new Mock<IAlbumsRepository>();
            _apiController.AlbumsRepository = mockAlbumsRepository.Object;

            const int testGenreId = 2;
            var testAlbums = new List<AlbumSummary>
            {
                new AlbumSummary {Id = 1, Artist = "Artist 1", Genre = "Genre 1", Price = 3, Title = "Test Album 1"},
                new AlbumSummary {Id = 2, Artist = "Artist 1", Genre = "Genre 1", Price = 5, Title = "Test Album 2"},
            };
            mockAlbumsRepository.Setup(x => x.Search(testGenreId)).Returns(testAlbums);
            //Act
            var albums = _apiController.Get(testGenreId);
            //Assert
            Assert.IsNotNull(albums);
            Assert.AreEqual(testAlbums.Count, albums.Count());
            Assert.AreEqual(testAlbums, albums);
            mockAlbumsRepository.Verify(x => x.Search(It.Is<int>(a => a == testGenreId)), Times.Once, "Missing mandatory call to repository to search albums");
        }

        [Test]
        public void GetAlbums_DefaultRequest_ShouldReturnAlbumsOfAllGenres()
        {
            //Arrange
            var mockAlbumsRepository = new Mock<IAlbumsRepository>();
            _apiController.AlbumsRepository = mockAlbumsRepository.Object;

            var testAlbums = new List<AlbumSummary>
            {
                new AlbumSummary {Id = 1, Artist = "Artist 1", Genre = "Genre 1", Price = 3, Title = "Test Album 1"},
                new AlbumSummary {Id = 2, Artist = "Artist 1", Genre = "Genre 1", Price = 5, Title = "Test Album 2"},
            };
            mockAlbumsRepository.Setup(x => x.Search(0)).Returns(testAlbums);
            //Act
            var albums = _apiController.Get();
            //Assert
            Assert.IsNotNull(albums);
            Assert.AreEqual(testAlbums.Count, albums.Count());
            Assert.AreEqual(testAlbums, albums);
            mockAlbumsRepository.Verify(x => x.Search(It.Is<int>(a => a == 0)), Times.Once, "Missing mandatory call to repository to search albums");
        }
    }
}
