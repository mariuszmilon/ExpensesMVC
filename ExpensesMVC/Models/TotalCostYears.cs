namespace ExpensesMVC.Models
{
    public class TotalCostYears
    {
        public TotalCostYears()
        {
            January = 0;
            February = 0;
            March = 0;
            April = 0;
            May = 0;
            June = 0;
            July = 0;
            August = 0;
            September = 0;
            October = 0;
            November = 0;
            December = 0;
        }

        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
    }
}
