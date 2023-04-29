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
            return rule == null ? new Dictionary<IRule, bool>() : Run(data, GetRule(rule));
        }
        
        public Dictionary<IRule, bool> RunMultipleRules(RuleModelData data, string[] rule)
        {
            return rule == null ? new Dictionary<IRule, bool>() : Run(data, GetRules(rule));
        }

        public Dictionary<IRule, bool> Run(RuleModelData data)
        {
            return RunAllWithAppend(data, Array.Empty<IRule>());
        }

        public Dictionary<IRule, bool> RunAllWithAppend(RuleModelData data, IEnumerable<IRule> rules)
        {
            return Run(data, GetRule().Union(rules));
        }

        public Dictionary<IRule, bool> Run(RuleModelData data, IEnumerable<IRule> rules)
        {
            return rules.Select(f => new {Ob = f, Result = f.Parse(data)})
                .GroupBy(f => f.Ob)
                .ToDictionary(f => f.Key, f => f.Select(x => x.Result).First());
        }

        private IEnumerable<IRule> GetRule(string ruleName = null)
        {
            return GetRules(ruleName is null ? null : new[] { ruleName });
        }
        
        private IEnumerable<IRule> GetRules(string[] ruleName = null)
        {
            var items = TypeHelper.GetAllOfType<IRule>();

            if (ruleName == null) return items.Select(f => (IRule)Activator.CreateInstance(f));
            var item = items.FirstOrDefault(f =>  ruleName.Contains(f.Name));
            return item != null ?
                new[] {(IRule) Activator.CreateInstance(item)} : 
                Array.Empty<IRule>();
        }
        
    }
}