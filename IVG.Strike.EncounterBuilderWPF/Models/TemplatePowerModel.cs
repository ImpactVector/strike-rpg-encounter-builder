using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVG.Strike.EncounterBuilderWPF.Interfaces;
using Newtonsoft.Json;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class TemplatePowerModel : PowerModel, IGenericJsonClone<TemplatePowerModel>
    {
        protected TemplatePowerModel()
        {
        }

        public static TemplatePowerModel NewTemplatePowerModel()
        {
            TemplatePowerModel m = new TemplatePowerModel();

            m.Name = "NewPower";
            m.ActionType = PowerActionType.Action;
            m.UsageType = PowerUsageType.AtWill;

            return m;
        }

        #region Private Variables

        private HashSet<int> _effectiveLevels;
        private int _effectDamage;

        #endregion

        #region Public Properties

        public HashSet<int> EffectiveLevels
        {
            get
            {
                return _effectiveLevels;
            }

            set
            {
                _effectiveLevels = value;
                OnPropertyChanged("EffectiveLevels");
            }
        }

        public int EffectDamage
        {
            get
            {
                return _effectDamage;
            }

            set
            {
                _effectDamage = value;
                OnPropertyChanged("EffectDamage");
            }
        }

        public TemplatePowerModel Clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<TemplatePowerModel>(serialized);
        }

        #endregion

    }
}
