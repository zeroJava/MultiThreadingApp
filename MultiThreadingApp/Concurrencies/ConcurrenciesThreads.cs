using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace MultiThreadingApp.Concurrencies
{
    public class ConcurrenciesThreads
    {
        private IList<BaseCon> _items = new List<BaseCon>();
        private ConcurrentQueue<BaseCon> _concurrentItems = new ConcurrentQueue<BaseCon>();
        private bool _state = true;

        public ConcurrenciesThreads()
        {
            //https://www.safaribooksonline.com/library/view/concurrency-in-c/9781491906675/ch01.html
        }

        public void Execute()
        {
            Thread thread1 = new Thread(CreateNonConcurrentData);
            thread1.Start();
            thread1.Join(30000);
            Thread threadC1 = new Thread(CreateConcurrentData);
            threadC1.Start();
            threadC1.Join(30000);

            Thread thread2 = new Thread(CreateNonConcurrentData);
            thread2.Start();
            Thread threadC2 = new Thread(CreateConcurrentData);
            threadC2.Start();

            Thread thread3 = new Thread(CreateNonConcurrentData);
            thread3.Start();
            Thread threadC3 = new Thread(CreateConcurrentData);
            threadC3.Start();

            Thread thread4 = new Thread(RemoveNonConcurrentData);
            thread4.Start();
            Thread threadC4 = new Thread(RemoveConcurrentData);
            threadC4.Start();

            Thread thread5 = new Thread(RemoveNonConcurrentData);
            thread5.Start();
            Thread threadC5 = new Thread(RemoveConcurrentData);
            threadC5.Start();

            Thread thread6 = new Thread(RemoveNonConcurrentData);
            thread6.Start();            
            Thread threadC6 = new Thread(RemoveConcurrentData);
            threadC6.Start();
        }

        private object _locking = new object();

        private void CreateNonConcurrentData()
        {
            while (_state)
            {
                lock (_locking)
                {
                    _items.Add(new SubOneCon(1000, "Zero", "Type: System_Zero"));
                    System.Console.WriteLine("List added size: " + _items.Count);
                }
                
            }
        }

        private void RemoveNonConcurrentData()
        {
            while (_state)
            {                
                lock (_locking)
                {
                    if (_items.Count > 5)
                    {
                        _items.RemoveAt(0);
                        System.Console.WriteLine("List removed size: " + _items.Count);
                    }
                }
            }
        }

        private void CreateConcurrentData()
        {
            while (_state)
            {
                _concurrentItems.Enqueue(new SubOneCon(2000, "Epion", "Type: System_Epion"));
                System.Console.WriteLine("Queue add size: " + _concurrentItems.Count);
            }
        }

        private void RemoveConcurrentData()
        {
            while (_state)
            {
                if (_concurrentItems.Count > 5)
                {
                    BaseCon item;
                    System.Console.WriteLine(_concurrentItems.TryDequeue(out item) + "Queue remove size: " + _concurrentItems.Count);
                }
            }
        }
    }
}
