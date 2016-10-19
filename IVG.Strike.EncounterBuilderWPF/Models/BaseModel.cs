using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public abstract class BaseModel : INotifyPropertyChanged, IComparable<BaseModel>
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public int CompareTo(BaseModel other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
