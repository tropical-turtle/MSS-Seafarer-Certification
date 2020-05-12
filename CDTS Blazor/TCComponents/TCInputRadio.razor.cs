using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace CDNApplication.TCComponents
{
    public class TCInputRadioBase<T> : InputBase<T>
    {
        [Parameter] public T SelectedValue { get; set; }
        [Parameter] public string Id { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public Expression<Func<T>> ValidationFor { get; set; }

        protected void OnChange(ChangeEventArgs args)
        {
            if (args != null)
            {
                CurrentValueAsString = args.Value.ToString();
            }
        }
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            var success = BindConverter.TryConvertTo<T>(value, CultureInfo.CurrentCulture, out var parsedValue);
            if (success)
            {
                result = parsedValue;
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default;
                validationErrorMessage = $"{FieldIdentifier.FieldName} field isn't valid.";
                return false;
            }
        }
    }
}
