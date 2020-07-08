namespace CDNApplication.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.JSInterop;

    public class UserPreference
    {
        public string LanguagePreference { get; set; }

        public string Culture { get; set; }
    }
}
