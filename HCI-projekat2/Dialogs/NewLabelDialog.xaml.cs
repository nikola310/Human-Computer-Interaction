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
using HCI_projekat2.Model;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for NewLabelDialog.xaml
    /// </summary>
    public partial class NewLabelDialog : Window
    {
        private LabelModel model;
        public NewLabelDialog()
        {
            InitializeComponent();
            model = new LabelModel();
            DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IDetikete.Text == "")
            {
                MessageBoxResult message = MessageBox.Show(this, "Morate uneti ID etikete!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                IDetikete.Focus();
                return;
            }
            if (Boja.SelectedColor == null)
            {
                MessageBoxResult message = MessageBox.Show("Morate izabrati boju!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                Boja.Focus();
                return;
            }
            if(Opis.Text == null)
            {
                Opis.Text = "";
            }

            foreach(LabelModel lbl in Etikete.Values)
            {
                if (lbl.ID.Equals(IDetikete.Text))
                {
                    MessageBoxResult message = MessageBox.Show(this, "Etiketa sa takvom ID oznakom vec postoji! Molimo vas, unesite drugi ID.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    IDetikete.Focus();
                    return;
                }
            }
            
            LabelModel novo = new LabelModel(IDetikete.Text, Boja.SelectedColor, Opis.Text);
            Etikete.Add(novo.Gid, novo);
            Close();
        }
    }
}
