var numbers = Enumerable.Range(1,100);

var parallelQuery = numbers.AsParallel().Where(n => n % 2 == 0);
Console.WriteLine(parallelQuery.Count());


