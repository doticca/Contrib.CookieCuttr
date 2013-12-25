using System;
using JetBrains.Annotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Contrib.CookieCuttr.Models;
using Orchard;

namespace Contrib.CookieCuttr.Drivers {
    [UsedImplicitly]
    public class CookieCuttrPartDriver : ContentPartDriver<CookiecuttrPart> {
        private readonly IWorkContextAccessor _workContextAccessor;

        public CookieCuttrPartDriver(
            IWorkContextAccessor workContextAccessor
            ) 
        {
                _workContextAccessor = workContextAccessor;
        }

        protected override DriverResult Display(CookiecuttrPart part, string displayType, dynamic shapeHelper)
        {
            var workContext = _workContextAccessor.GetContext();
            var cookieSettings = workContext.CurrentSite.As<CookiecuttrSettingsPart>().Record;

            return ContentShape("Parts_Cookiecuttr",
                            () => shapeHelper.Parts_Cookiecuttr(CookieSettings: cookieSettings));
        }
    }
}