namespace LinearProgrammingSolver.Domain.Entities.Result
{
    public class Result
    {
        public bool SolutionFound { get; set; }
        public Solution Solution { get; set; }

        public Result(bool solutionFound)
        {
            SolutionFound = solutionFound;
        }

        public Result(bool solutionFound, Solution solution)
        {
            SolutionFound = solutionFound;
            Solution = solution;
        }
    }
}
