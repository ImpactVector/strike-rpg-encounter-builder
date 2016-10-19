using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class MonsterModel : MonsterBaseModel
    {
        private MonsterModel()
        {
        }

        public static MonsterModel NewMonsterModel()
        {
            MonsterModel m = new MonsterModel();

            m.Name = "NewMonster";
            m.Level = 1;
            m.Size = 1;
            m.Speed = 6;
            m.Text = string.Empty;
            m.Type = MonsterType.Standard;
            m.HitPoints = 8;
            m.Traits = new BindableCollection<TraitModel>();
            m.Powers = new BindableCollection<PowerModel>();

            return m;
        }

        private int _level;
        private int _hitPoints;
        private MonsterType _type;
        private BindableCollection<PowerModel> _powers;
        private BindableCollection<TraitModel> _traits;

        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        public BindableCollection<PowerModel> Powers
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

        public BindableCollection<TraitModel> Traits
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

        public int HitPoints
        {
            get
            {
                return _hitPoints;
            }

            set
            {
                _hitPoints = value;
                OnPropertyChanged("HitPoints");
            }
        }

        public MonsterType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public List<MonsterPrintModel> GetPrintMonster()
        {
            List<MonsterPrintModel> l = new List<MonsterPrintModel>();

            Guid id = Guid.NewGuid();

            foreach (TraitModel t in Traits)
            {
                l.Add(new MonsterPrintModel()
                {
                    MonsterID = id,
                    MonsterHitPoints = HitPoints,
                    MonsterLevel = Level,
                    MonsterName = Name,
                    MonsterSize = Size,
                    MonsterSpeed = Speed,
                    MonsterText = Text,
                    MonsterType = Type.ToString(),
                    TraitName = t.Name,
                    TraitText = t.Text
                });
            }
            
            foreach (PowerModel p in Powers)
            {
                l.Add(new MonsterPrintModel()
                {
                    MonsterID = id,
                    MonsterHitPoints = HitPoints,
                    MonsterLevel = Level,
                    MonsterName = Name,
                    MonsterSize = Size,
                    MonsterSpeed = Speed,
                    MonsterText = Text,
                    MonsterType = Type.ToString(),
                    PowerName = p.Name,
                    PowerText = p.Text,
                    PowerActionType = p.ActionType.ToString(),
                    PowerBurst = p.Burst,
                    PowerDamage = p.Damage,
                    PowerIsMelee = p.IsMelee,
                    PowerIsMissTrigger = p.IsMissTrigger,
                    PowerIsRanged = p.IsRanged,
                    PowerRange = p.Range,
                    PowerUsageType = p.UsageType.ToString()
                });
            }

            return l;

        }
    }

    public enum MonsterType
    {
        Stooge,
        Goon,
        Standard,
        Elite,
        Champion,
        Titan
    }
}
