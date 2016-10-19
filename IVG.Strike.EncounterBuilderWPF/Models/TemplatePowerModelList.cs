using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.Models
{
    [Serializable]
    public class TemplatePowerModelList : BindableCollection<TemplatePowerModel>
    {
        public BindableCollection<PowerModel> GetPowerList(int level, MonsterType type, bool isSpecialist)
        {
            List<TemplatePowerModel> powers = new List<TemplatePowerModel>();

            switch (type)
            {
                case MonsterType.Stooge:
                    {
                        this.ToList().Where(p => (p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(level)) && p.UsageType != PowerUsageType.Encounter && !p.IsMissTrigger).ToList().ForEach(p => powers.Add(p.Clone()));
                        powers.ForEach(p => p.Text = p.Text.Replace("{d}", (p.EffectDamage - 1).ToString()));
                        powers.ForEach(p => p.Damage -= 1);
                    }
                    break;
                case MonsterType.Goon:
                    {
                        this.ToList().Where(p => (p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(level)) && p.UsageType != PowerUsageType.Encounter).ToList().ForEach(p => powers.Add(p.Clone()));
                        powers.ForEach(p => p.Text = p.Text.Replace("{d}", (p.EffectDamage).ToString()));
                    }
                    break;
                case MonsterType.Standard:
                    {
                        this.ToList().Where(p => p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(level)).ToList().ForEach(p => powers.Add(p.Clone()));
                        powers.ForEach(p => p.Text = p.Text.Replace("{d}", (p.EffectDamage).ToString()));
                    }
                    break;
                case MonsterType.Elite:
                case MonsterType.Champion:
                    {
                        this.ToList().Where(p => p.EffectiveLevels.Count == 0 || p.EffectiveLevels.Contains(Math.Min(level * 2, 12))).ToList().ForEach(p => powers.Add(p.Clone()));
                        powers.ForEach(p => p.Damage += 1);
                        powers.ForEach(p => p.Text = p.Text.Replace("{d}", (p.EffectDamage).ToString()));
                    }
                    break;
            }

            if ((level >= 10 && isSpecialist) || (level >= 6 && level < 10 && !isSpecialist))
                powers.ForEach(p => p.Damage += 1);
            else if (level >= 10) //&& !isSpecialist
                powers.ForEach(p => p.Damage += 2);

            return new BindableCollection<PowerModel>(powers);
        }
    }
}
