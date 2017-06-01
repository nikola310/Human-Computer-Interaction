using System.Windows;
using HCI_projekat2.Model;
using static HCI_projekat2.MainWindow;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media;

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
            model = new LabelModel();
            DataContext = model;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression b = IDetikete.GetBindingExpression(TextBox.TextProperty);
            b.UpdateSource();
            if (b.HasError == false)
            {
                if (Boja.SelectedColor == null)
                {
//                    Color? boja = Boja.SelectedColor;
                    Boja.SelectedColor = Color.FromRgb(255, 255, 255);
                    MessageBoxResult message = MessageBox.Show("Morate izabrati boju!", "Nedostaje vrednost", MessageBoxButton.OK, MessageBoxImage.Error);
                    //Boja.Focus();
                    Boja.SelectedColor = Color.FromRgb(255, 255, 255); //prepraviti
                   // Boja.
                    Boja.CaptureMouse();
                    return;
                }
                if (Opis.Text == null)
                {
                    Opis.Text = "";
                }

                foreach (LabelModel lbl in Etikete.Values)
                {
                    if (lbl.ID.Equals(IDetikete.Text))
                    {
                        MessageBoxResult message = MessageBox.Show(this, "Etiketa sa takvom ID oznakom vec postoji! Molimo vas, unesite drugi ID.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                        IDetikete.Focus();
                        return;
                    }
                }

                LabelModel novo = new LabelModel(IDetikete.Text, Boja.SelectedColor.ToString(), Opis.Text);
                Etikete.Add(novo.ID, novo);
                Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Boja_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            //TO DO: Add help page and then call it here
        }
    }
}
