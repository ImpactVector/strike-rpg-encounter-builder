using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    [XmlRoot("Data")]
    public class SystemModel
    {
        public SystemModel()
        {
        }

        public List<MonsterModel> Monsters { get; set; }
        public List<TemplateMonsterModel> Templates { get; set; }
        public List<TraitModel> Traits { get; set; }
    }
}
