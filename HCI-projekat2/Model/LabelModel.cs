using System;
using System.ComponentModel;

namespace HCI_projekat2.Model
{
    [Serializable]
    public class LabelModel : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        private string _clr;
        public string Clr
        {
            get
            {
                return _clr;
            }
            set
            {
                _clr = value;
                OnPropertyChanged("Clr");
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

        public LabelModel()
        {
            /*ID = "Enter ID";
            Desc = "Enter description";
            Clr = Color.FromArgb(0, 0, 0, 0);*/
        }

        public LabelModel(string id, string selectedColor, string desc)
        {
            ID = id;
            Clr = selectedColor;
            Desc = desc;
        }

        public LabelModel(LabelModel m)
        {
            ID = m.ID;
            Clr = m.Clr;
            Desc = m.Desc;
        }
    }
}
