using System.Collections.Generic;
using System.Linq;
using SimpleRulesEngineCore.Rules;

namespace SimpleRulesEngineCore
{
    public static class Extensions
    {
        public static bool AllParsed(this Dictionary<IRule, bool> item)
        {
            return item.All(x => x.Value);
        }
    }
}