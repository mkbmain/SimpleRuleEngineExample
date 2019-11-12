using SimpleRulesEngineCore.Models;

namespace SimpleRulesEngineCore.Rules
{
    internal class RelaxedRule : IRule
    {
        private const int PercentHigerThan = 75; 
        public bool Parse(RuleModelData data)
        {
            return data.PercentageFull > PercentHigerThan;
        }
    }
}