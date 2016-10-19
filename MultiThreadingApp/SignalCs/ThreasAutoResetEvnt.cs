using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadingApp.SignalCs
{
    public class ThreasAutoResetEvnt
    {
        public AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        private AutoResetEvent _areTest1 = new AutoResetEvent(false);
        private AutoResetEvent _areTest2 = new AutoResetEvent(false);

        private ReaderWriterLockSlim _rwsLock = new ReaderWriterLockSlim();
        private System.Timers.Timer _timer = new System.Timers.Timer(5000);
        private string _message = "Default";
        private int _number = 0;

        /* Signal constructs is similar to normal blocking mechanism like sleep and join,
         * in thatis blocks a thread, but with the ability to manually unblock the thread 
         * any time we like.
         * 
         * With Sleep(1000) and Join(1000), we would have to wait for the blocking mechniasm to
         * reach the threshold for it to resume executing the thread.
         * 
         * With signal construct we can unblock the thread when ever we like, by executing the 
         * Set() method, which would force any thread blocked using the WaitOne(10000) method
         * to resume executing.
         * */

        /* Difference between AutoResetEvent and ManaulResetEvent
         * 
         * Difference between AutoResetEvent and ManaulResetEvent is that the WaitOne() in 
         * ManualResetEvent WaitOne() function will not pause the thread when used a after the Set() 
         * function; where as AutoresetEvent WaitOne() will always pause the thread, even
         * after the Set() function.
         * This is because, once the manaualResetEvent Set() function opens the gates (analogy)
         * it does not close itself automatically, so the next time WaitOne() is called, it's 
         * trying stop process going through the door, but the door isn't closed and the
         * process are going through anyway.
         * Inorder to close the "gate" and have the WaitOne() function functioning again, we 
         * have to use the Reset() function after the Set(), which resets "gate" back to
         * close.
         * AutoResetEvent Set() has the Reset() function built-in, so it automatically closes the gates,
         * and the WaitOne() function will always pause
         * */

        public void Execute()
        {
            ThreadPool.QueueUserWorkItem(x => DisplayOne("Thread 1"));
            ThreadPool.QueueUserWorkItem(x => DisplayOne("Thread 2"));
            ThreadPool.QueueUserWorkItem(x => DisplayOne("Thread 3"));
            ThreadPool.QueueUserWorkItem(x => DisplayOne("Thread 4"));
            ThreadPool.QueueUserWorkItem(x => DisplayOne("Thread 5"));
            ThreadPool.QueueUserWorkItem(x => FunctionTwo("Function 1"));
            ThreadPool.QueueUserWorkItem(x => FunctionTwo("Function 2"));
        }

        private void DisplayOne(string name)
        {
            while (true)
            {
                System.Console.WriteLine(name + " Wait.");
                _autoResetEvent.WaitOne(5000);
                /* Using the WaitOne(5000) function we can block a particular thread
                 * 
                 * If the Set() is called before a wait, does nothing a waits for the object to call the 
                 * Wait() function.
                 * */

                _rwsLock.EnterWriteLock();
                _number++;
                _rwsLock.ExitWriteLock();
            }
        }

        private void FunctionTwo(string name)
        {
            while (true)
            {
                if (_number >= 5)
                {
                    System.Console.WriteLine(name + " Release.");
                    _autoResetEvent.Set();
                    /* Using the Set() function, we can unblock the thread that has blocked the by WaitOne() function.
                     * 
                     * We could use the Set() function as much as we want in AutoRestEvent, because 
                     * */

                    _rwsLock.EnterWriteLock();
                    _number = 0;
                    _rwsLock.ExitWriteLock();
                }
            }
        }

        public void ExecuteTwo()
        {
            Thread thread1 = new Thread(FunctionTestThree);
            thread1.Start();

            _timer.Elapsed += FunctionTestFour;
            _timer.Start();

            _areTest1.WaitOne();
            _rwsLock.EnterWriteLock();
            _message = "Hello";
            _rwsLock.ExitWriteLock();
            _areTest2.Set();

            _areTest1.WaitOne();
            _rwsLock.EnterWriteLock();
            _message = "World";
            _rwsLock.ExitWriteLock();
            _areTest2.Set();

            _areTest1.WaitOne();
            _rwsLock.EnterWriteLock();
            _message = "Hello Everybody";
            _rwsLock.ExitWriteLock();
            _areTest2.Set();
        }

        private void FunctionTestThree()
        {
            while (true)
            {
                _areTest1.Set();
                _areTest2.WaitOne();

                _rwsLock.EnterReadLock();
                System.Console.WriteLine("Fuction 3 being use. " + _message);
                _rwsLock.ExitReadLock();
            }
        }

        private void FunctionTestFour(object sender, System.Timers.ElapsedEventArgs receiver)
        {
            System.Console.WriteLine("Elaspsed");

            _areTest1.Set();
            _areTest2.Set();

            _rwsLock.EnterWriteLock();
            _timer.Stop();
            _timer.Start();
            _rwsLock.ExitWriteLock();
        }
    }
}
