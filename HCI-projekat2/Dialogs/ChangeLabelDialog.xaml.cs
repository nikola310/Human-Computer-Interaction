using HCI_projekat2.Model;
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
using System.Windows.Shapes;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for ChangeLabelDialog.xaml
    /// </summary>
    public partial class ChangeLabelDialog : Window
    {
        private LabelModel model;

        public ChangeLabelDialog(LabelModel m)
        {
            InitializeComponent();
            model = m;
            Boja.SelectedColor = (Color)ColorConverter.ConvertFromString(model.Clr);
            Opis.Text = model.Desc;
            IDetikete.Text = model.ID;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            if (Boja.SelectedColor == null)
            {
                MessageBoxResult message = MessageBox.Show("Morate izabrati boju!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                Boja.Focus();
                return;
            }

            if (Opis.Text == null)
            {
                Opis.Text = "";
            }

            Etikete[model.ID].Clr = Boja.SelectedColor.ToString();
            Etikete[model.ID].Desc = Opis.Text;

            Close();
        }
    }
}
