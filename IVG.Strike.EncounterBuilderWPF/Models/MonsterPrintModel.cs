using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class MonsterPrintModel
    {
        public Guid MonsterID { get; set; }
        public string MonsterName { get; set; }
        public int MonsterLevel { get; set; }
        public int MonsterSize { get; set; }
        public int MonsterSpeed { get; set; }
        public string MonsterText { get; set; }
        public string MonsterType { get; set; }
        public int MonsterHitPoints { get; set; }
        public string TraitName { get; set; }
        public string TraitText { get; set; }
        public string PowerName { get; set; }
        public int PowerDamage { get; set; }
        public int PowerRange { get; set; }
        public bool PowerIsRanged { get; set; }
        public bool PowerIsMelee { get; set; }
        public int PowerBurst { get; set; }
        public string PowerText { get; set; }
        public string PowerActionType { get; set; }
        public string PowerUsageType { get; set; }
        public bool PowerIsMissTrigger { get; set; }
    }
}
