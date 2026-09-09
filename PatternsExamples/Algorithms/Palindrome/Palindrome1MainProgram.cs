using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.Palindrome;

// code quality 5 — HashSet пересоздаётся на каждый вызов, ToString().ToLower() на каждый символ
// time  O(n)
// mem O(1)
internal class Palindrome1MainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();

        var isPalindrome = solution.IsPalindrome("A man, a plan, a canal: Panama");

        Console.WriteLine(isPalindrome);
    }
}

file class Solution
{
    HashSet<char> _characters = new HashSet<char>();

    public bool IsPalindrome(string s)
    {
        _characters = GetCharactersHashSet();

        var leftIndex = 0;
        var rightIndex = s.Length - 1;
        char? leftCharacter, rightCharacter;

        while (leftIndex < rightIndex)
        {
            leftCharacter = GetNextLeftCharacter(s, ref leftIndex, rightIndex);
            rightCharacter = GetNextRightCharacter(s, ref rightIndex, leftIndex);

            if (leftCharacter == null || rightCharacter == null)
                break;

            if (leftCharacter.Value.ToString().ToLower() != rightCharacter.Value.ToString().ToLower())
                return false;
        }

        return true;
    }

    char? GetNextLeftCharacter(string s, ref int leftIndex, int midelIndex)
    {
        char symbol;

        while (leftIndex <= midelIndex)
        {
            symbol = s[leftIndex++];

            if (IsCharacter(symbol))
                return symbol;
        }

        return null;
    }

    char? GetNextRightCharacter(string s, ref int rightIndex, int midelIndex)
    {
        char symbol;

        while (midelIndex <= rightIndex)
        {
            symbol = s[rightIndex--];

            if (IsCharacter(symbol))
                return symbol;
        }

        return null;
    }

    HashSet<char> GetCharactersHashSet()
    {
        var hashSet = new HashSet<char>();

        foreach (char ch in Enumerable.Range('A', 26))
            hashSet.Add(ch);

        foreach (char ch in Enumerable.Range('a', 26))
            hashSet.Add(ch);

        foreach (char ch in Enumerable.Range('0', 10))
            hashSet.Add(ch);

        return hashSet;
    }

    bool IsCharacter(char ch)
    {
        return _characters.Contains(ch);
    }
}