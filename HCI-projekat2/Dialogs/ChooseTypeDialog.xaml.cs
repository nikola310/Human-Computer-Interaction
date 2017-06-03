using HCI_projekat2.Model;
using HCI_projekat2.Tabels;
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
        private ChangeResourceDialog chr;
        private ResourceTable resTable;
        private bool flag = false;
        private bool resTableFlag = false;

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
            flag = true;
            foreach (TypeModel s in Tipovi.Values)
            {
                tipovi.Add(s);
            }
            DataContext = this;
        }

        public ChooseTypeDialog(ChangeResourceDialog dg)
        {
            InitializeComponent();
            tipovi = new ObservableCollection<TypeModel>();
            chr = dg;
            foreach (TypeModel s in Tipovi.Values)
            {
                tipovi.Add(s);
            }
            DataContext = this;
        }

        public ChooseTypeDialog(ResourceTable dg)
        {
            InitializeComponent();
            tipovi = new ObservableCollection<TypeModel>();
            resTable = dg;
            resTableFlag = true;
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
            //pre je bilo bez flaga i bez ovog ifa
            //dakle samo
            //res.Model.Type = model;
            // if (flag)
            // {
            //   chr.Model.Type = model;
            //  }
            //else 
            if (resTableFlag)
            {
                resTable.tipTextBox.Text = model.ID;
            }else if (flag)
            {
                res.Model.Type = model;
            }
            else
            {
                chr.Model.Type = model;
            }
            Close();
        }

        private void Help_Command(object sender, ExecutedRoutedEventArgs e)
        {
            //TO DO: add help page, then call it here
        }
    }
}
