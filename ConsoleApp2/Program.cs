using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Task delayTask = WaitAndPrintAsync();
        Task helloTask = SayHelloAsync();

        await Task.WhenAll(delayTask,helloTask);

        Console.WriteLine("Goodbye");
    }

    static async Task SayHelloAsync()
    {
        await Task.Delay(100); // Add a small delay before printing "Hello"
        Console.WriteLine("Hello");
        await Task.Delay(1000);
        Console.WriteLine("after");
    }

    static async Task WaitAndPrintAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Delayed task completed");
    }
}
