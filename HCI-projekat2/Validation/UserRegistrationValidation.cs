using HCI_projekat2.Model;
using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class UserRegistrationValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;
            if (Exists(name))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Već postoji korisnik s tim imenom.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }

        private bool Exists(string name)
        {
            foreach(UserModel model in MainWindow.Korisnici)
            {
                if (model.Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
