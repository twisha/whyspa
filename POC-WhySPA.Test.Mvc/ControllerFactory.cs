using System.Web.Mvc;
using MvcContrib.TestHelper;

namespace POC_WhySPA.Test.Mvc
{
    public static class ControllerFactory<T> where T: Controller
    {
        public static T Get()
        {
            var builder = new TestControllerBuilder();
            var controller = builder.CreateController<T>();
            builder.InitializeController(controller);
            return controller;
        }
    }
}
