Func<int, Func<int, int>, int> fnHigherOrder = (number, fn) =>
{
    if (number > 100)
    {
        return fn(number);
    }

    return number;
};
var result = fnHigherOrder(200, number => number * 2);
Console.WriteLine(result);

return;
int Summary(int numerator, int denominator) => numerator > denominator ? numerator : denominator;
decimal Suma(int a, int b) => a + b;