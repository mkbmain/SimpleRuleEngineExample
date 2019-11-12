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
        public bool Parsed(RuleModelData data,string RuleToRun,IEnumerable<IRule> rules = null, bool appendRules = true)
        {
            if (rules != null && !appendRules)
            {
                return rules.All(x => x.Parse(data));
            }

            var items = TypeHelper.GetAllOfType<IRule>();
            if (RuleToRun != null)
            {     
                items =  items.Where(f => f.Name == RuleToRun);
            }
      
            
            var ruleList = items.Select(item => (IRule) Activator.CreateInstance(item)).ToList();
            if (rules != null)
            {
               ruleList.AddRange(rules);
            }

            return ruleList.Distinct().All(x => x.Parse(data));
        }
    }
}