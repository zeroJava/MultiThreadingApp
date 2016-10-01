using MultiThreadingApp.FileIOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadingApp.Lockings
{
    public class ThreadReadWriteLock
    {
        private int _number = 0;
        private ReaderWriterLockSlim _readWriterLock;
        
        public ThreadReadWriteLock()
        {
            _readWriterLock = new ReaderWriterLockSlim();
        }

        public void Execute()
        {
            // ThreadPool.QueueUserWorkItem(x => ThreadFunction("Thead 1"));
            // ThreadPool.QueueUserWorkItem(x => ThreadFunction("Thead 2"));
            // ThreadPool.QueueUserWorkItem(x => ThreadFunction("Thead 3"));
            // ThreadPool.QueueUserWorkItem(x => ThreadFunction("Thead 4"));
            // ThreadPool.QueueUserWorkItem(x => ThreadFunction("Thead 5"));
            // ThreadPool.QueueUserWorkItem(x => ThreadFunction("Thead 6"));

            ThreadPool.QueueUserWorkItem(x => DisplayTableSize("Thead 1"));
            ThreadPool.QueueUserWorkItem(x => DisplayTableSize("Thead 2"));
            ThreadPool.QueueUserWorkItem(x => DisplayTableSize("Thead 3"));
            ThreadPool.QueueUserWorkItem(x => DisplayTableSize("Thead 4"));
            ThreadPool.QueueUserWorkItem(x => DisplayTableSize("Thead 5"));
            ThreadPool.QueueUserWorkItem(x => DisplayTableSize("Thead 6"));
        }

        private void ThreadFunction(string threadName)
        {
            if (_number >= 5 )
            {
                for (int index = _number; index > 1; index--)
                {
                    System.Console.WriteLine("Decreementing " + threadName);
                    _readWriterLock.EnterWriteLock();
                    _number--;
                    _readWriterLock.ExitWriteLock();

                    /* ReaderWriterLockSlim is another locking feature in c#/.net.
                     * Like the lock() feature, ReaderWriterLock also locks the resource that is used by another thread. 
                     * But unlike lock(), which only allows one thread to access the share rource one at a time, ReaderWriterLock allows multiple thread to read
                     * at the same time, but does an exclusive lock when writing. 
                     * */
                }
            }
            else
            {
                for (int index = 0; index < 5; index++)
                {
                    System.Console.WriteLine("Increementing " + threadName);
                    _readWriterLock.EnterWriteLock();
                    _number++;
                    _readWriterLock.ExitWriteLock();
                }
            }
        }

        private void DisplayTableSize(string name)
        {
            using (ServiceDBContext context = new ServiceDBContext())
            {
                PersistData persisting = new PersistData();
                while (true)
                {
                    _readWriterLock.EnterReadLock();
                    List<BasicServiceTable> list = context.BasicServiceTables.ToList();
                    System.Console.WriteLine(name + " " + list.Count);
                    _readWriterLock.ExitReadLock();

                    _readWriterLock.EnterWriteLock();
                    persisting.Save(list);
                    _readWriterLock.ExitWriteLock();
                }
            }
        }

        private void CreateDynamicClass()
        {
            // http://www.c-sharpcorner.com/article/dynamic-class-using-c-sharp/
            // http://stackoverflow.com/questions/16973172/waiting-queue-vs-ready-queue
        }
    }
}
