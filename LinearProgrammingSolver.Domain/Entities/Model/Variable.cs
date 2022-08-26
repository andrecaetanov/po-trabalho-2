namespace LinearProgrammingSolver.Domain.Entities.Model
{
    public class Variable
    {
        public string Name { get; set; }
        public int Coefficient { get; set; }

        public Variable(string name, int coefficient)
        {
            Name = name;
            Coefficient = coefficient;
        }
    }
}
