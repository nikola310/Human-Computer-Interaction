using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_projekat2.Model
{
    public class UserModel
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
            }
        }

        public UserModel(string name, string pass)
        {
            Name = name;
            Pass = pass;
        }
    }
}
