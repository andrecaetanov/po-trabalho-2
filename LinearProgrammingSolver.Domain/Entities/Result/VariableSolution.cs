namespace LinearProgrammingSolver.Domain.Entities.Result
{
    public class VariableSolution
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public VariableSolution(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
