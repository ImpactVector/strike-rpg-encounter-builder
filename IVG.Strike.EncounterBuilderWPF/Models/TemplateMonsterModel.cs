using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class TemplateMonsterModel : MonsterBaseModel
    {
        private TemplatePowerModelList _powers;
        private TemplateTraitModelList _traits;
        private bool _isSpecialist;

        protected TemplateMonsterModel()
        {
        }

        public static TemplateMonsterModel NewTemplateMonsterModel()
        {
            TemplateMonsterModel m = new TemplateMonsterModel();

            m.Name = "NewTemplate";
            m.Size = 1;
            m.Speed = 6;
            m.Text = string.Empty;
            m.Traits = new TemplateTraitModelList();
            m.Powers = new TemplatePowerModelList();

            return m;
        }

        public TemplatePowerModelList Powers
        {
            get
            {
                return _powers;
            }

            set
            {
                _powers = value;
                OnPropertyChanged("Powers");
            }
        }

        public TemplateTraitModelList Traits
        {
            get
            {
                return _traits;
            }

            set
            {
                _traits = value;
                OnPropertyChanged("Traits");
            }
        }

        public bool IsSpecialist
        {
            get
            {
                return _isSpecialist;
            }

            set
            {
                _isSpecialist = value;
                OnPropertyChanged("IsSpecialist");
            }
        }

        public MonsterModel GetMonster(int level, MonsterType type, string name = null, string text = null)
        {
            int hp = 1;

            switch (type)
            {
                case MonsterType.Stooge:
                    hp = 1;
                    break;
                case MonsterType.Goon:
                    {
                        if (level < 5)
                            hp = 4;
                        else
                            hp = 5;
                    }
                    break;
                case MonsterType.Standard:
                    hp = (level * 2) + 6;
                    break;
                case MonsterType.Elite:
                    hp = ((level * 2) + 6) * 2;
                    break;
                case MonsterType.Champion:
                case MonsterType.Titan:
                    hp = ((level * 2) + 6) * 4;
                    break;
            }

            MonsterModel m = MonsterModel.NewMonsterModel();
            m.Name = string.IsNullOrEmpty(name) ? this.Name : name + " (" + this.Name + ")";
            m.Level = level;
            m.Speed = this.Speed;
            m.Text = string.IsNullOrEmpty(text) ? this.Text : text;
            m.Powers = this.Powers.GetPowerList(level, type, this.IsSpecialist);
            m.Traits = this.Traits.GetTraitList(level, type, this.IsSpecialist);
            m.HitPoints = hp;
            m.Type = type;
            m.Size = this.Size;
            
            return m; 
            
        }
    }
}
