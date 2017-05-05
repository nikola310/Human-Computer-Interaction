using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HCI_projekat2.Model
{
    [Serializable]
    public class ResourceModel : INotifyPropertyChanged
    {
        public List<string> frekvencije { get; set; }

        public static string Redak = "Redak";
        public static string Cest = "Cest";
        public static string Univerzalan = "Univerzalan";

        public List<string> mere { get; set; }
        
        public static string Merica = "Merica";
        public static string Barel = "Barel";
        public static string Tona = "Tona";
        public static string Kg = "Kilogram";

        public string ValueString { get; set; }

        private Guid _guid;
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

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

        private TypeModel _type;
        public TypeModel Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

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

        private string _unit;
        public string Unit
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
            mere = new List<string>();
            mere.Add(Merica);
            mere.Add(Barel);
            mere.Add(Tona);
            mere.Add(Kg);

            frekvencije = new List<string>();
            frekvencije.Add(Redak);
            frekvencije.Add(Cest);
            frekvencije.Add(Univerzalan);

            Desc = "TEST TEST TEST";
            Date = DateTime.Now;
            IconPath = "/Images/qmark2.png";
        }



    }
}
