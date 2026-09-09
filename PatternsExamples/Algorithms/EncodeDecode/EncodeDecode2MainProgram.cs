using System.Text;
using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.EncodeDecode;

//main idea: склеиваем строки через редкий разделитель, при декоде режем по нему
// code quality 4
//hint: ломается, если сама строка содержит разделитель — надёжнее префикс длины перед каждой строкой
// time  O(n)
// mem O(n)
internal class EncodeDecode2MainProgram : IMainProgram
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
    const string _delimiter = "`|`";

    public string Encode(IList<string> strs)
    {
        var encodedString = new StringBuilder();

        for (var i = 0; i < strs.Count; i++)
        {
            encodedString.Append(strs[i]);
            encodedString.Append(_delimiter);
        }

        return encodedString.ToString();
    }

    public List<string> Decode(string encodedSt)
    {
        var decodedStringArray = encodedSt.Split(_delimiter).ToList();
        decodedStringArray.RemoveAt(decodedStringArray.Count - 1);
        return decodedStringArray;
    }
}