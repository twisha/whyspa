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

            bundles.Add(new ScriptBundle("~/bundles/oldIEBrowsersSupport").Include("~/Scripts/respond.js")
                                                                          .Include("~/Scripts/html5shiv.js"));

            //AngularJs
            bundles.Add(
                new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.js")
                                                     .Include("~/Scripts/angular-route.js"));

            //ngTable
            bundles.Add(
                new StyleBundle("~/Content/ngtable").Include("~/bower_components/ng-table/ng-table.css"));
            bundles.Add(
                new ScriptBundle("~/bundles/ngtable").Include("~/bower_components/ng-table/ng-table.js"));

            //AngularJs Scripts - Music Albums Module
            bundles.Add(
                new ScriptBundle("~/bundles/angularMusicAlbums").Include(
                    "~/Scripts/MusicSpa/Albums/Shared/musicAlbumsModule.js")
                                                                .Include(
                                                                    "~/Scripts/MusicSpa/Albums/Shared/musicAlbumsRouteConfig.js")
                                                                .Include(
                                                                    "~/Scripts/MusicSpa/Albums/Shared/musicAlbumsLookupService.js")
                                                                .Include(
                                                                    "~/Scripts/MusicSpa/Albums/Shared/musicAlbumsNavigationService.js")
                                                                .Include(
                                                                    "~/Scripts/MusicSpa/Albums/List/musicAlbumsService.js")
                                                                .Include(
                                                                    "~/Scripts/MusicSpa/Albums/List/musicAlbumsController.js")
                                                                .Include(
                                                                    "~/Scripts/MusicSpa/Albums/Edit/musicAlbumEditService.js")
                                                                .Include(
                                                                    "~/Scripts/MusicSpa/Albums/Edit/musicAlbumEditController.js"));
            //AngularJs Scripts - Movie DVDs Module
            bundles.Add(new ScriptBundle("~/bundles/angularMovieDvds").Include(
                "~/Scripts/MusicSpa/MovieDvds/Shared/movieDvdsModule.js")
                                                                      .Include(
                                                                          "~/Scripts/MusicSpa/MovieDvds/Shared/movieDvdsRouteConfig.js")
                                                                      .Include(
                                                                          "~/Scripts/MusicSpa/MovieDvds/Shared/movieDvdsLookupService.js")
                                                                      .Include(
                                                                          "~/Scripts/MusicSpa/MovieDvds/Shared/movieDvdsNavigationService.js")
                                                                      .Include(
                                                                          "~/Scripts/MusicSpa/MovieDvds/List/movieDvdsService.js")
                                                                      .Include(
                                                                          "~/Scripts/MusicSpa/MovieDvds/List/movieDvdsController.js")
                                                                      .Include(
                                                                          "~/Scripts/MusicSpa/MovieDvds/Edit/movieDvdEditService.js")
                                                                      .Include(
                                                                          "~/Scripts/MusicSpa/MovieDvds/Edit/movieDvdEditController.js"));
            //app
            bundles.Add(new StyleBundle("~/Content/app").Include("~/Content/app.css"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/app.js"));
        }
    }
}