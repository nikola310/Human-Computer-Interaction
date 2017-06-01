using HCI_projekat2.Model;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for ChangeTypeDialog.xaml
    /// </summary>
    public partial class ChangeTypeDialog : Window
    {
        TypeModel model;

        public ChangeTypeDialog(TypeModel m)
        {
            InitializeComponent();
            model = m;
            DataContext = model;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression b = Ime.GetBindingExpression(TextBox.TextProperty);

            b.UpdateSource();

            if (b.HasError == false)
            {

                if (model.IconPath == null || model.IconPath == "/Images/qmark2.png" || model.IconPath == "")
                {
                    MessageBoxResult message = MessageBox.Show(this, "Morate odabrati ikonu!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                    BrowseButton.Focus();
                    return;
                }

                if (model.Desc == null)
                {
                    model.Desc = "";
                }

                Tipovi[model.ID].Name = model.Name;
                Tipovi[model.ID].Desc = model.Desc;

                Close();
            }
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void Change_Icon_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Browse_Click(sender, e);
        }

        private void Help_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            //TO DO: write page then call it here
        }
    }
}
