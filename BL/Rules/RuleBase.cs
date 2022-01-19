using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rules
{
    public interface IRule
    {
        bool IsMatch(Provider provider);
    }
    public abstract class RuleBase<T> : IRule
    {
        protected RuleBase(T param){
            this.param = param;
        }
        protected T param { get; set; }
        public abstract bool IsMatch(Provider provider);
    }
    public class SpecialtyRule : RuleBase<string>
    {
        public SpecialtyRule(string param) : base(param) { }
        public override bool IsMatch(Provider provider)
        {
            return provider.Specialties.Any(sp => String.Compare(sp, param, true) == 0);
        }
    }
    public class ScoreRule : RuleBase<float>
    {
        public ScoreRule(float param) : base(param) { }

        public override bool IsMatch(Provider provider)
        {
            return provider.Score >= param;
        }
    }
    public class AvailableRule : RuleBase<long>
    {
        public AvailableRule(long param) : base(param) { }
        public override bool IsMatch(Provider provider)
        {
            return provider.AvailableDates.Any(availableDate => availableDate.From <= param && availableDate.To >= param);
        }
    }
    public class NameRule : RuleBase<string>
    {
        public NameRule(string param) : base(param) { }

        public override bool IsMatch(Provider provider)
        {
            return provider.Name == param;
        }
    }
}
