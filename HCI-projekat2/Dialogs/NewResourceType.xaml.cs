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
    /// Interaction logic for NewResourceType.xaml
    /// </summary>
    public partial class NewResourceType : Window
    {
        private TypeModel model;
        public NewResourceType()
        {
            model = new TypeModel();
            this.DataContext = model;
            InitializeComponent();
            

        }
    }
}
