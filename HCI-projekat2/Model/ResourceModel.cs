using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HCI_projekat2.Model
{
    [Serializable]
    public class ResourceModel : INotifyPropertyChanged
    {


        public string ValueString { get; set; }

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

        private List<LabelModel> _labels;
        public List<LabelModel> Labels
        {
            get
            {
                return _labels;
            }
            set
            {
                _labels = value;
                OnPropertyChanged("Labels");
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

        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
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

        private string _freq;
        public string Freq
        {
            get
            {
                return _freq;
            }
            set
            {
                _freq = value;
                OnPropertyChanged("Freq");
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ResourceModel()
        {
            Type = new TypeModel();
            Date = DateTime.Now;
            IconPath = "/Images/qmark2.png";
        }
    }
}
