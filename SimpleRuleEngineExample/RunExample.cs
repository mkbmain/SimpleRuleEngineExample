using SimpleRulesEngineCore;
using SimpleRulesEngineCore.Helpers;
using SimpleRulesEngineCore.Models;

namespace SimpleRuleEngineExample
{
    public class RunExample
    {
        public static void Main()
        {
            var rr = new RunRules();
            var model = new RuleModelData {NumberOfPassengers = 22, NumberOfSeats = 28};
            bool result;
            result = rr.RunSingleRule(model, "RelaxedRule").AllParsed(); // obviously RelaxedRule could be loaded in via config or data store
            result = rr.RunSingleRule(model, "GreedRule").AllParsed(); // obviously RelaxedRule could be loaded in via config or data store
            result = rr.Run(model).AllParsed(); // run all rules

            var allResults = rr.Run(model);
            
        }
    }
}