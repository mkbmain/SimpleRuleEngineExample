using System;
using System.Collections.Generic;
using System.Linq;
using SimpleRulesEngineCore.Helpers;
using SimpleRulesEngineCore.Models;
using SimpleRulesEngineCore.Rules;

namespace SimpleRulesEngineCore
{
    public class RunRules
    {
        public Dictionary<IRule, bool> RunSingleRule(RuleModelData data, string rule)
        {
            if (rule == null)
            {
                return new Dictionary<IRule, bool>();
            }

            return Run(data, GetRules(rule));
        }

        public Dictionary<IRule, bool> Run(RuleModelData data)
        {
            return RunAllWithAppend(data, new IRule[0]);
        }

        public Dictionary<IRule, bool> RunAllWithAppend(RuleModelData data, IEnumerable<IRule> rules)
        {
            return Run(data, GetRules().Union(rules));
        }

        public Dictionary<IRule, bool> Run(RuleModelData data, IEnumerable<IRule> rules)
        {
            return rules.Select(f => new {Ob = f, Result = f.Parse(data)})
                .GroupBy(f => f.Ob)
                .ToDictionary(f => f.Key, f => f.Select(x => x.Result).First());
        }

        private IEnumerable<IRule> GetRules(string ruleName = null)
        {
            var items = TypeHelper.GetAllOfType<IRule>();

            if (ruleName != null)
            {
                var item = items.FirstOrDefault(f => f.Name == ruleName);
                if (item != null)
                {
                    return new[] {(IRule) Activator.CreateInstance(item)};
                }

                return new IRule[0];
            }

            return items.Select(f => (IRule) Activator.CreateInstance(f));
        }
    }
}