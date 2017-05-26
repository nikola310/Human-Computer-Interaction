using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_projekat2.Model
{
    [Serializable]
    public class UserModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string _pass;
        public string Pass
        {
            get
            {
                return _pass;
            }
            set
            {
                _pass = value;
                OnPropertyChanged("Pass");
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public UserModel(string name, string pass)
        {
            Name = name;
            Pass = pass;
        }
    }
}
