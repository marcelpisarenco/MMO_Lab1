using System;
using Google.OrTools.LinearSolver; // Or-Tools lybrary

public class MMO_Lab1
{
    static void Main()
    {
        //define 2 solver objects
        Solver solver = Solver.CreateSolver("GLOP");
        Solver solver1 = Solver.CreateSolver("CBC_MIXED_INTEGER_PROGRAMMING");
        //use function to find maximal profit first problem and to find minimal cost for second problem
        Maximize(solver);
        Minimize(solver1);
        
    }
    static void Maximize (Solver solver)//function for maximize
    {
        if (solver is null)
        {
            return;
        }
        // define continuous non-negative variables variables

        var a = solver.MakeNumVar(0.0, double.PositiveInfinity, "a");
        var b = solver.MakeNumVar(0.0, double.PositiveInfinity, "b");
        var c = solver.MakeNumVar(0.0, double.PositiveInfinity, "c");
        var d = solver.MakeNumVar(0.0, double.PositiveInfinity, "d");
        var e = solver.MakeNumVar(0.0, double.PositiveInfinity, "e");
        Console.WriteLine("Maximize Function:");
        Console.WriteLine("Number of decisional variables = " + solver.NumVariables());
        //define constraints
        solver.Add(a <= 120);
        solver.Add(b <= 100);
        solver.Add(c <= 80);
        solver.Add(d <= 70);
        solver.Add(e <= 50);
        solver.Add(a + b + c + d + e >= 200);
        solver.Add(a >= 50);
        solver.Add(b >= 30);

        Console.WriteLine("Number of constraints = " + solver.NumConstraints());
        // Objective function
        solver.Maximize(-2000 * a + 5000 * b - 2500 * c + 7000 * d + 8000 * e);

        Solver.ResultStatus resultStatus = solver.Solve();

        // Check that the problem has an optimal solution.
        if (resultStatus != Solver.ResultStatus.OPTIMAL)
        {
            Console.WriteLine("The problem does not have an optimal solution!");
            return;
        }
        //display solution
        Console.WriteLine("Solution:");
        Console.WriteLine("Maximal Profit = " + solver.Objective().Value());
        Console.WriteLine("A = " + a.SolutionValue());
        Console.WriteLine("B = " + b.SolutionValue());
        Console.WriteLine("C = " + c.SolutionValue());
        Console.WriteLine("D = " + d.SolutionValue());
        Console.WriteLine("E = " + e.SolutionValue());
        Console.WriteLine();
    }

    static void Minimize(Solver solver)//function for minimize
    {
        if (solver is null)
        {
            return;
        }
        // variables are continuous non-negative variables.

        Variable a = solver.MakeIntVar(0.0, double.PositiveInfinity, "a");
        Variable b = solver.MakeIntVar(0.0, double.PositiveInfinity, "b");
        Variable c = solver.MakeIntVar(0.0, double.PositiveInfinity, "c");
        Variable d = solver.MakeIntVar(0.0, double.PositiveInfinity, "d");
        Variable e = solver.MakeIntVar(0.0, double.PositiveInfinity, "e");
        Console.WriteLine("Minimize function:");
        Console.WriteLine("Number of decisional variables = " + solver.NumVariables());
        //defined constraints
        solver.Add(a >= 0);
        solver.Add(b >= 0);
        solver.Add(c >= 0);
        solver.Add(d >= 0);
        solver.Add(e >= 0);
        solver.Add((20 * a) + (30 * b) + (15 * c) + (10 * d) + (40 * e) >= 60);
        solver.Add((500 * a) + (250 * b) + (350 * c) + (200 * d) + (600 * e) >= 1000);
        solver.Add((9 * a) + (6 * b) + (7 * c) + (5 * d) + (12 * e) >= 18);
        solver.Add((2 * a) + (10 * b) + (7 * c) + (5 * d) + (10 * e) >= 20);
        solver.Add((60 * a) + (90 * b) + (80 * c) + (50 * d) + (120 * e) >= 360);


        Console.WriteLine("Number of constraints = " + solver.NumConstraints());
        // Objective function
        solver.Minimize(4 * a + 6 * b + 8 * c + 2 * d + 15 * e);

        Solver.ResultStatus resultStatus = solver.Solve();

        // Check that the problem has an optimal solution.
        if (resultStatus != Solver.ResultStatus.OPTIMAL)
        {
            Console.WriteLine("The problem does not have an optimal solution!");
            return;
        }
        Console.WriteLine("Solution:");
        Console.WriteLine("Minimal Cost = " + solver.Objective().Value());
        Console.WriteLine("A = " + a.SolutionValue());
        Console.WriteLine("B = " + b.SolutionValue());
        Console.WriteLine("C = " + c.SolutionValue());
        Console.WriteLine("D = " + d.SolutionValue());
        Console.WriteLine("E = " + e.SolutionValue());
        Console.WriteLine();
    }
}
