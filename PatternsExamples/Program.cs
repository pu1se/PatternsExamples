using PatternsExamples.Algorithms.SortColors;

var mainProgram = new SortColors1MainProgram();
mainProgram.RunCode();

//int[] arr = [10, 9, 1, 2, 4, 3, 1];
//PrintDown(arr, 0);






void PrintUp(int[] arr, int i)
{
    if (i == arr.Length)
        return;

    Console.Write(arr[i] + ", ");//действие

    PrintUp(arr, i + 1);// след, след, след
}

void PrintDown(int[] arr, int i)
{
    if (i == arr.Length)
        return;

    PrintDown(arr, i + 1);// на стек, на стек, на стек

    Console.Write(arr[i] + ", ");//действие
}

