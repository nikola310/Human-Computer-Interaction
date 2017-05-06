using System.Collections.ObjectModel;
using System.Windows;
using HCI_projekat2.Model;
using static HCI_projekat2.MainWindow;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System;

namespace HCI_projekat2.Tabels
{

    public partial class TypeTable : Window
    {
        public TypeModel mod = new TypeModel();


        public ObservableCollection<TypeModel> tipovi
        {
            get;
            set;
        }

        public TypeTable()
        {
            InitializeComponent();
            tipovi = new ObservableCollection<TypeModel>();
            foreach (TypeModel s in Tipovi.Values)
            {
                tipovi.Add(s);
            }
            DataContext = this;
            mod.Name = "jkdsnfjdsndnfjnj";
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "Jeste li sigurni da želite obrisati selektovani tip?", "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                TypeModel model = (TypeModel)dgrMain.SelectedItem;
                Tipovi.Remove(model.ID);
                tipovi.Clear();
                foreach(TypeModel t in Tipovi.Values)
                {
                    tipovi.Add(t);
                }
                MessageBox.Show(this, "Tip resursa je obrisan.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dijalog = new OpenFileDialog();
            TypeModel model = (TypeModel)dgrMain.SelectedItem;
            dijalog.Filter = "Slike (*.jpeg, *.jpg, *.png, *.ico)|*.jpeg; *.jpg; *.png; *.ico";
            bool? retVal = dijalog.ShowDialog();
            if (retVal == true)
            {
                string fajl = dijalog.FileName;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new System.Uri(fajl, UriKind.Absolute);
                img.EndInit();
                model.IconPath = fajl;
                Ikona.Source = img;
            }
        }
    }
}
