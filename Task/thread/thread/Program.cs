using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace thread
{
    //class th
    //{
    //    public void StartTheActions()
    //    {
    //        //Starting thread 1....
    //        Thread t1 = new Thread(new ThreadStart(action1));
    //        t1.Start();
    //        t1.Join();
    //        Thread t2 = new Thread(new ThreadStart(action2));
    //        t2.Start();
    //        t2.Join();
    //        Thread t3 = new Thread(new ThreadStart(action3));
    //        t3.Start();
    //    }

    //    private void action1()
    //    {
    //        Console.WriteLine("action1 1");
    //        Thread.Sleep(500);
    //        Console.WriteLine("action1 2");

    //    }

    //    private void action2()
    //    {
    //        Console.WriteLine("action2 1");
    //        Thread.Sleep(500);
    //        Console.WriteLine("action2 2");

    //    }
    //    private void action3()
    //    {
    //        Console.WriteLine("action3 1");
    //        Thread.Sleep(500);
    //        Console.WriteLine("action3 2");

    //    }
    //}
    //class th2
    //{
    //    static int[] a = new int[14];
    //    private static int avg = 0;
    //    public static bool isFinish = false;
    //    public static void doArray()
    //    {
    //        int Min = 0;
    //        int Max = 20;
    //        isFinish = false;
    //        Random randNum = new Random();
    //        for (int i = 0; i < a.Length; i++)
    //        {
    //            a[i] = randNum.Next(Min, Max);
    //            Console.WriteLine($"        {a[i]}");
    //        }
    //        isFinish = true;
    //    }

    //    public static void doAvg()
    //    {

    //        for (int i = 0; i < a.Length; i++)
    //        {
    //            avg += a[i];
    //        }
    //        avg /= a.Length;
    //        Console.WriteLine(avg);
    //    }
    //}
    //class Program
    //{
    //static void Main(string[] args)
    //{
    //    //th t = new th();
    //    //t.StartTheActions();
    //    Console.WriteLine("main end");
    //    Console.ReadLine();
    //}


    //static void Main(string[] args)
    //{
    //    Thread t1 = new Thread(th2.doArray);
    //    Thread t2 = new Thread(th2.doAvg);
    //    t1.Start();
    //    while (th2.isFinish == false)
    //    {
    //    }
    //    t2.Start();
    //    Console.WriteLine("main end");
    //    Console.ReadLine();
    //}
    //static void Main(string[] args)
    //{
    //    Thread t1 = new Thread(th2.doArray);
    //    Thread t2 = new Thread(th2.doAvg);

    //        t1.Start();

    //        t2.Start();




    //    Console.WriteLine("main end");
    //    Console.ReadLine();
    //}
    class Program
    {
        static Semaphore semaphoreObject = new Semaphore(2,2,"MyRes");
        static List<string> StrList = new List<string>();

        static void Func1()
        {
            semaphoreObject.WaitOne();
            for (int i = 0; i <3; i++)
            {
                Thread.Sleep(1000);
                StrList.Add($"{Thread.CurrentThread.Name}: { i}");
                
            }
            semaphoreObject.Release();
        }

        static void Func3()
        {
            semaphoreObject.WaitOne();
            StrList.ForEach(n => { Console.WriteLine(n); });
            Console.WriteLine("func3 end");
            semaphoreObject.Release();
        }

        static void Main(string[] args)
        {

            Thread t1 = new Thread(Func1) { Name="t1"};
            Thread t2 = new Thread(Func1) { Name="t2"};
            Thread t3 = new Thread(Func3);
            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadLine();
        }
    }

    // }
}
