using Contrib.CookieCuttr.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contrib.CookieCuttr.Handlers
{
    public class CookiecuttrSettingsPartHandler : ContentHandler
    {
        public CookiecuttrSettingsPartHandler(IRepository<CookiecuttrSettingsPartRecord> repository)
        {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<CookiecuttrSettingsPart>("Site"));
            Filters.Add(StorageFilter.For(repository));

            OnInitializing<CookiecuttrSettingsPart>((context, part) =>
            {
                    part.cookieNotificationLocationBottom= false;           
                    part.cookieAnalytics= true;                             
                    part.cookieAnalyticsMessage = CookiecuttrMigrations.cookieanalyticsmsg;
                    part.cookiePolicyLink= string.Empty;              
                    part.showCookieDeclineButton= false;              
                    part.showCookieAcceptButton= true;               
                    part.showCookieResetButton= false;                
                    part.cookieOverlayEnabled= false;                 
                    part.cookieMessage = CookiecuttrMigrations.cookiemsg;
                    part.cookieWhatAreTheyLink= CookiecuttrMigrations.whatarecookieslink;          
                    part.cookieCutter= false;
                    part.cookieErrorMessage = CookiecuttrMigrations.errormsg;             
                    part.cookieDisable= string.Empty;                  
                    part.cookieAcceptButtonText= CookiecuttrMigrations.acceptmsg;
                    part.cookieDeclineButtonText = CookiecuttrMigrations.declinemsg;
                    part.cookieResetButtonText = CookiecuttrMigrations.resetmsg;
                    part.cookieWhatAreLinkText = CookiecuttrMigrations.whataremsg;          
                    part.cookiePolicyPage= false;                      
                    part.cookiePolicyPageMessage= string.Empty;        
                    part.cookieDiscreetLink= false;                    
                    part.cookieDiscreetLinkText= string.Empty;         
                    part.cookieDiscreetPosition= "topleft";            
                    part.cookieDomain= string.Empty;
                    part.cookieDiscreetReset = false;
            });
        }

        public Localizer T { get; set; }

        protected override void GetItemMetadata(GetContentItemMetadataContext context)
        {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Cookies")));
        }
    }
}