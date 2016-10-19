using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class TraitListViewModel : Conductor<PropertyChangedBase>
    {
        public TraitListViewModel(BindableCollection<Models.TraitModel> traits)
        {
            DisplayName = "Trait List";
            _traits = traits;
            if (_traits != null && _traits.Count > 0) SelectedTrait = _traits[0];
        }

        private BindableCollection<Models.TraitModel> _traits;
        public BindableCollection<Models.TraitModel> Traits
        {
            get { return _traits; }
        }

        private Models.TraitModel _selectedTrait;
        public Models.TraitModel SelectedTrait
        {
            get { return _selectedTrait; }
            set
            {
                if (_selectedTrait != value)
                {
                    _selectedTrait = value;

                    if (value != null)
                        ActivateItem(new TraitViewModel(value, false));

                    NotifyOfPropertyChange(() => SelectedTrait);
                    NotifyOfPropertyChange(() => CanDelTrait);
                }
            }
        }
        public void AddTrait()
        {
            Models.TraitModel t = Models.TraitModel.NewTraitModel();
            _traits.Add(t);
            SelectedTrait = t;
        }
        public void DelTrait()
        {
            DeactivateItem(ActiveItem, true);

            _traits.Remove(SelectedTrait);
            
            SelectedTrait = null;
        }
        public bool CanDelTrait
        {
            get { return SelectedTrait != null; }
        }
    }
}
