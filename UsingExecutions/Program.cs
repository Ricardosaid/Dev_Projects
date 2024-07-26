
using var operation = new Operation().Dispose();
Console.WriteLine($"{operation.IsCompletedSuccessfully}");
using var disposalExecution = new DisposalExecution();


internal class Operation : IOperation
{
    public Task Dispose()
    {
        Console.WriteLine("Operation disposed executed");
        return Task.CompletedTask;
    }

    public Task Execute()
    {
        Console.WriteLine("Operation execute executed");
        return Task.CompletedTask;
    }
}

public class DisposalExecution : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Disposal executed");
    }
}

public interface IOperation
{
    Task Dispose();
    Task Execute();
}