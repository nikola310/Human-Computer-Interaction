using HCI_projekat2.Model;
using System;
using System.ComponentModel;
using System.Windows;

namespace HCI_projekat2.Dialogs
{
    /// <summary>
    /// Interaction logic for NewResourceDialog.xaml
    /// </summary>
    public partial class NewResourceDialog : Window, INotifyPropertyChanged 
    {
        public static bool BooleanTrue = true;
        public static bool BooleanFalse = false;
        private ResourceModel model = null;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private decimal _cena;

        public decimal Cena
        {
            get
            {
                return _cena;
            }
            set
            {
                if (value != _cena)
                {
                    _cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        }

        
        public NewResourceDialog()
        {
            model = new ResourceModel();
            DataContext = model;
            model.Renewable = true;
            InitializeComponent();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {

            MessageBox.Show(string.Format("Boolean property: {0}.",
             this.model.Renewable));

        }
    }
}
