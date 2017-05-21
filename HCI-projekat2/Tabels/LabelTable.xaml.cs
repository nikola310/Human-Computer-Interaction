using HCI_projekat2.Dialogs;
using HCI_projekat2.Model;
using System.Collections.ObjectModel;
using System.Windows;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Tabels
{
    /// <summary>
    /// Interaction logic for LabelTable.xaml
    /// </summary>
    public partial class LabelTable : Window
    {
        public ObservableCollection<LabelModel> etikete
        {
            get;
            set;
        }

        public ObservableCollection<LabelModel> etiketeFilter
        {
            get;
            set;
        }

        public LabelTable(ObservableCollection<LabelModel> e)
        {
            InitializeComponent();
            etikete = e;
            foreach (LabelModel s in Etikete.Values)
            {
                etiketeFilter.Add(s);
            }
            DataContext = this;
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "Brisanjem ove etikete će doći do njenog brisanja iz svakog resursa koji ju sadrži. Jeste li sigurni da želite obrisati selektovanu etiketu?", "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                LabelModel model = (LabelModel)dgrMain.SelectedItem;

                foreach (ResourceModel r in Resursi.Values)
                {
                    r.Labels.Remove(model);
                }




                Etikete.Remove(model.ID);
                etikete.Clear();
                foreach (LabelModel t in Etikete.Values)
                {
                    etikete.Add(t);
                }
                MessageBox.Show(this, "Etiketa je obrisana.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            LabelModel model = (LabelModel)dgrMain.SelectedItem;
            ChangeLabelDialog val = new ChangeLabelDialog(model);
            val.Show();
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterLabel filter = new FilterLabel(this);
            filter.Show();
        }

        public void resetFilter_Click(object sender, RoutedEventArgs e)
        {
            etiketeFilter.Clear();
            foreach(LabelModel model in etikete)
            {
                etiketeFilter.Add(model);
            }
        }


    }
}
