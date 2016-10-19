using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public abstract class MonsterBaseModel : BaseModel
    {
        private int _size;
        private int _speed;
        private string _text;

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }
        
        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
    }
}
