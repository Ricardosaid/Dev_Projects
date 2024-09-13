// //Generic methods
//
// static List<T> CopyAtMost<T>(List<T> input, int maxElements)
// {
//     var actualCount = Math.Min(input.Count, maxElements);
//     var ret = new List<T>();
//     for (var i = 0; i < actualCount; i++)
//     {
//         ret.Add(input[i]);
//     }
//     return ret;
// }
//
// Initializer();
// return;
//
// static void Initializer()
// {
//     List<int> numbers =
//     [
//         1,
//         2,
//         3
//
//     ];
//
//     var firstTwo = CopyAtMost(numbers, 2);
//     Console.WriteLine(firstTwo.Count); 
// }


List<int> values = new List<int>
{
    1, 2, 3, 4, 5, 6
};

var newList = CopyAtMost(values, 3);
Console.WriteLine(newList.Count);

static List<T> CopyAtMost<T>(List<T> input, int maxElements)
{
    var actualCount = Math.Min(input.Count, maxElements);
    var ret = new List<T>();
    for (var i = 0;  i < maxElements; i++)
    {
        ret.Add(input[i]);
    }

    return ret;
}