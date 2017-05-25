using HCI_projekat2.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for NewResourceDialog.xaml
    /// </summary>
    /// to add a font: FontFamily="/HCI-projekat2;component/Resources/#Pragmata Pro"
    public partial class NewResourceDialog : Window, INotifyPropertyChanged
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

        public NewResourceDialog()
        {
            InitializeComponent();
            model = new ResourceModel();
            model.Price = 0;
            DataContext = model;

            foreach (LabelModel e in Etikete.Values)
            {
                EtiketeCheckList.Items.Add(e.ID);
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

        private void Dodaj_Resurs_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression b = IDResursa.GetBindingExpression(TextBox.TextProperty);
            BindingExpression b1 = ImeResursa.GetBindingExpression(TextBox.TextProperty);
            BindingExpression b2 = price.GetBindingExpression(TextBox.TextProperty);

            b.UpdateSource();
            b1.UpdateSource();
            b2.UpdateSource();
            if (b.HasError == false && b1.HasError == false && b2.HasError == false)
            {
                if (model.Type.ID == "" || model.Type.ID == null)
                {
                    MessageBoxResult result = MessageBox.Show("Morate odabrati tip resursa!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                    TipResursa.Focus();
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
                    frequency.IsDropDownOpen = true;
                    return;
                }
                model.Freq = ((ComboBoxItem)frequency.SelectedItem).Content.ToString();

                if (measureUnit.SelectedItem == null || measureUnit.SelectedItem.ToString() == "")
                {
                    measureUnit.Focus();
                    measureUnit.IsDropDownOpen = true;
                    return;
                }
                model.Unit = ((ComboBoxItem)measureUnit.SelectedItem).Content.ToString();

                if (model.IconPath == "/Images/qmark2.png" || model.IconPath == null || model.IconPath == "")
                {
                    MessageBoxResult result = MessageBox.Show("Morate odabrati ikonu resursa!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


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


                Resursi.Add(model.ID, model);
                ikoniceResursa.Add(model);
                Close();
            }
        }

        private void price_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

