using HCI_projekat2.Help;
using HCI_projekat2.Model;
using HCI_projekat2.Tabels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Dialogs
{
    public partial class ChangeLabelDialog : Window
    {
        private LabelModel model;
        private string oldID;
        private Dictionary<string, LabelModel> oldDictionary;
        private LabelTable parent;

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
            }
            else
            {


                Etikete[model.ID].Clr = Boja.SelectedColor.ToString();
                Etikete[model.ID].Desc = Opis.Text;
            }
            Close();
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("changeLabel", this);
        }
    }
}
