﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POC_WhySPA.Areas.MusicSpa.Resources.Albums {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Albums {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Albums() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("POC_WhySPA.Areas.MusicSpa.Resources.Albums.Albums", typeof(Albums).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Artist.
        /// </summary>
        public static string HeaderArtistName {
            get {
                return ResourceManager.GetString("HeaderArtistName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Genre.
        /// </summary>
        public static string HeaderGenre {
            get {
                return ResourceManager.GetString("HeaderGenre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Price.
        /// </summary>
        public static string HeaderPrice {
            get {
                return ResourceManager.GetString("HeaderPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title.
        /// </summary>
        public static string HeaderTitle {
            get {
                return ResourceManager.GetString("HeaderTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Genres.
        /// </summary>
        public static string LabelGenres {
            get {
                return ResourceManager.GetString("LabelGenres", resourceCulture);
            }
        }
    }
}
