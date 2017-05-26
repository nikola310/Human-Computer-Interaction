using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class PasswordStrengthValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string;
            // Minimum and Maximum Length of field - 6 to 12 Characters
            if (password.Length < 6)
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Prekratka šifra.");
            }
            else if (password.Length > 16)
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Predugačka šifra.");
            }

            // Special Characters - Not Allowed
            // Spaces - Not Allowed
            /*if (!(password.All(c => char.(c) || char.IsDigit(c))))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Šifra mora imati ASCII karaktere.");
            }*/
            //ASCII VALIDATION RULE - DODATI NA SIFRU
            //Whitespace
            if (!(password.All(c => char.IsWhiteSpace(c))))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Šifra ne smije imati razmake.");
            }

            // Numeric Character - At least one character
            if (!password.Any(c => char.IsDigit(c)))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Šifra mora imati barem jedan broj.");
            }
            // At least one Capital Letter
            if (!password.Any(c => char.IsUpper(c)))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Šifra mora imati barem jedno veliko slovo.");
            }
            // Repetitive Characters - Allowed only two repetitive characters
            var repeatCount = 0;
            var lastChar = '\0';
            foreach (var c in password)
            {
                if (c == lastChar)
                    repeatCount++;
                else
                    repeatCount = 0;
                if (repeatCount == 2)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    return new ValidationResult(false, "Samo dva karaktera zaredom se mogu ponavljati.");
                }
                lastChar = c;
            }

            return new ValidationResult(true, null);
        }
    }
}
