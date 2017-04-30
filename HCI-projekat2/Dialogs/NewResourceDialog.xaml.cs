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

        private ResourceModel model;
        public NewResourceDialog()
        {
            InitializeComponent();
            model = new ResourceModel();
            DataContext = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
