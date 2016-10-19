using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class TraitModel : BaseModel
    {
        private string _text;
        private string _cost;
        private TraitType _type;

        protected TraitModel()
        {
        }

        public static TraitModel NewTraitModel()
        {
            TraitModel m = new TraitModel();

            m.Name = "NewTrait";
            m.Text = string.Empty;
            m.Cost = string.Empty;
            m.Type = TraitType.None;

            return m;
        }

        public static TraitModel NewTraitModel(string name, string cost, string text, TraitType type)
        {
            TraitModel m = new TraitModel();

            m.Name = name;
            m.Text = text;
            m.Cost = cost;
            m.Type = type;

            return m;
        }

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public string Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public TraitType Type
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

        public TraitModel Clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<TraitModel>(serialized);
        }
    }
    public enum TraitType
    {
        None,
        MonsterType,
        Attacking,
        Defending,
        Movement,
        [Description("Role/Misc")]
        RoleMisc,
        Negative
    }
}
