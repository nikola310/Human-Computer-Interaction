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

    }
}
