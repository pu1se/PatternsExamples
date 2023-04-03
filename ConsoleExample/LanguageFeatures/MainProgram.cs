using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleExample.LanguageFeatures
{
    internal class MainProgram
    {
        public static void Code([CallerMemberName] string callerMethod = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callingLine = 0)
        {
            // c# 5, get information about caller.
            // c# 5 interpolation.
            WriteLine($"caller method: {callerMethod}, caller file path: {callerFilePath}, calling line: {callingLine}");

            WriteLine();

            // c# 7 out variable.
            if (IsItPossibleToCombine(5, 10, out var result))
            {
                WriteLine($"5 + 10 = {result}");
            }

            var anotherResult = IsItPossibleToCombine(5, 10);
            if (anotherResult.isItPossbile)
            {
                WriteLine($"5 + 10 = {anotherResult.result}");
            }

            (bool isItPossible, result) = IsItPossibleToCombine(5, 15);
            if (isItPossible)
            {
                WriteLine($"5 + 10 = {result}");
            }

            WriteLine();

            var canIDoCombination = new Func<int, int, (bool canIDoCombination, int resultOfCombination)>
                ((a,b) => (true, a+b));
            var (canIDoThis, result2) = canIDoCombination(50, 10);
            if (canIDoThis)
                WriteLine($"50 + 10 = {result2}");

            WriteLine();

            var me = (Name: "Pasha", Surname: "Pontus");
            WriteLine($"This is {me.Name} {me.Surname}");

            WriteLine();


            // c# 8 pattern matching. Use as validation:
            var user = new User
            {
                Name = "Peter",
                Age = 16,
                Salary = 2000
            };
            var errorMessage = user switch
            {
                null => "Object is missing",
                { Name: null } => "Name is missing",
                { Age: 0 } => "Age is missing",
                { Salary: 0 } => "Salary is missing",
                { Age: var age } when age < 18 => "User must be older then 18.",
                { Salary: var salary } when salary < 1000 => "Salary must be bigger then 1000",
                _ => null
            };
            if (errorMessage != null)
            {
                WriteLine(errorMessage);
            }

            WriteLine();WriteLine();WriteLine();
        }

        static bool IsItPossibleToCombine(int a, int b, out int result)
        {
            result = a + b;
            return true;
        }

        static (bool isItPossbile, int result) IsItPossibleToCombine(int a, int b)
        {
            return (true, a + b);
        }

        private class Shape
        {
            public int Width, Height;
        }

        private class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }
        }
    }
}
