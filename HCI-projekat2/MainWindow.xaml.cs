using HCI_projekat2.Model;
using System.Windows;

namespace HCI_projekat2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
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
