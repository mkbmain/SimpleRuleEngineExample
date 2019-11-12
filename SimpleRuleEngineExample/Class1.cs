using System;
using System.Data;
using SimpleRulesEngineCore;
using SimpleRulesEngineCore.Models;

namespace SimpleRuleEngineExample
{
    public class Class1
    {
        public static void Main()
        {
            var rr = new RunRules();
            var model = new RuleModelData {NumberOfPassengers = 22, NumberOfSeats = 28};
            bool result;
            result = rr.Parsed(model, "RelaxedRule"); // obviously RelaxedRule could be loaded in via config or data store
            result = rr.Parsed(model, "GreedRule"); // obviously RelaxedRule could be loaded in via config or data store
            result = rr.Parsed(model, null); // run all rules
        }
    }
}