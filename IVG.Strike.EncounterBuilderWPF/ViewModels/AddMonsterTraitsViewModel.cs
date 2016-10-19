using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class AddMonsterTraitsViewModel : Screen
    {
        public AddMonsterTraitsViewModel(BindableCollection<Models.TraitModel> traits, 
            BindableCollection<Models.TraitModel> mosnterTraits)
        {
            TraitListVM = new TraitListViewModel(traits);
            _monsterTraits = mosnterTraits;
        }

        public TraitListViewModel TraitListVM { get; }

        private BindableCollection<Models.TraitModel> _monsterTraits;
        public BindableCollection<Models.TraitModel> MonsterTraits
        {
            get { return _monsterTraits; }
        }

        private Models.TraitModel _selectedMonsterTrait;
        public Models.TraitModel SelectedMonsterTrait
        {
            get { return _selectedMonsterTrait; }
            set
            {
                if (_selectedMonsterTrait != value)
                {
                    _selectedMonsterTrait = value;

                    NotifyOfPropertyChange(() => SelectedMonsterTrait);
                    NotifyOfPropertyChange(() => CanDelMonsterTrait);
                }
            }
        }
        public void AddTraitFromList()
        {
            _monsterTraits.Add(TraitListVM.SelectedTrait);
        }
        public void DelMonsterTrait()
        {
            _monsterTraits.Remove(SelectedMonsterTrait);

            SelectedMonsterTrait = null;
        }
        public bool CanDelMonsterTrait
        {
            get { return SelectedMonsterTrait != null; }
        }
    }
}
