using System.Collections;

// ArrayList is a non-generic collection
var names = GenerateNames();
PrintNames(names);
static ArrayList GenerateNames()
{
    ArrayList names = new ArrayList();
    names.Add("Ricardo");
    names.Add("Mauricio");
    names.Add("Daniel");
    names.Add(new Exception());
    return names;
}

static void PrintNames(ArrayList names)
{
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
    
}


// Generic class
List<string> list = new List<string>();
list.Add("Ricardo");
list.Brand = "Apple";
list.Name = "iPhone";
if (list.Name.Length > 0)
{
    Console.WriteLine("Name is not empty");
}

Console.WriteLine(list);

internal class List<T>
{
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public void Add(T item)
    {
        Console.WriteLine("Adding item");
        Console.WriteLine(item);
    }
}