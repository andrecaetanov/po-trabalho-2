using System.Collections.Generic;

namespace LinearProgrammingSolver.Domain.Entities.Result
{
    public class Solution
    {
        public double ObjectiveValue { get; set; }
        public List<VariableSolution> Variables { get; set; }

        public Solution(double objectiveValue, List<VariableSolution> variables)
        {
            ObjectiveValue = objectiveValue;
            Variables = variables;
        }
    }
}
