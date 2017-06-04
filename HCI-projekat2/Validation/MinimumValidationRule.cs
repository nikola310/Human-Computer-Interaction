using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class MinimumValidationRule : ValidationRule
    {
        public double Min
        {
            get; set;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

             if (value is double)
             {
                 double d = (double)value;
                 if (d < Min) return new ValidationResult(false, "Broj je premali.");
                 return new ValidationResult(true, null);
             }
             else
             {
                 return new ValidationResult(false, "Došlo je do greške.");
             }
        }
    }
}
