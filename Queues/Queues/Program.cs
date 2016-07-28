using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitedQueue<int> q = new LimitedQueue<int>(10);

            q.Dequeue();

            for (int i = 0; i < 10; i ++)
            {
                ThreadPool.QueueUserWorkItem(_ => { q.Enqueue(new Random().Next(1, 100)); });
                ThreadPool.QueueUserWorkItem(_ => { q.Enqueue(new Random().Next(101, 200)); });
            }

       //     bool triedEnqueuing = q.Enqueue(10);

        //    Console.WriteLine($"was enqueuing past q max capacity succesful: {triedEnqueuing}");

            q.Dequeue();
            q.Dequeue();
            q.Dequeue();

            for(int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    ThreadPool.QueueUserWorkItem(_ => { q.Enqueue(new Random().Next(300, 310)); });
                } else
                {
                    q.Dequeue();
                }
            }

        }
    }
}
