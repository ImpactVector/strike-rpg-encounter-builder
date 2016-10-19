using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class TemplateTraitModelList : BindableCollection<TemplateTraitModel>
    {
        public BindableCollection<TraitModel> GetTraitList(int level, MonsterType type, bool isSpecialist)
        {
            List<TraitModel> traits = new List<TraitModel>();

            switch (type)
            {
                case MonsterType.Stooge:
                    {
                        this.ToList().Where(p => (p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(level))).ToList().ForEach(p => traits.Add(p.Clone()));
                        traits.Add(TraitModel.NewTraitModel("Stooge", "N/A", "The base damage of your Opportunities is 1.", TraitType.MonsterType ));
                    }
                    break;
                case MonsterType.Goon:
                case MonsterType.Standard:
                    {
                        this.ToList().Where(p => p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(level)).ToList().ForEach(p => traits.Add(p.Clone()));
                    }
                    break;
                case MonsterType.Elite:
                    {
                        this.ToList().Where(p => p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(Math.Min(level * 2, 12))).ToList().ForEach(p => traits.Add(p.Clone()));
                        traits.Add(TraitModel.NewTraitModel("Elite", "N/A", "While you are not Bloodied, you automatically succeed on all Saving Throws. While Bloodied, you take two consecutive turns on your Initiative count.", TraitType.MonsterType ));
                    }
                    break;
                case MonsterType.Champion:
                    {
                        this.ToList().Where(p => p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(Math.Min(level * 2, 12))).ToList().ForEach(p => traits.Add(p.Clone()));
                        traits.Add(TraitModel.NewTraitModel("Champion", "N/A", "<div>You act on Initiative counts of 7, 5, and 3. You automatically succeed at all Saving Throws.</div><div style=\"padding-top:5pt\">Each of these Initiative counts is a full turn for you.So if a Status terminates at the end of your next turn, you only suffer on one of your Initiative counts.</div>", TraitType.MonsterType ));
                    }
                    break;
            }

            //normal monsters 6 and up and specialists 10 and up recharge, but stooges and goons don't have encounter powers
            if ((type != MonsterType.Stooge && type != MonsterType.Goon) && (level >= 10 || (level >= 6 && !isSpecialist)))
                traits.Add(TraitModel.NewTraitModel("Recharge", "1", "When you roll a 5 or 6 on a single-target attack or a 6 on a multi - target attack, you recharge one Encounter Power.", TraitType.Attacking ));
            
            if ((level >= 10 && isSpecialist) || (level >= 6 && level < 10 && !isSpecialist))
                traits.Add(TraitModel.NewTraitModel("Extra Damage", "3", "+1 damage to all attacks (included in powers).", TraitType.Attacking ));
            else if (level >= 10) //&& !isSpecialist
                traits.Add(TraitModel.NewTraitModel("Super Damage", "7", "+2 damage to all attacks (included in powers).", TraitType.Attacking ));
            
            return new BindableCollection<TraitModel>(traits);
        }
    }
}
