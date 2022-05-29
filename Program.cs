using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4OS
{
    class Program
    {
        static object locker = new object();
        static int i1 = 0;
        static int i2 = 0;

        static void WithoutLocker()
        {
            Task first = Task.Run(() => IncWithoutLocker());
            Task second = Task.Run(() => IncWithoutLocker());
            Task.WaitAll(first, second);
            Console.WriteLine($"Result without locker, i = {i1}");

            /*Thread first = new Thread(IncrementWithoutLocker);
            first.Start();
            Thread second = new Thread(IncrementWithoutLocker);
            second.Start();*/
        }

        static void IncWithoutLocker()
        {
            for (int j = 0; j < 2000; j++)
            {
                i1++;
            }
        }

        static void WithtLocker()
        {
            /*Thread first = new Thread(IncWithLocker);
            first.Name = "First";
            first.Start();
            Thread second = new Thread(IncWithLocker);
            second.Name = "Second";
            second.Start();*/

            Task first = Task.Run(() => IncWithLocker());
            Task second = Task.Run(() => IncWithLocker());
            Task.WaitAll(first, second);
            Console.WriteLine($"Result with locker, i = {i2}");
        }

        static void IncWithLocker()
        {
            lock (locker)
            {
                for (int j = 0; j < 2000; ++j)
                {
                    ++i2;
                }
            }
        }

        static void Main(string[] args)
        {
            WithoutLocker();
            WithtLocker();
        }
    }
}
