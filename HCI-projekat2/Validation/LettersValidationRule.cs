using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class LettersValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tmp = value as string;
            foreach (char c in tmp)
            {
                if ((c < 65 || c > 90) && (c < 97 || c > 122))
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    return new ValidationResult(false, "Morate uneti ASCII slovo.");
                }
            }
            return new ValidationResult(true, null);
        }
    }
}
