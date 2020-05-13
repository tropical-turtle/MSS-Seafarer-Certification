using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq.Expressions;

namespace CDNApplication.TCComponents
{
    public class TCInputTextBase : InputBase<string>
    {
        [Parameter] public string Id { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public TextInputType TextInputType { get; set; } = TextInputType.TEXT;
        [Parameter] public Expression<Func<string>> ValidationFor { get; set; }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }

        public string TextInputTypeString()
        {
            switch(this.TextInputType)
            {
                case TextInputType.DATE:
                    return "date";
                case TextInputType.DATETIMELOCAL:
                    return "datetime-local";
                case TextInputType.EMAIL:
                    return "email";
                case TextInputType.MONTH:
                    return "month";
                case TextInputType.NUMBER:
                    return "number";
                case TextInputType.PASSWORD:
                    return "password";
                case TextInputType.SEARCH:
                    return "search";
                case TextInputType.TEL:
                    return "tel";
                case TextInputType.TIME:
                    return "time";
                case TextInputType.URL:
                    return "url";
                case TextInputType.WEEK:
                    return "week";
                case TextInputType.TEXT:
                default:
                    return "text";
            }
        }
    }
}
