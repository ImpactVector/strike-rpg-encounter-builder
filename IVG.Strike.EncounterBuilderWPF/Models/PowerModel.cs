using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class PowerModel : BaseModel
    {
        protected PowerModel()
        {
        }

        public static PowerModel NewPowerModel()
        {
            PowerModel m = new PowerModel();

            m.Name = "NewPower";
            m.ActionType = PowerActionType.Action;
            m.UsageType = PowerUsageType.AtWill;

            return m;
        }

        #region Private Variables

        private int _damage;
        private int _range;
        private bool _isRanged;
        private bool _isMelee;
        private bool _isBurst;
        private int _burst;
        private string _text;
        private PowerActionType _actionType;
        private PowerUsageType _usageType;
        private bool _isMissTrigger;

        #endregion

        #region Public Properties

        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
                OnPropertyChanged("Damage");
            }
        }

        public int Range
        {
            get
            {
                return _range;
            }

            set
            {
                _range = value;
                OnPropertyChanged("Range");
            }
        }

        public int Burst
        {
            get
            {
                return _burst;
            }

            set
            {
                _burst = value;
                OnPropertyChanged("Burst");
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

        public PowerActionType ActionType
        {
            get
            {
                return _actionType;
            }

            set
            {
                _actionType = value;
                OnPropertyChanged("ActionType");
            }
        }

        public PowerUsageType UsageType
        {
            get
            {
                return _usageType;
            }

            set
            {
                _usageType = value;
                OnPropertyChanged("UsageType");
            }
        }

        public bool IsMissTrigger
        {
            get
            {
                return _isMissTrigger;
            }

            set
            {
                _isMissTrigger = value;
                OnPropertyChanged("IsMissTrigger");
            }
        }

        public bool IsMelee
        {
            get
            {
                return _isMelee;
            }

            set
            {
                _isMelee = value;
                OnPropertyChanged("IsMelee");
            }
        }

        public bool IsRanged
        {
            get
            {
                return _isRanged;
            }

            set
            {
                _isRanged = value;
                OnPropertyChanged("IsRanged");
            }
        }

        public bool IsBurst
        {
            get
            {
                return _isBurst;
            }

            set
            {
                _isBurst = value;
                OnPropertyChanged("IsBurst");
            }
        }

        #endregion
    }

    public enum PowerUsageType
    {
        [Description("At-Will")]
        AtWill,
        Encounter
    }

    public enum PowerActionType
    {
        Action,
        Move,
        Free,
        Reaction,
        Interrupt
    }
}
