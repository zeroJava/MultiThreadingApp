using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadingApp.Lockings
{
    public class ThreadLocks
    {
        private int _sharedResource = 0;
        private int _sharedLockedResource = 0;
        private readonly object _lock = new object();

        public void Execute()
        {
            Thread thread1 = new Thread(ThreadFunction1);
            Thread thread2 = new Thread(ThreadFunction1);
            Thread thread3 = new Thread(ThreadFunction1);
            thread1.Start();
            thread2.Start();
            thread3.Start();

            Thread thread4 = new Thread(ThreadLockedFunction1);
            Thread thread5 = new Thread(ThreadLockedFunction1);
            Thread thread6 = new Thread(ThreadLockedFunction1);
            thread4.Start();
            thread5.Start();
            thread6.Start();
        }

        private void ThreadFunction1()
        {
            for (int index = 0; index < 10; index++)
            {
                if (_sharedResource == 5)
                {
                    System.Console.WriteLine("This should only print once");

                    /* In this thread without a lock, the WriteLine statement is mostly going to be executes more that once, even though it shoudl only execute once.
                     * This could be becuase all or some of the thread accessed the if statement just around the same time before it could increement the 
                     * _shareResource variable.
                     * 
                     * We need to force the applicaation to access the shared resource one at a time, we need to use blocking 
                     * */
                }

                _sharedResource++;
            }
        }

        private void ThreadLockedFunction1()
        {
            for (int index = 0; index < 10; index++)
            {
                lock (_lock)
                {
                    if (_sharedLockedResource == 5)
                    {
                        System.Console.WriteLine("shared locked resource");
                    }

                    /* The lock feature will lock all shared resource used within the lock block.
                     * This will mean that the any other threads wanting to access the shared resource will have to wait
                     * until the thread using the shared resource has finished using it. 
                     * */

                    _sharedLockedResource++;

                    /* Here we also demonstrate Atomicity; meaning that the _sharedLockedResource variable is read and written inside 
                     * the same lock block, thus the integrity of the share resource is sound in this instance, because there is 
                     * no outside factors that can change the value.  
                     * */
                }
            }
        }
    }
}
