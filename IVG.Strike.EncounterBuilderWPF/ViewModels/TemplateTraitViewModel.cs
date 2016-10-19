using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class TemplateTraitViewModel : PropertyChangedBase
    {
        private Models.TemplateTraitModel _model;
        private bool _isReadOnly;
        public TemplateTraitViewModel(Models.TemplateTraitModel trait, bool isReadOnly)
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

        public bool IsLevel2Selected
        {
            get { return _model.EffectiveLevels.Contains(2); }
            set
            {
                if (value)
                {
                    if (!_model.EffectiveLevels.Contains(2))
                        _model.EffectiveLevels.Add(2);
                }
                else
                    if (_model.EffectiveLevels.Contains(2))
                    _model.EffectiveLevels.Remove(2);

                NotifyOfPropertyChange(() => IsLevel2Selected);
                NotifyOfPropertyChange(() => SelectedLevels);
            }
        }
        public bool IsLevel4Selected
        {
            get { return _model.EffectiveLevels.Contains(4); }
            set
            {
                if (value)
                {
                    if (!_model.EffectiveLevels.Contains(4))
                        _model.EffectiveLevels.Add(4);
                }
                else
                    if (_model.EffectiveLevels.Contains(4))
                    _model.EffectiveLevels.Remove(4);

                NotifyOfPropertyChange(() => IsLevel4Selected);
                NotifyOfPropertyChange(() => SelectedLevels);
            }
        }
        public bool IsLevel6Selected
        {
            get { return _model.EffectiveLevels.Contains(6); }
            set
            {
                if (value)
                {
                    if (!_model.EffectiveLevels.Contains(6))
                        _model.EffectiveLevels.Add(6);
                }
                else
                    if (_model.EffectiveLevels.Contains(6))
                    _model.EffectiveLevels.Remove(6);

                NotifyOfPropertyChange(() => IsLevel6Selected);
            }
        }
        public bool IsLevel8Selected
        {
            get { return _model.EffectiveLevels.Contains(8); }
            set
            {
                if (value)
                {
                    if (!_model.EffectiveLevels.Contains(8))
                        _model.EffectiveLevels.Add(8);
                }
                else
                    if (_model.EffectiveLevels.Contains(8))
                    _model.EffectiveLevels.Remove(8);

                NotifyOfPropertyChange(() => IsLevel8Selected);
                NotifyOfPropertyChange(() => SelectedLevels);
            }
        }
        public bool IsLevel10Selected
        {
            get { return _model.EffectiveLevels.Contains(10); }
            set
            {
                if (value)
                {
                    if (!_model.EffectiveLevels.Contains(10))
                        _model.EffectiveLevels.Add(10);
                }
                else
                    if (_model.EffectiveLevels.Contains(10))
                    _model.EffectiveLevels.Remove(10);

                NotifyOfPropertyChange(() => IsLevel10Selected);
                NotifyOfPropertyChange(() => SelectedLevels);
            }
        }
        public bool IsLevel12Selected
        {
            get { return _model.EffectiveLevels.Contains(12); }
            set
            {
                if (value)
                {
                    if (!_model.EffectiveLevels.Contains(12))
                        _model.EffectiveLevels.Add(12);
                }
                else
                    if (_model.EffectiveLevels.Contains(12))
                    _model.EffectiveLevels.Remove(12);

                NotifyOfPropertyChange(() => IsLevel12Selected);
                NotifyOfPropertyChange(() => SelectedLevels);
            }
        }

        public string SelectedLevels
        {
            get { return _model.EffectiveLevels.ToString(); }
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
