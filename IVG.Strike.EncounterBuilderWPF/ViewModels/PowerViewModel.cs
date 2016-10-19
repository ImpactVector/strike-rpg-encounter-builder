using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class PowerViewModel : PropertyChangedBase
    {
        private Models.PowerModel _model;
        public PowerViewModel(Models.PowerModel power)
        {
            _model = power;
            _selectedActionType = _model.ActionType.ToString();
            _selectedUsageType = _model.UsageType.ToString();
        }

        public List<string> UsageTypes
        {
            get
            {
                return Enum.GetNames(typeof(Models.PowerUsageType)).ToList();
            }
        }
        private string _selectedUsageType;
        public string SelectedUsageType
        {
            get { return _selectedUsageType; }
            set
            {
                if (_selectedUsageType != value)
                {
                    _selectedUsageType = value;
                    _model.UsageType = (Models.PowerUsageType)Enum.Parse(typeof(Models.PowerUsageType), _selectedUsageType);
                    NotifyOfPropertyChange(() => SelectedUsageType);
                }
            }
        }

        public List<string> ActionTypes
        {
            get
            {
                return Enum.GetNames(typeof(Models.PowerActionType)).ToList();
            }
        }
        private string _selectedActionType;
        public string SelectedActionType
        {
            get { return _selectedActionType; }
            set
            {
                if (_selectedActionType != value)
                {
                    _selectedActionType = value;
                    _model.ActionType = (Models.PowerActionType)Enum.Parse(typeof(Models.PowerActionType), _selectedActionType);
                    NotifyOfPropertyChange(() => SelectedActionType);
                }
            }
        }

        public string PowerName
        {
            get { return _model.Name; }
            set { if (_model.Name != value) { _model.Name = value; NotifyOfPropertyChange(() => PowerName); } }
        }

        public string PowerText
        {
            get { return _model.Text; }
            set { if (_model.Text != value) { _model.Text = value; NotifyOfPropertyChange(() => PowerText); } }
        }

        public int Damage
        {
            get { return _model.Damage; }
            set { if (_model.Damage != value) { _model.Damage = value; NotifyOfPropertyChange(() => Damage); } }
        }

        public bool IsRanged
        {
            get { return _model.IsRanged; }
            set { if (_model.IsRanged != value) { _model.IsRanged = value; NotifyOfPropertyChange(() => IsRanged); } }
        }

        public bool IsBurst
        {
            get { return _model.IsBurst; }
            set { if (_model.IsBurst != value) { _model.IsBurst = value; NotifyOfPropertyChange(() => IsBurst); } }
        }

        public bool IsMelee
        {
            get { return _model.IsMelee; }
            set { if (_model.IsMelee != value) { _model.IsMelee = value; NotifyOfPropertyChange(() => IsMelee); } }
        }

        public bool IsMissTrigger
        {
            get { return _model.IsMissTrigger; }
            set { if (_model.IsMissTrigger != value) { _model.IsMissTrigger = value; NotifyOfPropertyChange(() => IsMissTrigger); } }
        }

        public int Range
        {
            get { return _model.Range; }
            set { if (_model.Range != value) { _model.Range = value; NotifyOfPropertyChange(() => Range); } }
        }

        public int Burst
        {
            get { return _model.Burst; }
            set { if (_model.Burst != value) { _model.Burst = value; NotifyOfPropertyChange(() => Burst); } }
        }
    }
}
