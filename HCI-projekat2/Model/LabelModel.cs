﻿using System;
using System.ComponentModel;
using System.Windows.Media;

namespace HCI_projekat2.Model
{
    [Serializable]
    class LabelModel : INotifyPropertyChanged
    {
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

        private Color _clr;
        private Color Clr
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
        private string Desc
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
            ID = "Enter ID";
            Desc = "Enter description";
            Clr = Color.FromArgb(0, 0, 0, 0);
        }

    }
}
