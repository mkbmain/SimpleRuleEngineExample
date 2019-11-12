using SimpleRulesEngineCore.Models;

namespace SimpleRulesEngineCore.Rules
{
    public interface IRule
    {
        bool Parse(RuleModelData data);
    }
}