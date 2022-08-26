using LinearProgrammingSolver.Domain.Enums;
using System.Collections.Generic;

namespace LinearProgrammingSolver.Domain.Entities.Model
{
    public class Model
    {
        public ObjectiveType Objective { get; set; }
        public List<Variable> Variables { get; set; }
        public List<Constraint> Constraints { get; set; }
    }
}
