using Orchard.UI.Resources;

namespace Contrib.CookieCuttr {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            manifest.DefineScript("jQueryCookie")
                .SetUrl("jquery.cookie.min.js", "jquery.cookie.js")
                .SetDependencies("jQuery")
                .SetVersion("1.4.0");

            manifest.DefineScript("CookieCuttr")
                .SetUrl("jquery.cookiecuttr.min.js", "jquery.cookiecuttr.js")
                .SetDependencies("jQueryCookie", "jQuery")
                .SetVersion("1.0.0");

            manifest.DefineStyle("CookieCuttr")
                .SetUrl("cookiecuttr.css")
                .SetVersion("1.0.0");
        }
    }
}
