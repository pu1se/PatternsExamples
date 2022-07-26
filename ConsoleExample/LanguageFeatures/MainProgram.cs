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
            int a=5, b=15;
            (a, b) = (b, a);
            WriteLine(b + " " + a);

            // c# 5, get information about caller.
            // c# 5 interpolation.
            WriteLine($"caller method: {callerMethod}, caller file path: {callerFilePath}, calling line: {callingLine}");

            WriteLine();

            // c# 7 out variable.
            if (IsItPossibleToCombine(5, 10, out var result))
            {
                WriteLine($"5 + 10 = {result}");
            }

            // c# 7 tuples.
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

            // c# 7 class to tuple conversion.
            var (height, width) = new Shape { Height = 5, Width = 10 };
            WriteLine($"height: {height}, width: {width}");

            WriteLine();

            // c# 7 class to tuple initialization.
            var me = (Name: "Pasha", age: 35);
            WriteLine($"I am {me}");

            WriteLine();

            // c# 7 using tuples in list.
            var list = new[]
            {
                new { Name = "Pasha", age = 35 },
                new { Name = "Vasya", age = 40 },
                new { Name = "Kolya", age = 45 },
            };
            var listOfTuples = list.Select(x => (x.Name, x.age)).Where(x => x.age > 35);
            WriteLine($"list of tupes " + string.Join(", ", listOfTuples));


            WriteLine();

            // c# 7 number with delimiter like 1000_000.
            WriteLine("Number underscore: 123000 is " + 123__000);

            WriteLine();


            // c# 7 default value.
            WriteLine("default of decimal is " + default(decimal));
            DateTime defaultDateTime = default;
            WriteLine("default of decimal is " + defaultDateTime);

            WriteLine();

            // c# 7 pattern matching.
            var animal = new Animal();
            if (animal is Pig pig)
            {
                WriteLine("animal is pig");
            }

            switch (animal)
            {
                case Pig pork:
                    WriteLine("animal is pig");
                    break;
            }

            // c# 7 change parameter order in function.
            // always use naming for unclear variable.
            var shape = new Shape(width: 10, height: 12);
            WriteLine();
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

            public Shape(int height, int width)
            {
                Height = height;
                Width = width;
            }

            public Shape()
            {
            }

            public void Deconstruct(out int height, out int width)
            {
                height = Height;
                width = Width;
            }
        }

        private class Animal {}
        private class Pig : Animal {}
    }
}
