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
using static HCI_projekat2.MainWindow;
using System.Windows.Shapes;
using HCI_projekat2.Model;
using Microsoft.Win32;
using System.ComponentModel;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for ChangeResourceDialog.xaml
    /// </summary>
    public partial class ChangeResourceDialog : Window, INotifyPropertyChanged
    {
        private ResourceModel model;
        public ResourceModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ChangeResourceDialog()
        {
            InitializeComponent();
        }

        public ChangeResourceDialog(ResourceModel model)
        {
            InitializeComponent();
            measureUnit.SelectedValue = model.Unit;
            frequency.SelectedValue = model.Freq;
            this.model = model;
            DataContext = model;

            foreach (LabelModel e in Etikete.Values)
            {
                EtiketeCheckList.Items.Add(e.ID);
            }

        }

        private void Izmeni_Resurs_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression b1 = ImeResursa.GetBindingExpression(TextBox.TextProperty);
            BindingExpression b2 = price.GetBindingExpression(TextBox.TextProperty);

            b1.UpdateSource();
            b2.UpdateSource();
            if (b1.HasError == false && b2.HasError == false)
            {
                if (model.Type.ID == "" || model.Type.ID == null)
                {
                    MessageBoxResult result = MessageBox.Show("Morate odabrati tip resursa!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                    TipResursa.Focus();
                    return;
                }

                if (model.IconPath == "/Images/qmark2.png" || model.IconPath == null || model.IconPath == "")
                {
                    MessageBoxResult result = MessageBox.Show("Morate odabrati ikonu resursa!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Datum.Text == "" || Datum.Text == null)
                {
                    Datum.Focus();
                    return;
                }
                model.Date = (DateTime)Datum.SelectedDate;

                model.Renewable = renewable.IsChecked.Value;
                model.Important = important.IsChecked.Value;
                model.Exploit = exploit.IsChecked.Value;

                if (frequency.SelectedItem == null || frequency.SelectedItem.ToString() == "")
                {
                    frequency.Focus();
                    return;
                }
                model.Freq = ((ComboBoxItem)frequency.SelectedItem).Content.ToString();

                if (measureUnit.SelectedItem == null || measureUnit.SelectedItem.ToString() == "")
                {
                    measureUnit.Focus();
                    return;
                }
                model.Unit = ((ComboBoxItem)measureUnit.SelectedItem).Content.ToString();

                if (Opis.Text == null || Opis.Text == "")
                {
                    model.Desc = "";
                }

                List<LabelModel> tmp = new List<LabelModel>();
                foreach (string et in EtiketeCheckList.SelectedItems)
                {
                    foreach (LabelModel t in Etikete.Values)
                    {
                        if (t.ID.Equals(et))
                        {
                            tmp.Add(t);
                        }
                    }
                }

                model.Labels = tmp;

                Resursi[model.ID] = model;

                Close();
            }
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

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Izaberi_Tip_Click(object sender, RoutedEventArgs e)
        {
            ChooseTypeDialog val = new ChooseTypeDialog(this);
            val.Show();
        }
    }
}
