using System.Globalization;
using System.Windows.Controls;

namespace BarcodeReader.Toolkit.MVVM.Validators
{
    public sealed class IpPartValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "IP cannot be empty.");

            var parsed = int.TryParse(value.ToString(), out int ipValue);
            if (!parsed)
                return new ValidationResult(false, "IP must be a number");

            if (ipValue < 0 || ipValue > 255)
                return new ValidationResult(false, "IP value can not be less than 0 or mere than 255.");


            return ValidationResult.ValidResult;
        }
    }
}