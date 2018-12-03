using System;
using System.Collections.Generic;
using System.Threading;

namespace _02_Threads
{
    class Program
    {
       static Semaphore semaphoreObject = new Semaphore(initialCount: 0, maximumCount: 5, name: "MyUniqueNameApp");
        static List<int> NumList = new List<int>();

        static void Func1()
        {
            semaphoreObject.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                NumList.Add(i);

            }
         
        }

        static void Func2()
        {
            semaphoreObject.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                NumList.Add(i);

            }
      
        }
        static void Func3()
        {
            semaphoreObject.Release();
            NumList.ForEach(n => { Console.WriteLine(n); });
           
        }
      
    }
}
