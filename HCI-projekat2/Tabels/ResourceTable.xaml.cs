﻿using HCI_projekat2.Dialogs;
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


        public ObservableCollection<ResourceModel> resursi
        {
            get;
            set;
        }


        public ResourceTable()
        {
            InitializeComponent();
            resursi = new ObservableCollection<ResourceModel>();
            foreach(ResourceModel tmp in Resursi.Values)
            {
                resursi.Add(tmp);
            }
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

                Resursi.Remove(model.ID);
                resursi.Clear();
                foreach (ResourceModel t in Resursi.Values)
                {
                    resursi.Add(t);
                }
                MessageBox.Show(this, "Resurs je obrisan.", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            ResourceModel model = (ResourceModel)dgrMain.SelectedItem;
            ChangeResourceDialog val = new ChangeResourceDialog(model);
            val.Show();
        }
    }
}
