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
    public class TemplateTraitModel :TraitModel, IGenericJsonClone<TemplateTraitModel>
    {
        protected TemplateTraitModel()
        {
        }

        public static TemplateTraitModel NewTemplateTraitModel()
        {
            TemplateTraitModel m = new TemplateTraitModel();

            m.Name = "NewTrait";
            m.Text = string.Empty;
            m.Cost = string.Empty;
            m.Type = TraitType.None;
            m.EffectiveLevels = new HashSet<int>(new int[] { 2, 4, 6, 8, 10, 12 });

            return m;
        }

        public static TemplateTraitModel NewTemplateTraitModel(TraitModel trait)
        {
            TemplateTraitModel m = new TemplateTraitModel();

            m.Name = trait.Name;
            m.Text = trait.Text;
            m.Cost = trait.Cost;
            m.Type = trait.Type;
            m.EffectiveLevels = new HashSet<int>(new int[] { 2, 4, 6, 8, 10, 12 });

            return m;
        }

        #region Private Variables

        private HashSet<int> _effectiveLevels;

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
            }
        }

        #endregion

        public new TemplateTraitModel Clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<TemplateTraitModel>(serialized);
        }
    }
}
