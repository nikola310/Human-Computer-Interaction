using System.Collections.ObjectModel;
using System.Windows;
using HCI_projekat2.Model;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Tabels
{

    public partial class TypeTable : Window
    {
        public ObservableCollection<TypeModel> tipovi
        {
            get;
            set;
        }

        public TypeTable()
        {
            InitializeComponent();
            tipovi = new ObservableCollection<TypeModel>();
            foreach (TypeModel s in Tipovi.Values)
            {
                tipovi.Add(s);
            }
            DataContext = this;
        }
    }
}
