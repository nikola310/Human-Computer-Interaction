using System.Windows;
using HCI_projekat2.Model;
using Microsoft.Win32;
using static HCI_projekat2.MainWindow;
using System;
using System.Windows.Data;
using System.Windows.Controls;
using HCI_projekat2.Help;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for NewResourceType.xaml
    /// </summary>
    public partial class NewResourceType : Window
    {
        private TypeModel model;
        public NewResourceType()
        {
            model = new TypeModel();
            DataContext = model;
            InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dijalog = new OpenFileDialog();
            dijalog.Filter = "Slike (*.jpeg, *.jpg, *.png, *.ico)|*.jpeg; *.jpg; *.png; *.ico";
            bool? retVal = dijalog.ShowDialog();
            if (retVal == true)
            {
                string fajl = dijalog.FileName;
                model.IconPath = fajl;
            }

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression b = TipID.GetBindingExpression(TextBox.TextProperty);
            BindingExpression b1 = Ime.GetBindingExpression(TextBox.TextProperty);

            b.UpdateSource();
            b1.UpdateSource();

            
            if (b.HasError == false && b1.HasError == false)
            {
                if (model.IconPath == null || model.IconPath == "/Images/qmark2.png" || model.IconPath == "")
                {
                    MessageBoxResult message = MessageBox.Show(this, "Morate odabrati ikonu!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                    BrowseButton.Focus();
                    return;
                }


                if (model.Desc == null)
                {
                    model.Desc = "";
                }


                foreach (TypeModel tip in Tipovi.Values)
                {
                    if (tip.ID.Equals(TipID.Text))
                    {
                        MessageBoxResult message = MessageBox.Show(this, "Tip sa takvom ID oznakom vec postoji! Molimo vas, unesite drugi ID.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                        TipID.Focus();
                        return;
                    }
                }


                Tipovi.Add(model.ID, model);
                Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Change_Icon_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Browse_Click(sender, e);
        }

        private void Help_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("newType", this);
        }
    }
}

