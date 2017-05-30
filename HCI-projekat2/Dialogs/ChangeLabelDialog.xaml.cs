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
    /// Interaction logic for ChangeLabelDialog.xaml
    /// </summary>
    public partial class ChangeLabelDialog : Window
    {
        private LabelModel model;
        private string oldID;
        private Dictionary<string, LabelModel> oldDictionary;
        private LabelTable parent;
        private ObservableCollection<LabelModel> oldEtikete;

        public ChangeLabelDialog(LabelTable parent, LabelModel m)
        {
            InitializeComponent();
            this.parent = parent;
            oldDictionary = Etikete;
            oldID = m.ID;
            model = new LabelModel(m);
            Boja.SelectedColor = (Color)ColorConverter.ConvertFromString(model.Clr);
            Opis.Text = model.Desc;
            DataContext = model;
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

            if (!IDetikete.Text.Equals(oldID))
            {
                Etikete.Clear();
                oldDictionary.Remove(oldID);
                LabelModel tmp = new LabelModel(IDetikete.Text, Boja.SelectedColor.ToString(), Opis.Text);
                oldDictionary.Add(tmp.ID, tmp);
                Etikete = new Dictionary<string, LabelModel>(oldDictionary);
                parent.dgrMain.Items.Refresh();
            } else {


                Etikete[model.ID].Clr = Boja.SelectedColor.ToString();
                Etikete[model.ID].Desc = Opis.Text;
            }
            Close();
        }
    }
}
