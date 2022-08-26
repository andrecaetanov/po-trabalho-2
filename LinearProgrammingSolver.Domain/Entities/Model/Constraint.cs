using LinearProgrammingSolver.Domain.Enums;
using System.Collections.Generic;

namespace LinearProgrammingSolver.Domain.Entities.Model
{
    public class Constraint
    {
        public List<Variable> Variables { get; set; }
        public ConstraintType Type { get; set; }
        public double Value { get; set; }
    }
}
