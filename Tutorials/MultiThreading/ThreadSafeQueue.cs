using System;
using System.Threading;
using System.Collections.Generic;

class ThreadSafeQueueExample
{
    public static void Main()
    {
        // TBD

    }
}

class ThreadSafeQueue<T>
{
    public ThreadSafeQueue(int size) => (this._size, this._queue) = (size, new Queue<T>(size));
    private int _size;
    private Queue<int> _queue;
    private static readonly object _queueLockObject = new object();


    public void Enqueue(T val)
    {
        try
        {
            Monitor.Enter(_queueLockObject);

            while (_queue.Count == this._size)
            {
                // always wait in a loop - see spurious wake ups
                Monitor.Wait(_queueLockObject);
            }



        }
        finally
        {
            Monitor.Exit(_queueLockObject);
        }
    }

    public void Dequeue()
    {

    }
}