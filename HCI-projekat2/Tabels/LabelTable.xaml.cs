using HCI_projekat2.Model;
using System.Collections.ObjectModel;
using System.Windows;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Tabels
{
    /// <summary>
    /// Interaction logic for LabelTable.xaml
    /// </summary>
    public partial class LabelTable : Window
    {
        public ObservableCollection<LabelModel> etikete
        {
            get;
            set;
        }
        

        public LabelTable()
        {
            InitializeComponent();
            etikete = new ObservableCollection<LabelModel>();
            foreach(LabelModel s in Etikete.Values)
            {
                etikete.Add(s);
            }
            DataContext = this;
        }
    }
}
