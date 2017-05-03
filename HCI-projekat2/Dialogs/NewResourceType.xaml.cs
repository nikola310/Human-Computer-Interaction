using System.Windows;
using HCI_projekat2.Model;
using Microsoft.Win32;
using static HCI_projekat2.MainWindow;
using System;

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
            if (model.Name == "")
            {
                MessageBoxResult message = MessageBox.Show(this, "Morate uneti ime tipa!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                Ime.Focus();
                return;
            }
            if (model.ID == "")
            {
                MessageBoxResult message = MessageBox.Show(this, "Morate uneti ID tipa!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                TipID.Focus();
                return;
            }
            if (model.IconPath == null || model.IconPath == "")
            {
                MessageBoxResult message = MessageBox.Show(this, "Morate odabrati ikonu tipa!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
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

            model.Gid = Guid.NewGuid();
            Tipovi.Add(model.Gid, model);
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}

