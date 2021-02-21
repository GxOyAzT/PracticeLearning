using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelPractice
{
    public static class DoParallelTask
    {
        static void TaskWait()
        {
            Thread.Sleep(2000);
        }

        public static void DoTenTasks()
        {
            for (int i = 0; i < 10; i++)
            {
                TaskWait();
            }
        }

        public static void DoTenTasksParallel()
        {
            Parallel.For(0, 11, e => 
            {
                TaskWait();
            });
        }
    }
}
