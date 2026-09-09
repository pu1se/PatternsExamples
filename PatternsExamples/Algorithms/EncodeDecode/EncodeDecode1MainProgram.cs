using System.Text;
using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.EncodeDecode;

//main idea: каждый символ пишем как число со сдвигом +10 через пробел, конец строки помечаем -1
// code quality 5
//hint: работает на любых входных строках, но результат раздувается в разы — на каждый символ число плюс пробел
// time  O(n)
// mem O(n)
internal class EncodeDecode1MainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();

        var encodedString = solution.Encode(["neet", "code", "love", "you"]);
        var decodedStringArray = solution.Decode(encodedString);

        Console.WriteLine(decodedStringArray.Join(", "));
    }
}

file class Solution
{
    const int _encodingShift = 10;

    public string Encode(IList<string> strs)
    {
        var encodedString = new StringBuilder();

        foreach (var st in strs)
        {
            foreach (var ch in st)
            {
                encodedString.Append(ch + _encodingShift);
                encodedString.Append(' ');
            }

            encodedString.Append("-1");
            encodedString.Append(" ");
        }

        return encodedString.ToString();
    }

    public List<string> Decode(string s)
    {
        var decodedStringArray = new List<string>();
        var currentString = new StringBuilder();

        foreach (var chAsString in s.Split(' ').Where(x => string.IsNullOrEmpty(x) == false))
        {
            var value = int.Parse(chAsString);

            if (value == -1)
            {
                decodedStringArray.Add(currentString.ToString());
                currentString.Clear();
                continue;
            }

            value -= _encodingShift;
            currentString.Append((char)value);
        }

        return decodedStringArray;
    }
}