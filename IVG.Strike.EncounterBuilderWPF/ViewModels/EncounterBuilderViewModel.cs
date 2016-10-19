using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class EncounterBuilderViewModel : Conductor<PropertyChangedBase>
    {
        public EncounterBuilderViewModel(BindableCollection<Models.MonsterModel> monsters)
        {
            DisplayName = "Encounter Designer";
            _monsters = monsters;
            _encounterMonsters = new BindableCollection<Models.MonsterModel>();
        }

        private BindableCollection<Models.MonsterModel> _monsters;
        public BindableCollection<Models.MonsterModel> Monsters
        {
            get { return _monsters; }
        }

        private BindableCollection<Models.MonsterModel> _encounterMonsters;
        public BindableCollection<Models.MonsterModel> EncounterMonsters
        {
            get { return _encounterMonsters; }
        }

        private Models.MonsterModel _selectedMonster;
        public Models.MonsterModel SelectedMonster
        {
            get { return _selectedMonster; }
            set
            {
                if (_selectedMonster != value)
                {
                    _selectedMonster = value;

                    if (value != null)
                        ActivateItem(new MonsterViewModel(value, null, true));

                    NotifyOfPropertyChange(() => SelectedMonster);
                    NotifyOfPropertyChange(() => CanAddMonsterToEncounter);
                }
            }
        }

        private Models.MonsterModel _selectedEncounterMonster;
        public Models.MonsterModel SelectedEncounterMonster
        {
            get { return _selectedEncounterMonster; }
            set
            {
                if (_selectedEncounterMonster != value)
                {
                    _selectedEncounterMonster = value;

                    NotifyOfPropertyChange(() => SelectedEncounterMonster);
                    NotifyOfPropertyChange(() => CanDelEncounterMonster);
                }
            }
        }

        public void AddMonsterToEncounter()
        {
            _encounterMonsters.Add(SelectedMonster);
        }
        public void DelEncounterMonster()
        {
            DeactivateItem(ActiveItem, true);

            _encounterMonsters.Remove(SelectedEncounterMonster);

            SelectedEncounterMonster = null;
        }
        public bool CanAddMonsterToEncounter
        {
            get { return SelectedMonster != null; }
        }
        public bool CanDelEncounterMonster
        {
            get { return SelectedEncounterMonster != null; }
        }

        public void PrintEncounter()
        {
            List<Models.MonsterPrintModel> l = new List<Models.MonsterPrintModel>();

            foreach (Models.MonsterModel m in EncounterMonsters)
                l.AddRange(m.GetPrintMonster());

            IVG.Strike.EncounterBuilderWPF.Views.MonsterPrintPreview mpv = new EncounterBuilderWPF.Views.MonsterPrintPreview(l);
            mpv.Owner = (Window)this.GetView();
            mpv.ShowDialog();
        }
    }
}
