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

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for ChooseTypeDialog.xaml
    /// </summary>
    public partial class ChooseTypeDialog : Window
    {
        private TypeModel mod = new TypeModel();
        private NewResourceDialog res;

        public ObservableCollection<TypeModel> tipovi
        {
            get;
            set;
        }

        public ChooseTypeDialog(NewResourceDialog dg)
        {
            InitializeComponent();
            tipovi = new ObservableCollection<TypeModel>();
            res = dg;
            foreach (TypeModel s in Tipovi.Values)
            {
                tipovi.Add(s);
            }
            DataContext = this;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Izaberi_Tip_Click(object sender, RoutedEventArgs e)
        {
            TypeModel model = (TypeModel)dgrType.SelectedItem;
            res.Model.Type = model;
            Close();
        }
    }
}
