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
        private double _cena;

        public double Cena
        {
            get
            {
                return _cena;
            }
            set
            {
               if(value != _cena)
                {
                    _cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        } 

        public NewResourceDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
