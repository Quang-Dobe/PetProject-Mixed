using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;

namespace PetProject.Razor.Components.IFSComponents
{
    public class IfsInputAmount<TValue> : InputNumber<TValue>
    {
        private string? _stepAttributeValue;
        private string? _rawValue;

        [Parameter]
        public int DecimalPlaces { get; set; } = 2;

        protected override void OnInitialized()
        {
            _stepAttributeValue = GetStepAttributeValue();
            _rawValue = string.Empty;

            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            if (!string.IsNullOrEmpty(_rawValue))
            {
                CurrentValue = (TValue)Convert.ChangeType(_rawValue, typeof(TValue));
            }

            base.OnParametersSet();
        }

        protected override string? FormatValueAsString(TValue? value)
        {
            switch (value)
            {
                case decimal @decimal:
                    return @decimal.ToString("F" + DecimalPlaces, CultureInfo.InvariantCulture) ?? string.Empty;
            }

            return base.FormatValueAsString(value);
        }

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            var parsedValue = string.Empty;
            if (decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, out var price))
            {
                parsedValue = price.ToString();
            }

            return base.TryParseValueFromString(parsedValue, out result, out validationErrorMessage);
        }

        private string FormatValueAsString(decimal value)
        {
            var format = "#,##0." + new string('0', DecimalPlaces);
            return value.ToString(format);
        }

        private bool ParseFormattedString(string formattedString)
        {
            string cleanedString = formattedString.Replace(",", "");

            return decimal.TryParse(cleanedString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result);
        }

        private static string GetStepAttributeValue()
        {
            // Unwrap Nullable<T>, because InputBase already deals with the Nullable aspect
            // of it for us. We will only get asked to parse the T for nonempty inputs.
            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
            if (targetType == typeof(int) ||
                targetType == typeof(long) ||
                targetType == typeof(short) ||
                targetType == typeof(float) ||
                targetType == typeof(double) ||
                targetType == typeof(decimal))
            {
                return "any";
            }
            else
            {
                throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
            }
        }
    }
}
