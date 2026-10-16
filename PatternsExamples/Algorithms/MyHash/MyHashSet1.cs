namespace PatternsExamples.Algorithms.MyHash;

// падающий камень
internal class MyHashSet1 : IMainProgram
{
    public void RunCode()
    {
        MyHashSet myHashSet = new();
        myHashSet.Add(1);      // set = [1]
        myHashSet.Add(2);      // set = [1, 2]
        myHashSet.Contains(1); // return True
        myHashSet.Contains(3); // return False, (not found)
        myHashSet.Add(2);      // set = [1, 2]
        myHashSet.Contains(2); // return True
        myHashSet.Remove(2);   // set = [1]
        myHashSet.Contains(2); // return False, (already removed)
    }
}

file class MyHashSet
{

    bool[] keys = new bool[1_000_001];

    public MyHashSet()
    {

    }

    public void Add(int key)
    {
        keys[key] = true;
    }

    public void Remove(int key)
    {
        keys[key] = false;
    }

    public bool Contains(int key)
    {
        return keys[key];
    }
}