namespace CDNApplication.Data.Services
{
    using System;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;

    public class CustomRequestCultureProvider : RequestCultureProvider
    {
        private string culture = "en-CA";

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext != null)
            {
                if (httpContext.Request.Path.Value.StartsWith("/en", StringComparison.OrdinalIgnoreCase))
                {
                    this.culture = "en-CA";
                }

                if (httpContext.Request.Path.Value.StartsWith("/fr", StringComparison.OrdinalIgnoreCase))
                {
                    this.culture = "fr-CA";
                }

                return Task.FromResult(new ProviderCultureResult(this.culture));
            }
            else
            {
                return Task.FromResult(new ProviderCultureResult(this.culture));
            }
        }
    }
}
