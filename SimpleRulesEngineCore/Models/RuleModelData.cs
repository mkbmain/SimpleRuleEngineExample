namespace SimpleRulesEngineCore.Models
{
    public class RuleModelData
    {
        public int NumberOfPassengers { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal PercentageFull => 100m / ((decimal) NumberOfSeats / (decimal) NumberOfPassengers);
    }
}