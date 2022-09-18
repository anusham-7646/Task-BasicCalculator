namespace BasicCalculatorServer.Model
{
    public class CalculatorDbModel
    {
        public Guid Id { get; set; }

        public double FirstNumber { get; set; }

        public double SecondNumber { get; set; }

        public string Operator { get; set; }

        public double Result { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
