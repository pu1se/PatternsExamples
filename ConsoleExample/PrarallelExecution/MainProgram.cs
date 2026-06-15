using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExample.PrarallelExecution
{
    public static class MainProgram
    {
        public static void Write(object st)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(st);
            }
        }

        public static int GetLength(object st)
        {
            Console.WriteLine($"Task id {Task.CurrentId} processing {st}");
            return st.ToString().Length;
        }

        

        public static void RunCode()
        {
            
            var arr = new string[] { "1" };

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            
            var task1 = Task.Factory.StartNew(() =>
            {
                int i = 10;

                while (i > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Bomb is disarmed");
                        return;
                    }
                    Console.WriteLine(i--);
                    Task.Delay(TimeSpan.FromSeconds(1), token).Wait(token);
                }

                Console.WriteLine("BOOM!");
            }, token);


            Console.ReadKey();
            tokenSource.Cancel();

            Task.WaitAll(task1);
            Console.WriteLine("Main program is done.");
            Console.ReadKey();
        }
    }
}
