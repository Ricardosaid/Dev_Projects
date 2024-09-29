
//
// var result = new NonGenerics();
//
// result.PrintEnumValues<NumbersToThree>();

var container = new Container<string>
{
    ValueContainer = "Hello World",
    Speed = 100,
    Value = "Hello World",
    [0] = 1,
    [1] = 2,
    [2] = 3
};
var value = container.ValueContainer;
var indexOne = container[0];
container.OnSpeedChanged += () => Console.WriteLine("Speed Changed");
container.Speed = 200;
container.ChangeSpeed();


public class Container<T>
{
    public required T ValueContainer; //Field

    // public int Speed
    // {
    //     get => speed;
    //     set => speed = value;
    // }
    public int Speed { get; set; } // Property
    
    public T Value { get; set; } = default!;
    
    private readonly int[] _numbers = new int[10];
    
    public int this[int index]  // Indexer
    {
        get => _numbers[index];
        set => _numbers[index] = value;
    }

    public event Action? OnSpeedChanged; //events
    public void ChangeSpeed()
    {
        OnSpeedChanged?.Invoke();
        
    }

    ~Container() //finalizer
    {
        Console.WriteLine("Container is destroyed");
    }
}


public class NonGenerics
{
    public void PrintEnumValues<T>() where T : Enum
    {
        foreach (var value in Enum.GetValues(typeof(T)))
        {
            Console.WriteLine(value);
        }
    }
}


public enum NumbersToThree
{
    One,
    Two,
    Three
}






