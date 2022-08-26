using LinearProgrammingSolver.Domain;
using System;

namespace LinearProgrammingSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Linear Programming Solver -----");

            var modelFileName = "Model.json";
            Console.WriteLine("*** Reading model file: " + modelFileName);
            var model = FileManager.ReadModelFile(modelFileName);

            Console.WriteLine("*** Solving model");
            var result = Solver.Solve(model);

            var resultFileName = "Result.json";
            Console.WriteLine("*** Writing result file: " + resultFileName);
            FileManager.WriteResultFile(resultFileName, result);
        }
    }
}
