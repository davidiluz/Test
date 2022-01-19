using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rules
{
    public class RulesHolder
    {
        public List<IRule> rules { get; set; } = new List<IRule>();
        public bool ApplyAllRules(Provider provider)
        {
            return rules.All(rule => rule.IsMatch(provider));
        }
        public void addSpecialtyRule(string param)
        {
            rules.Add(new SpecialtyRule(param));
        }
        public void addScoreRule(float param)
        {
            rules.Add(new ScoreRule(param));
        }
        public void addAvailabiltyRule(long param)
        {
            rules.Add(new AvailableRule(param));
        }
        public void addNameRule(string name)
        {
            rules.Add(new NameRule(name));
        }
    }
}
