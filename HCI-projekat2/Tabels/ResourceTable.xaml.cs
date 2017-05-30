using HCI_projekat2.Dialogs;
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

        public ResourceTable(MainWindow parent)
        {
            InitializeComponent();
            resursi = new ObservableCollection<ResourceModel>(Resursi.Values);
            resursiContainer = new ObservableCollection<ResourceModel>(Resursi.Values);
            labels = new ObservableCollection<LabelModel>();
            /*            foreach (ResourceModel tmp in Resursi.Values)
                        {
                            resursi.Add(tmp);
                        }*/
            //foreach(LabelModel lab in )
            mW = parent;
            DataContext = this;
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
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
            ResourceModel model = (ResourceModel)dgrMain.SelectedItem;
            ChangeResourceDialog val = new ChangeResourceDialog(model, mW);
            val.ShowDialog();


        }

        private void resetFilter_Click(object sender, RoutedEventArgs e)
        {

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

                if (uslov)
                    resursi.Add(res);
            }
        }

        private void filtrirajTabeluCheckBox(object sender, RoutedEventArgs e)
        {
            filtriraj();
        }

        private void tipButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseTypeDialog val = new ChooseTypeDialog(this);
            val.ShowDialog();
        }
    }
}
