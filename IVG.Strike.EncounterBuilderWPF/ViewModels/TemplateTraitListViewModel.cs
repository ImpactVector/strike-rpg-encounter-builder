using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class TemplateTraitListViewModel : Conductor<PropertyChangedBase>
    {
        public TemplateTraitListViewModel(BindableCollection<Models.TemplateTraitModel> traits)
        {
            _traits = traits;
        }

        private BindableCollection<Models.TemplateTraitModel> _traits;
        public BindableCollection<Models.TemplateTraitModel> Traits
        {
            get { return _traits; }
        }

        private Models.TemplateTraitModel _selectedTrait;
        public Models.TemplateTraitModel SelectedTrait
        {
            get { return _selectedTrait; }
            set
            {
                if (_selectedTrait != value)
                {
                    _selectedTrait = value;

                    if (value != null)
                        ActivateItem(new TemplateTraitViewModel(value, false));

                    NotifyOfPropertyChange(() => SelectedTrait);
                    NotifyOfPropertyChange(() => CanDelTrait);
                }
            }
        }
        public void AddTrait()
        {
            Models.TemplateTraitModel t = Models.TemplateTraitModel.NewTemplateTraitModel();
            t.EffectiveLevels = new HashSet<int>(new int[] { 2, 4, 6, 8, 10, 12 });
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
