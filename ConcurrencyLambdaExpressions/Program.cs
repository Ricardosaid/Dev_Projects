
var t = Task.Factory.StartNew(async delegate
{
    await Task.Delay(1000);
    return 42;
},CancellationToken.None,TaskCreationOptions.DenyChildAttach,TaskScheduler.Default).Unwrap();
t.Wait();

var t2 = Task.Run(async delegate
{
    await Task.Delay(1000);
    return 42;
});
t2.Wait();


var t3 = await Task.Run(async () =>
{
    await Task.Delay(100);
    return 45;
});

var t4 = await await Task.Factory.StartNew(async delegate
{
    await Task.Delay(100);
    return 90;
});
Console.WriteLine(t4);
// using System.Diagnostics;
//
// var timer = Stopwatch.StartNew();
// var tasks = new List<Task>();
// for (int i = 0; i < 100; i++)
// {
//     int taskId = i;
//     tasks.Add(Task.Run(
//         async () =>
//         {
//         Console.WriteLine($"{taskId}");
//         var client = new HttpClient();
//         var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos/{taskId}");
//         var result = await response.Content.ReadAsStringAsync();
//         Console.WriteLine(result);
//     }
//     ));
// }
//
// Task.WaitAll(tasks.ToArray());
// timer.Stop();
// Console.WriteLine($"Time elapsed: {timer.ElapsedMilliseconds} ms");

//Task.Run
//Task.Factory.StartNew