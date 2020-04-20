using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq.Expressions;

namespace CDTS_Blazor.TCComponents
{
    public class TCInputTextBase : InputBase<string>
    {
        [Parameter] public string Id { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public Expression<Func<string>> ValidationFor { get; set; }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
