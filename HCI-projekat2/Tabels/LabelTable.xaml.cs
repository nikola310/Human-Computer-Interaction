using HCI_projekat2.Dialogs;
using HCI_projekat2.Help;
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

        public LabelTable()
        {
            InitializeComponent();
            etikete = new ObservableCollection<LabelModel>(Etikete.Values);
            etiketeFilter = new ObservableCollection<LabelModel>(Etikete.Values);
            DataContext = this;
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgrMain.SelectedItem == null)
            {
                MessageBox.Show(this, "Morate izabrati jednu etiketu iz tabele.", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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
            if (dgrMain.SelectedItem == null)
            {
                MessageBox.Show(this, "Morate izabrati jednu etiketu iz tabele.", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            LabelModel model = (LabelModel)dgrMain.SelectedItem;
            ChangeLabelDialog val = new ChangeLabelDialog(this, model);
            val.ShowDialog();
            dgrMain.Items.Refresh();
        }

        public void resetFilter_Click(object sender, RoutedEventArgs e)
        {
            etikete.Clear();
            foreach(LabelModel model in etiketeFilter)
            {
                etikete.Add(model);
            }
            idTextBox.Text = "";
            opisTextBox.Text = "";
        }

        private void filtrirajTabelu(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            etikete.Clear();
            bool uslov;

            foreach(LabelModel lbl in etiketeFilter)
            {
                uslov = true;
                if (!idTextBox.Text.Equals(""))
                {
                    if (!lbl.ID.Contains(idTextBox.Text))
                    {
                        uslov = false;
                    }
                }

                if (!opisTextBox.Text.Equals(""))
                {
                    if (!lbl.Desc.Contains(opisTextBox.Text))
                    {
                        uslov = false;
                    }
                }

                if (uslov)
                    etikete.Add(lbl);
            }
        }

        private void Help_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("labelTable", this);
        }

        private void Izmeni_Cmd(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Izmeni_Click(sender, e);
        }

        private void Obrisi_Cmd(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Obrisi_Click(sender, e);
        }

        private void Resetuj_Cmd(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            resetFilter_Click(sender, e);
        }
    }
}
