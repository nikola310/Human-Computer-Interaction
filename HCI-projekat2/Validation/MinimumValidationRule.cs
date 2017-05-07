using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                 if (d < Min) return new ValidationResult(false, "Premali broj.");
                 return new ValidationResult(true, null);
             }
             else
             {
                 return new ValidationResult(false, "Unknown error occured.");
             }
            /*double r;
            if (double.TryParse(value as string, out r))
            {
                double d = r;
                if (d < Min) return new ValidationResult(false, "Premali broj.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown error occured.");
            }*/
        }
    }
}
