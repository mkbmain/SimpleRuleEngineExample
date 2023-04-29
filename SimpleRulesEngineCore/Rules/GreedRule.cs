using SimpleRulesEngineCore.Models;

namespace SimpleRulesEngineCore.Rules
{
    internal class GreedRule : IRule
    {
        private const int PercentHigherThan = 90;
        public bool Parse(RuleModelData data)
        {
            return data.PercentageFull > PercentHigherThan;
        }
    }
}