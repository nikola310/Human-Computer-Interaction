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
using HCI_projekat2.Tabels;
using HCI_projekat2.Model;
using static HCI_projekat2.MainWindow;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for FilterLabel.xaml
    /// </summary>
    public partial class FilterLabel : Window
    {
        LabelTable tabela;

        public List<LabelModel> Filter
        {
            get;
            set;
        }

        public FilterLabel(LabelTable tabela)
        {
            InitializeComponent();
            DataContext = this;
            this.tabela = tabela;
            Filter = new List<LabelModel>();
            foreach(LabelModel model in obsEtikete)
            {
                Filter.Add(model);
            }
        }



        private void izlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void reset()
        {
            Filter = new List<LabelModel>();
            foreach(LabelModel model in obsEtikete)
            {
                Filter.Add(model);
            }
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            tabela.resetFilter_Click(this, e);
            reset();
            List<LabelModel> tmp;
            if (idCheckBox.IsChecked.Value)
            {
                string filter = idTextBox.Text;
                tmp = new List<LabelModel>();
                foreach(LabelModel model in Filter)
                {
                    //treba bolje!!!
                    if (!model.ID.Contains(filter))
                    {
                        tmp.Add(model);
                    }
                }
                foreach(LabelModel model in tmp)
                {
                    Filter.Remove(model);
                }
            }

            
        }
    }
}
