using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    public class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string s = (string) value;
                Regex r = new Regex(@"^[0-9]*([.,][0-9]+)?$");

                if (r.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Morate uneti broj.");
            }
            catch
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Došlo je do greške.");
            }
        }
    }


}
