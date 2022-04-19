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

            var (height, width) = new Shape { Height = 5, Width = 10 };
            WriteLine($"height: {height}, width: {width}");
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

            public void Deconstruct(out int height, out int width)
            {
                height = Height;
                width = Width;
            }
        }
    }
}
