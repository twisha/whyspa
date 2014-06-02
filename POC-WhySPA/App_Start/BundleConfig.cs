using System.Web.Optimization;

namespace POC_WhySPA
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bootstrap
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));

            //IE8 with Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/oldIEBrowsersSupport").Include("~/Scripts/respond.js")
                .Include("~/Scripts/html5shiv.js")
                .Include("~/bower_components/es5-shim/es5-shim.js")
                .Include("~/Scripts/angular-ui-bootstrap-ie8.js"));

            //AngularJs
            bundles.Add(
                new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.js")
                    .Include("~/Scripts/angular-route.js"));

            //Angular.UI.Bootstrap
            bundles.Add(
                new ScriptBundle("~/bundles/angularUIBootstrap").Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

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
            //AngularJs Scripts - AngularJs UI Bootstrap Module
            bundles.Add(
                new ScriptBundle("~/bundles/angularUIBootstrapExamples").Include(
                    "~/Scripts/MusicSpa/AngularUIBootstrapExamples/Shared/angularUIBootstrapExamplesModule.js")
                    .Include(
                        "~/Scripts/MusicSpa/AngularUIBootstrapExamples/Shared/angularUIBootstrapExamplesRouteConfig.js")
                    .Include(
                        "~/Scripts/MusicSpa/AngularUIBootstrapExamples/Accordian/angularUIAccordianController.js")
                    .Include(
                        "~/Scripts/MusicSpa/AngularUIBootstrapExamples/Modal/angularUIModalController.js")
                    .Include(
                        "~/Scripts/MusicSpa/AngularUIBootstrapExamples/Carousel/angularUICarouselController.js"));
            //app
            bundles.Add(new StyleBundle("~/Content/app").Include("~/Content/app.css"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/app.js"));

            //Angular Spinner
            bundles.Add(
                new StyleBundle("~/Content/angular-loading-bar").Include(
                    "~/bower_components/angular-loading-bar/src/loading-bar.css"));
            bundles.Add(
                new ScriptBundle("~/bundles/angular-loading-bar").Include(
                    "~/bower_components/angular-loading-bar/src/loading-bar.js"));
        }
    }
}