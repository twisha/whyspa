using System.Web.Mvc;
using MvcContrib.TestHelper;
using NUnit.Framework;
using POC_WhySPA.Areas.MusicSpa.Controllers;

namespace POC_WhySPA.Test.Mvc.MusicSpa.Albums
{
    [TestFixture]
    public class AlbumsControllerTests
    {
        private AlbumsController _controller;

        [TestFixtureSetUp]
        public void Setup()
        {
            _controller = ControllerFactory<AlbumsController>.Get();
        }

        [Test]
        public void Index_Get_ReturnsView()
        {
            ActionResult actionResult = _controller.Index();
            var viewResult = actionResult.AssertViewRendered().ForView("");
            Assert.IsNull(viewResult.Model);
        }

        [Test]
        public void List_Get_ReturnsPartialView()
        {
            ActionResult actionResult = _controller.List();
            var partialViewResult = actionResult.AssertPartialViewRendered().ForView("");
            Assert.IsNull(partialViewResult.Model);
        }

        [Test]
        public void Edit_Get_ReturnsPartialView()
        {
            ActionResult actionResult = _controller.Edit();
            var partialViewResult = actionResult.AssertPartialViewRendered().ForView("");
            Assert.IsNull(partialViewResult.Model);
        }
    }
}
