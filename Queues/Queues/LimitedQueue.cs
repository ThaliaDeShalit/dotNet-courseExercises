using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Queues
{
    class LimitedQueue<T>
    {
        private Queue<T> _queue;
        private int _maxCapacity;
        SemaphoreSlim _semaphore;

        public int MaxCapacity
        {
            get
            {
                return _maxCapacity;
            }
        }

        public LimitedQueue(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
            _queue = new Queue<T>();
            _semaphore = new SemaphoreSlim(MaxCapacity, MaxCapacity);
        }

        public void Enqueue(T item)
        {
            _semaphore.Wait();

            _queue.Enqueue(item);
        }

        public T Dequeue()
        {
            T toReturn = default(T);

            try
            {
                toReturn = _queue.Dequeue();

                _semaphore.Release(1);
            }
            catch (Exception e)
            {

            }

            return toReturn;
        }
    }
}
