using HCI_projekat2.Help;
using HCI_projekat2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for NewUserDialog.xaml
    /// </summary>
    public partial class NewUserDialog : Window
    {
        MainWindow mW;
        UserModel model;

        public NewUserDialog(MainWindow mW)
        {
            this.mW = mW;
            model = new UserModel("", "");
            DataContext = model;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            UserModel user = new UserModel(usrName.Text, passwordBox.Password);
            MainWindow.Korisnici.Add(user);
            Close();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = passwordBox.Password;
            if (password.Length < 6)
            {
                System.Media.SystemSounds.Exclamation.Play();
                pswLabel.Content = "Prekratka šifra.";
                pswLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                regButton.IsEnabled = false;
                return;
            }
            else if (password.Length > 12)
            {
                System.Media.SystemSounds.Exclamation.Play();
                pswLabel.Content = "Predugačka šifra.";
                pswLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                regButton.IsEnabled = false;
                return;
            }

            foreach (char c in password)
            {
                if (c > 255)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    pswLabel.Content = "Samo ASCII karakteri su podržani.";
                    pswLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    regButton.IsEnabled = false;
                    return;
                }
                if (c == ' ')
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    pswLabel.Content = "Šifra ne smije imati razmake.";
                    pswLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    regButton.IsEnabled = false;
                    return;
                }
            }
            if (!password.Any(c => char.IsDigit(c)))
            {
                System.Media.SystemSounds.Exclamation.Play();
                pswLabel.Content = "Šifra mora imati barem jedan broj.";
                pswLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                regButton.IsEnabled = false;
                return;
            }
            if (!password.Any(c => char.IsUpper(c)))
            {
                System.Media.SystemSounds.Exclamation.Play();
                pswLabel.Content = "Šifra mora imati barem jedno veliko slovo.";
                pswLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                regButton.IsEnabled = false;
                return;
            }
            pswLabel.Content = "OK";
            pswLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 153, 76));
            regButton.IsEnabled = true;
            return;
        }

        private void confirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!passwordBox.Password.Equals(confirmPassword.Password))
            {
                System.Media.SystemSounds.Exclamation.Play();
                pswConfirmLabel.Content = "Šifre nisu iste.";
                pswConfirmLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return;
            }
            pswConfirmLabel.Content = "OK";
            pswConfirmLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 153, 76));
            regButton.IsEnabled = true;
            return;
        }

        private void Help_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("newUser", this);
        }
    }
}
