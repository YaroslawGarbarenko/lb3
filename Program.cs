using System;
using System.Threading;

namespace lb3._4
{
    class Program
    {

        static void Main(string[] args)
        {
            for (int i = 0; i < 6; i++)
            {
                Symbol symbol = new Symbol(i);
            }
            Console.ReadKey();
        }
        class Symbol
        {
            private static Semaphore sem = new Semaphore(3, 3);
            Thread symbolThread;
            int count = 3;


            public Symbol(int i)
            {
                symbolThread = new Thread(Add);
                symbolThread.Name = $"Symbol{i.ToString()}";
                symbolThread.Start();
            }
            public void Add()
            {
                while(count > 0)
                {
                    sem.WaitOne();

                    Console.WriteLine($"{Thread.CurrentThread.Name} White");
                    Console.WriteLine($"{Thread.CurrentThread.Name} LightGreen");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Thread.CurrentThread.Name} DarkGreen");
                    sem.Release();
                    count--;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
