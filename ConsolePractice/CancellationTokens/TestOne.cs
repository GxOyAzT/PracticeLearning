using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePractice.CancellationTokens
{
    public class TestOne
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>();

        public static async Task Execute()
        {
            "Strating Process...".Write();

            CancellationTokenSource cancellationToken = new CancellationTokenSource();

            var task = Task.Run(() =>
            {
                for (int i = 1; i < 100; i++)
                {
                    $"Doing work {i}".Write();
                    Thread.Sleep(1000);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }
                }
            }, cancellationToken.Token);

            $"Press S to stop task.".Write();
            if (ConsoleKey.Enter == Console.ReadKey().Key)
            {
                "Cancel()".Write();
                cancellationToken.Cancel();

                try
                {
                    await task;
                }
                catch(TaskCanceledException tce)
                {
                    $"Operation was canceled {tce.Message}".Write();
                }
            }
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
