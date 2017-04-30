using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HCI_projekat2.Model
{
    [Serializable]
    class ResourceModel : INotifyPropertyChanged
    {
        public static int Redak = 1;
        public static int Cest = 2;
        public static int Univerzalan = 3;

        public static int Merica = 0;
        public static int Barel = 1;
        public static int Tona = 2;
        public static int Kg = 3;

        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

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

        private string _desc;
        public string Desc
        {
            get
            {
                return _desc;
            }
            set
            {
                _desc = value;
                OnPropertyChanged("Desc");
            }
        }


        private string _iconPath;
        public string IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                _iconPath = value;
                OnPropertyChanged("IconPath");
            }
        }

        //tip?
        private bool _renewable;
        public bool Renewable
        {
            get
            {
                return _renewable;
            }
            set
            {
                _renewable = value;
                OnPropertyChanged("Renewable");
            }
        }

        private bool _important;
        public bool Important
        {
            get
            {
                return _important;
            }
            set
            {
                _important = value;
                OnPropertyChanged("Important");
            }
        }

        private bool _exploit;
        public bool Exploit
        {
            get
            {
                return _exploit;
            }
            set
            {
                _exploit = value;
                OnPropertyChanged("Exploit");
            }
        }

        private int _unit;
        public int Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
                OnPropertyChanged("Unit");
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ResourceModel()
        {
            Desc = "TEST TEST TEST";
            Date = DateTime.Now;
        }



    }
}
