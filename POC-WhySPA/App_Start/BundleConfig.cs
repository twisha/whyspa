using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace POC_WhySPA.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            //bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));

            //AngularJs
            bundles.Add(
                new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.js")
                                                     .Include("~/Scripts/angular-route.js"));
            //Music Albums AngularJs Scripts
            bundles.Add(
                new ScriptBundle("~/bundles/angularMusicAlbums").Include("~/Scripts/MusicSpa/Albums/Shared/musicAlbumsModule.js")
                .Include("~/Scripts/MusicSpa/Albums/Shared/musicAlbumsRouteConfig.js")
                                                                .Include("~/Scripts/MusicSpa/Albums/Shared/musicAlbumsLookupService.js")
                                                                .Include("~/Scripts/MusicSpa/Albums/Shared/musicAlbumsNavigationService.js")
                                                                .Include("~/Scripts/MusicSpa/Albums/List/musicAlbumsService.js")
                                                                .Include("~/Scripts/MusicSpa/Albums/List/musicAlbumsController.js")
                                                                .Include("~/Scripts/MusicSpa/Albums/Edit/musicAlbumEditService.js")
                                                                .Include("~/Scripts/MusicSpa/Albums/Edit/musicAlbumEditController.js"));
        }
    }
}