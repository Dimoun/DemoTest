using Nito.AsyncEx;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class Program
{
    private static readonly AsyncManualResetEvent _event = new AsyncManualResetEvent();

    public static EventHandler SomeEvent { get; private set; }

    public static async Task Main(string[] args)
    {
        TestTaskCompletionSource();
    }

    public async Task TestAsyncManualResetEvent()
    {
        var waitingTask = WaitForEventAsync();

        // 模拟某些操作
        await Task.Delay(2000);

        Console.WriteLine("Signaling event...");
        _event.Set();

        await waitingTask;
        Console.WriteLine("Event signaled and task completed.");
    }


    private static async Task WaitForEventAsync()
    {
        Console.WriteLine("Waiting for event...");
        await _event.WaitAsync();
        Console.WriteLine("Event signaled.");
    }
    private static void TestTaskCompletionSource()
    {
        TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();
        Task<int> t1 = tcs1.Task;

        // Start a background task that will complete tcs1.Task
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            tcs1.SetResult(15);
        });

        // The attempt to get the result of t1 blocks the current thread until the completion source gets signaled.
        // It should be a wait of ~1000 ms.
        Stopwatch sw = Stopwatch.StartNew();
        int result = t1.Result;
        sw.Stop();

        Console.WriteLine("(ElapsedTime={0}): t1.Result={1} (expected 15) ", sw.ElapsedMilliseconds, result);

        // ------------------------------------------------------------------

        // Alternatively, an exception can be manually set on a TaskCompletionSource.Task
        TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>();
        Task<int> t2 = tcs2.Task;

        // Start a background Task that will complete tcs2.Task with an exception
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            tcs2.SetException(new InvalidOperationException("SIMULATED EXCEPTION"));
        });

        // The attempt to get the result of t2 blocks the current thread until the completion source gets signaled with either a result or an exception.
        // In either case it should be a wait of ~1000 ms.
        sw = Stopwatch.StartNew();
        try
        {
            result = t2.Result;

            Console.WriteLine("t2.Result succeeded. THIS WAS NOT EXPECTED.");
        }
        catch (AggregateException e)
        {
            Console.Write("(ElapsedTime={0}): ", sw.ElapsedMilliseconds);
            Console.WriteLine("The following exceptions have been thrown by t2.Result: (THIS WAS EXPECTED)");
            for (int j = 0; j < e.InnerExceptions.Count; j++)
            {
                Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
            }
        }
    }


}
