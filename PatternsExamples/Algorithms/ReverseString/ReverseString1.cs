namespace PatternsExamples.Algorithms.ReverseString;

internal class ReverseString1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();

        var st = "cat";
        var s = st.ToArray();
        solution.ReverseString(s);

        Console.WriteLine(s);
    }
}
file class Solution
{
    public void ReverseString(char[] s)
    {
        if (s == null)
            return;

        var left_i = 0;
        var right_i = s.Length - 1;

        while (left_i < right_i)
        {
            (s[left_i], s[right_i]) = (s[right_i], s[left_i]);
            left_i++;
            right_i--;
        }
    }
}