using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoC.WebTemplate.Components.Core.Services;
using GoC.WebTemplate.Components.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CDNApplication.Middleware
{
    public class PageSettingsMiddleware
    {
        private readonly RequestDelegate _next;
        public PageSettingsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ModelAccessor modelAccessor)
        {
            // Perhaps we can fail more gracefully then just throwing an exception
            if (modelAccessor == null)
                throw new ArgumentNullException(nameof(modelAccessor));

            //add page settings like: Modified Date, Breadcrumbs, Culture, Title etc.
            modelAccessor.Model.DateModified = DateTime.Now.Date;
            modelAccessor.Model.HeaderTitle = "Seafarer Credentials Online Prototype";
            List<Breadcrumb> breadcrumbs = new List<Breadcrumb>();
            breadcrumbs.Add(new Breadcrumb { Href = "http://www.canada.ca/en/index.html", Title = "Canada.ca" });
            breadcrumbs.Add(new Breadcrumb { Href = "https://www.tc.gc.ca/en/services/marine.html", Title = "Marine Transportation" });
            breadcrumbs.Add(new Breadcrumb { Href = "/", Title = "Seafarer Credentials Online Prototype" });
            modelAccessor.Model.Breadcrumbs = breadcrumbs;
            modelAccessor.Model.LeftMenuItems = new List<MenuSection>();

            await _next.Invoke(context).ConfigureAwait(false);
        }
    }
    public static class PageSettingsMiddlewareExtension
    {
        public static IApplicationBuilder UsePageSettingsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PageSettingsMiddleware>();
        }
    }
}