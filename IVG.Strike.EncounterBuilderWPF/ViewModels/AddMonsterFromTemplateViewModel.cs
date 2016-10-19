using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class AddMonsterFromTemplateViewModel : Screen
    {
        public AddMonsterFromTemplateViewModel()
        {
            DisplayName = "Add Monster from Template";
            MonsterName = "TemplateMonster";
            SelectedLevel = 2;
            SelectedMonsterType = Models.MonsterType.Standard.ToString();
        }

        public string MonsterName { get; set; }
        public int SelectedLevel { get; set; }
        public HashSet<int> Levels { get { return new HashSet<int>(new int[] { 2, 4, 6, 8, 10, 12 }); } }

        public List<string> MonsterTypes
        {
            get
            {
                return Enum.GetNames(typeof(Models.MonsterType)).ToList();
            }
        }
        private string _selectedMonsterType;
        public string SelectedMonsterType
        {
            get { return _selectedMonsterType; }
            set
            {
                if (_selectedMonsterType != value)
                {
                    _selectedMonsterType = value;
                    NotifyOfPropertyChange(() => SelectedMonsterType);
                }
            }
        }
        public string MonsterText { get; set; }

        public void CreateMonster()
        {
            this.TryClose(true);
        }
    }
}
