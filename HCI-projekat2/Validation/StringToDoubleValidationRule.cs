using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    public class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                decimal r;
                if(decimal.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid double value.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class MinValidationRule : ValidationRule
    {
        public double Min
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is double)
            {
                double d = (double)value;
                if (d < Min) return new ValidationResult(false, "Value too small.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
