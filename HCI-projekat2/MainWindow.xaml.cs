using HCI_projekat2.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HCI_projekat2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Dictionary<Guid, ResourceModel> _resursi;
        public static Dictionary<Guid, ResourceModel> Resursi
        {
            get
            {
                return _resursi;
            }
            set
            {
                _resursi = value;
            }
        }
        public static Dictionary<Guid, TypeModel> _tipovi;
        public static Dictionary<Guid, TypeModel> Tipovi
        {
            get
            {
                return _tipovi;
            }
            set
            {
                _tipovi = value;
            }
        }
        public static Dictionary<Guid, LabelModel> _etikete;
        public static Dictionary<Guid, LabelModel> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                _etikete = value;
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            Etikete = new Dictionary<Guid, LabelModel>();
            Tipovi = new Dictionary<Guid, TypeModel>();
            Resursi = new Dictionary<Guid, ResourceModel>();
        }

        private void AddNewRes_Click(object sender, RoutedEventArgs e)
        {
            var s = new HCI_projekat2.Dialogs.NewResourceDialog();
            s.Show();
        }

        private void NewResType_Click(object sender, RoutedEventArgs e)
        {
            var t = new HCI_projekat2.Dialogs.NewResourceType();
            t.Show();
        }

        private void NewResLabel_Click(object sender, RoutedEventArgs e)
        {
            var l = new HCI_projekat2.Dialogs.NewLabelDialog();
            l.Show();
        }




    }
}
