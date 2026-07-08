using ConsoleExample.Templates.Behavioral.MementoWithUndoAndRedo;
using System;
using System.Threading.Tasks;


namespace ConsoleExample
{
    public class A
    {
        public virtual void Print1()
        {
            Console.Write("A");
        }
        public void Print2()
        {
            Console.Write("A");
        }
    }
    public class B : A
    {
        public override void Print1()
        {
            Console.Write("B");
        }
    }
    public class C : B
    {
        new public void Print2()
        {
            Console.Write("C");
        }
    }

    class Program
    {
        class MyCustomException : DivideByZeroException
        {

        }

        static void MyMethod(int required, string optional = "default")
        {
            Console.WriteLine($"{required}, {optional}");
        }


        static void Main(string[] args)
        {
            MementoWithUndoAndRedoMainProgram.RunCode();
        }

        private static void Calc()
        {
            int result = 0;
            var x = 5;
            int y = 0;
            try
            {
                result = x / y;
            }
            catch (MyCustomException e)
            {
                Console.WriteLine("Catch DivideByZeroException");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Catch Exception");
            }
            finally
            {
                throw new MyCustomException();
            }
        }

        private static void DoAsync(string text)
        {
            var symbolsCount = CalcSymbolsAsync(text).Result;
            Console.WriteLine($"Count of symbols: {symbolsCount}");
        }

        static Task<long> CalcSymbolsAsync(string text)
        {
            return Task.Factory.StartNew<long>(() => text.Length);
        }
    }



    public struct S : IDisposable
    {
        private bool dispose;
        public void Dispose()
        {
            dispose = true;
        }
        public bool GetDispose()
        {
            return dispose;
        }
    }


    class Pointer : IDisposable
    {
        public int x, y;
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        ~Pointer()
        {
            Console.WriteLine("finilize");
        }
    }
}