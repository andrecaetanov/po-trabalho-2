using ILOG.Concert;
using ILOG.CPLEX;
using LinearProgrammingSolver.Domain.Entities.Model;
using LinearProgrammingSolver.Domain.Entities.Result;
using LinearProgrammingSolver.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LinearProgrammingSolver.Domain
{
    public class Solver
    {
        public static Result Solve(Model model)
        {
            var cplex = new Cplex();

            var intVars = new List<IIntVar>();
            var coefficients = new List<int>();
            var intVarsDictionary = new Dictionary<string, IIntVar>();

            foreach (var variable in model.Variables)
            {
                var intVar = cplex.IntVar(0, int.MaxValue, variable.Name);

                intVars.Add(intVar);
                coefficients.Add(variable.Coefficient);
                intVarsDictionary.Add(variable.Name, intVar);
            }

            SetObjectiveExpression(model, cplex, intVars, coefficients);

            SetConstraints(model, cplex, intVarsDictionary);

            var solutionFound = cplex.Solve();

            return GetResult(model, cplex, intVarsDictionary, solutionFound);
        }

        private static void SetObjectiveExpression(Model model, Cplex cplex, List<IIntVar> intVars, List<int> coefficients)
        {
            var expression = cplex.LinearIntExpr();
            expression.AddTerms(intVars.ToArray(), coefficients.ToArray());

            if (model.Objective == ObjectiveType.Maximize)
                cplex.AddMaximize(expression);

            else if (model.Objective == ObjectiveType.Minimize)
                cplex.AddMinimize(expression);
        }

        private static void SetConstraints(Model model, Cplex cplex, Dictionary<string, IIntVar> intVarsDictionary)
        {
            foreach (var constraint in model.Constraints)
            {
                var intExpressions = new List<IIntExpr>();

                foreach (var variable in constraint.Variables)
                {
                    var intVar = intVarsDictionary.GetValueOrDefault(variable.Name);
                    intExpressions.Add(cplex.Prod(variable.Coefficient, intVar));
                }

                if (constraint.Type == ConstraintType.Equal)
                    cplex.AddEq(cplex.Sum(intExpressions.ToArray()), constraint.Value);

                else if (constraint.Type == ConstraintType.GreaterThanOrEqual)
                    cplex.AddGe(cplex.Sum(intExpressions.ToArray()), constraint.Value);

                else if (constraint.Type == ConstraintType.LessThanOrEqual)
                    cplex.AddLe(cplex.Sum(intExpressions.ToArray()), constraint.Value);
            }
        }

        private static Result GetResult(Model model, Cplex cplex, Dictionary<string, IIntVar> intVarsDictionary, bool solutionFound)
        {
            Console.WriteLine("*** Solution found: " + solutionFound);

            if (solutionFound)
            {
                var objectiveValue = cplex.GetObjValue();
                var variableSolutions = new List<VariableSolution>();

                Console.WriteLine("*** Solution objetive value: " + objectiveValue);

                foreach (var variable in model.Variables)
                {
                    var intVar = intVarsDictionary.GetValueOrDefault(variable.Name);
                    var variableValue = cplex.GetValue(intVar);

                    var variableSolution = new VariableSolution(variable.Name, variableValue);
                    variableSolutions.Add(variableSolution);

                    Console.WriteLine("*** " + variable.Name + ": " + variableValue);
                }

                var solution = new Solution(objectiveValue, variableSolutions);
                return new Result(solutionFound, solution);
            }

            return new Result(solutionFound);
        }
    }
}
