using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class TraitViewModel : PropertyChangedBase
    {
        private Models.TraitModel _model;
        private bool _isReadOnly;
        public TraitViewModel(Models.TraitModel trait, bool isReadOnly)
        {
            _model = trait;
            _isReadOnly = isReadOnly;
            _selectedTraitType = _model.Type.ToString();
        }

        public string TraitName
        {
            get { return _model.Name; }
            set { if (_model.Name != value) { _model.Name = value; NotifyOfPropertyChange(() => TraitName); } }
        }

        public string TraitText
        {
            get { return _model.Text; }
            set { if (_model.Text != value) { _model.Text = value; NotifyOfPropertyChange(() => TraitText); } }
        }

        public string Cost
        {
            get { return _model.Cost; }
            set { if (_model.Cost != value) { _model.Cost = value; NotifyOfPropertyChange(() => Cost); } }
        }

        public bool IsEnabled
        {
            get { return !_isReadOnly; }
        }


        public List<string> TraitTypes
        {
            get
            {
                return Enum.GetNames(typeof(Models.TraitType)).ToList();
            }
        }
        private string _selectedTraitType;
        public string SelectedTraitType
        {
            get { return _selectedTraitType; }
            set
            {
                if (_selectedTraitType != value)
                {
                    _selectedTraitType = value;
                    _model.Type = (Models.TraitType)Enum.Parse(typeof(Models.TraitType), _selectedTraitType);
                    NotifyOfPropertyChange(() => SelectedTraitType);
                }
            }
        }
    }
}
