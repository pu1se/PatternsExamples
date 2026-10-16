namespace PatternsExamples.Algorithms.MyHash;

// падающий камень
internal class MyHashMap1 : IMainProgram
{
    public void RunCode()
    {
        MyHashMap myHashMap = new();
        myHashMap.Put(1, 1); // The map is now [[1,1]]
        myHashMap.Put(2, 2); // The map is now [[1,1], [2,2]]
        var tmp = myHashMap.Get(1); // return 1, The map is now [[1,1], [2,2]]
        tmp = myHashMap.Get(3); // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
        myHashMap.Put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
        tmp = myHashMap.Get(2); // return 1, The map is now [[1,1], [2,1]]
        myHashMap.Remove(2); // remove the mapping for 2, The map is now [[1,1]]
        tmp = myHashMap.Get(2); // return -1 (i.e., not found), The map is now [[1,1]]
    }
}

file class MyHashMap
{

    int?[] keys = new int?[1_000_001];

    public MyHashMap()
    {

    }

    public void Put(int key, int value)
    {
        keys[key] = value;
    }

    public int Get(int key)
    {
        return keys[key] == null ? -1 : keys[key].Value;
    }

    public void Remove(int key)
    {
        keys[key] = null;
    }
}