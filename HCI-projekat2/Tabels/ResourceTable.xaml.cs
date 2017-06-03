using HCI_projekat2.Dialogs;
using HCI_projekat2.Help;
using HCI_projekat2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Tabels
{
    /// <summary>
    /// Interaction logic for ResourceTable.xaml
    /// </summary>
    public partial class ResourceTable : Window
    {
        public ResourceModel mod = new ResourceModel();

        public MainWindow mW = null;

        public ObservableCollection<ResourceModel> resursi
        {
            get;
            set;
        }
        public ObservableCollection<LabelModel> labels
        {
            get;
            set;
        }
        public ObservableCollection<ResourceModel> resursiContainer
        {
            get;
            set;
        }

        private bool _flag = false;

        public ResourceTable(MainWindow parent)
        {
            resursi = new ObservableCollection<ResourceModel>(Resursi.Values);
            resursiContainer = new ObservableCollection<ResourceModel>(Resursi.Values);
            labels = new ObservableCollection<LabelModel>();
            mW = parent;
            DataContext = this;

            InitializeComponent();

            _flag = true;
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgrMain.SelectedItem == null)
            {
                MessageBox.Show(this, "Morate izabrati jedan resurs iz tabele.", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show(this, "Jeste li sigurni da želite obrisati selektovani resurs?", "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ResourceModel model = (ResourceModel)dgrMain.SelectedItem;

                foreach (Image img in mW.Canvas.Children)
                {
                    if (img.Tag.Equals(model))
                    {
                        mW.Canvas.Children.Remove(img);
                        break;
                    }
                }

                Resursi.Remove(model.ID);
                ikoniceResursa.Remove(model);
                resursi.Clear();

                foreach (ResourceModel t in Resursi.Values)
                {
                    resursi.Add(t);
                }

                mW.iscrtajOpet();

                mW.removeResourceFromMap(model);

                MessageBox.Show(this, "Resurs je obrisan.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgrMain.SelectedItem == null)
            {
                MessageBox.Show(this, "Morate izabrati jedan resurs iz tabele.", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ResourceModel model = (ResourceModel)dgrMain.SelectedItem;
            ChangeResourceDialog val = new ChangeResourceDialog(model, mW);
            val.ShowDialog();


        }

        private void resetFilter_Click(object sender, RoutedEventArgs e)
        {
            resursi.Clear();
            foreach (ResourceModel model in resursiContainer)
            {
                resursi.Add(model);
            }
            idTextBox.Clear();
            tipTextBox.Clear();
            opisTextBox.Clear();
            imeTextBox.Clear();
            cenaUpDown.Value = 0;
            frekvencijaComboBox.SelectedIndex = 0;
            meraComboBox.SelectedIndex = 0;
            obnovljivCheckBox.IsChecked = false;
            strategijaCheckBox.IsChecked = false;
            eksploatisanjeCheckBox.IsChecked = false;
            veceRadioButton.IsChecked = false;
            manjeRadioButton.IsChecked = false;
            jednakoRadioButton.IsChecked = false;
        }

        private void filtrirajTabelu(object sender, TextChangedEventArgs e)
        {
            filtriraj();
        }

        private void filtrirajTabeluComboBox(object sender, SelectionChangedEventArgs e)
        {
            filtriraj();
        }

        private void filtriraj()
        {
            resursi.Clear();
            bool uslov;

            foreach (ResourceModel res in resursiContainer)
            {
                uslov = true;
                if (!idTextBox.Text.Equals(""))
                {
                    if (!res.ID.Contains(idTextBox.Text))
                    {
                        uslov = false;
                    }
                }

                if (!opisTextBox.Text.Equals(""))
                {
                    if (!res.Desc.Contains(opisTextBox.Text))
                    {
                        uslov = false;
                    }
                }

                if (!tipTextBox.Text.Equals(""))
                {
                    if (!res.Type.ID.Contains(tipTextBox.Text))
                    {
                        uslov = false;
                    }
                }

                if (frekvencijaComboBox.SelectedIndex != 0)
                {
                    if (frekvencijaComboBox.SelectedIndex == 1 && !res.Freq.Equals(MainWindow.Redak))
                        uslov = false;
                    else if (frekvencijaComboBox.SelectedIndex == 2 && !res.Freq.Equals(MainWindow.Cest))
                        uslov = false;
                    else if (frekvencijaComboBox.SelectedIndex == 3 && !res.Freq.Equals(MainWindow.Univerzalan))
                        uslov = false;
                }

                if (meraComboBox.SelectedIndex != 0)
                {
                    if (meraComboBox.SelectedIndex == 1 && !res.Unit.Equals(MainWindow.Merica))
                        uslov = false;
                    else if (meraComboBox.SelectedIndex == 2 && !res.Unit.Equals(MainWindow.Barel))
                        uslov = false;
                    else if (meraComboBox.SelectedIndex == 3 && !res.Unit.Equals(MainWindow.Tona))
                        uslov = false;
                    else if (meraComboBox.SelectedIndex == 4 && !res.Unit.Equals(MainWindow.Kg))
                        uslov = false;
                }


                double? dbtmp = cenaUpDown.Value;
                double cena = dbtmp.GetValueOrDefault(0);

                if (veceRadioButton.IsChecked == true)
                {
                    if (res.Price <= cena)
                        uslov = false;
                }
                else if (manjeRadioButton.IsChecked == true)
                {
                    if (res.Price >= cena)
                        uslov = false;
                }
                else if (res.Price != cena)
                {
                    uslov = false;
                }

                if (!imeTextBox.Text.Equals(""))
                {
                    if (!res.Name.Contains(imeTextBox.Text))
                    {
                        uslov = false;
                    }
                }

                bool? otkacen = obnovljivCheckBox.IsChecked;
                if (otkacen.Equals(true))
                {
                    if (!res.Renewable)
                        uslov = false;
                }

                otkacen = strategijaCheckBox.IsChecked;
                if (otkacen.Equals(true))
                {
                    if (!res.Important)
                        uslov = false;
                }

                otkacen = eksploatisanjeCheckBox.IsChecked;
                if (otkacen.Equals(true))
                {
                    if (!res.Exploit)
                        uslov = false;
                }

                if (uslov)
                    resursi.Add(res);
            }
        }

        private void filtrirajTabeluCheck(object sender, RoutedEventArgs e)
        {
            filtriraj();
        }

        private void tipButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseTypeDialog val = new ChooseTypeDialog(this);
            val.ShowDialog();
        }

        private void Help_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("resourceTable", this);
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

        private void cenaUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (_flag)
                filtriraj();
        }
    }
}
