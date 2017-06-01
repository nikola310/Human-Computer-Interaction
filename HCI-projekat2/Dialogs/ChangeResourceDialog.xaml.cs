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
using System.Windows.Controls.Primitives;

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

        private MainWindow mW;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ChangeResourceDialog()
        {
            InitializeComponent();
        }

        public ChangeResourceDialog(ResourceModel model, MainWindow mW)
        {
            InitializeComponent();

            this.model = model;
            DataContext = model;
            this.mW = mW;
            foreach (LabelModel e in Etikete.Values)
            {
                EtiketeCheckList.Items.Add(e.ID);
            }

            /*foreach (String lbl in EtiketeCheckList.Items)
            {
                foreach (LabelModel e in model.Labels)
                {
                    if (lbl.Equals(e.ID))
                    {
                        EtiketeCheckList.Items = lbl;
                    }
                }
            }*/

            foreach (LabelModel lbl in model.Labels)
            {
                EtiketeCheckList.SelectedItems.Add(lbl.ID);
            }

            Datum.SelectedDate = model.Date;

            renewable.IsChecked = model.Renewable;
            important.IsChecked = model.Important;
            exploit.IsChecked = model.Exploit;

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

                foreach (Image img in mW.Canvas.Children)
                {
                    ResourceModel mdl = (ResourceModel)img.Tag;
                    if (mdl.ID.Equals(model.ID))
                    {
                        img.Source = new ImageSourceConverter().ConvertFromString(mdl.IconPath) as ImageSource;
                        img.ToolTip = mW.addTooltip(mdl);
                        img.Tag = model;
                        break;
                    }
                }

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

        private void dodajEtiketu_Click(object sender, RoutedEventArgs e)
        {
            NewLabelDialog v = new NewLabelDialog();
            v.ShowDialog();
            EtiketeCheckList.Items.Clear();
            foreach (LabelModel model in Etikete.Values)
            {
                EtiketeCheckList.Items.Add(model.ID);
            }
        }

        private void dodajTip_Click(object sender, RoutedEventArgs e)
        {
            NewResourceType v = new NewResourceType();
            v.ShowDialog();
        }

        private void Help_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // znas vec sta treba
        }

        private void Change_Icon_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Browse_Click(sender, e);
        }

        private void Choose_Type_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Izaberi_Tip_Click(sender, e);
        }

        private void Add_Label_Cmd(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            dodajEtiketu_Click(sender, e);
        }

        private void Add_New_Type_Cmd(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            dodajTip_Click(sender, e);
        }
    }
}
