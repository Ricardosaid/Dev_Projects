

namespace UsingHashSet;

class Union
{
    public void SetOperationUnion()
    {
        HashSet<int> setUnion = new HashSet<int>();

        for (int i = 0; i < 10; i++)
        {
            setUnion.Add(i);
        }
        
        HashSet<int> setUnion2 = new HashSet<int>();
        
        for (int i = 5; i < 15; i++)
        {
            setUnion2.Add(i);
        }
        
        setUnion.UnionWith(setUnion2);
        
        foreach (int i in setUnion)
        {
            Console.WriteLine(i);
        }
    }
}

class Program
{
    static void Main()
    {
        Union union = new Union();
        union.SetOperationUnion();
    }
}