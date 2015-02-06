using POC_WhySPA.Areas.MusicSpa.Models.Albums;
using StructureMap;

namespace POC_WhySPA
{
    public static class StructureMapContainerFactory
    {
        public static Container Get()
        {
            var container = new Container(x =>
            {
                x.For<IAlbumsRepository>().Use<AlbumsRepository>();
            });
            return container;
        }
    }
}