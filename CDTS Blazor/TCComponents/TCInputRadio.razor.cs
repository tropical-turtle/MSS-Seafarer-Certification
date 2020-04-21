using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;

namespace CDTS_Blazor.TCComponents
{
    public class TCInputRadioBase<T> : InputBase<T>
    {
        [Parameter] public T SelectedValue { get; set; }

        protected void OnChange(ChangeEventArgs args)
        {
            CurrentValueAsString = args.Value.ToString();
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
