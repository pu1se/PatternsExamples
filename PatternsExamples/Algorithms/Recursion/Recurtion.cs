namespace PatternsExamples.Algorithms.Recursion
{
    internal class Recurtion
    {
        // recursion from bottom to top
        void PrintUp(int[] arr, int i)
        {
            if (i == arr.Length)
                return;

            Console.Write(arr[i] + ", ");//действие

            PrintUp(arr, i + 1);// след, след, след
        }

        // recursion from top to bottom
        void PrintDown(int[] arr, int i)
        {
            if (i == arr.Length)
                return;

            PrintDown(arr, i + 1);// на стек, на стек, на стек

            Console.Write(arr[i] + ", ");//действие
        }
    }
}
