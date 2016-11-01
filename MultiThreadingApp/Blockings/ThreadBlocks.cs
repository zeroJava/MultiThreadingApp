using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadingApp.Blockings
{
    public class ThreadBlocks
    {
        public int _count = 0;

        /// <summary>
        /// The join method in multithread forces the main thread to pause, until the sub thread invoking has finished executing. 
        /// With join we force the multithread to run one thread a time.
        /// </summary>
        public void ExecuteJoins()
        {
            Thread thread2 = new Thread(x => ThreadFunctionJoin1("Joining 1"));
            thread2.Start();
            thread2.Join(5000);
            /* The join method in multithread forces the main thread to pause, until the sub thread invoking has finished executing.
             * With join we force the multithread to run one thread a time.
             * */
            System.Console.WriteLine("We are joining to 2....");

            /* Different between sleep and join, is that sleep pauses the whole thread and does nothing.
             * Join in the other hand, pauses the main thread i.e the thread it is placed inside, and has the sub thread running.
             * 
             * http://www.journaldev.com/1024/java-thread-join-example 
             * */


            Thread thread3 = new Thread(x => ThreadFunctionJoin1("Joining 2"));
            thread3.Start();
            thread3.Join(5000);
            System.Console.WriteLine("We are joining to 3....");

            Thread thread4 = new Thread(x => ThreadFunctionJoin1("Joining 3"));
            thread4.Start();
            thread4.Join(5000);

            System.Console.WriteLine("Count: " + _count);
            /* Without join, the value of count would either be zero or a low value, but not the expected value of 30.
             * This is because all the threads are running all at the same time, and most likely this line will be invoked before all threads have finished executing.
             * */

            // Thread threadInception = new Thread(ThreadInception); // Demonstrates joins of sub-threads within a sub-thread within a main thread.
            // threadInception.Start();

            Thread thread5 = new Thread(x => IncorrectJoinInception());
            thread5.Start();
            thread5.Join();
        }

        public void ExecuteSleep()
        {
            Thread thread1 = new Thread(x => TSleeping("thread1"));
            Thread thread2 = new Thread(x => TSleeping("thread2"));
            Thread thread3 = new Thread(x => TSleeping2("threadsleep2_1"));
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        private void ThreadFunctionSleep(string word)
        {
            System.Console.WriteLine("Blocking: Sleep: " + word);
            for (int index = 0; index < 10; index++)
            {
                if (index == 5)
                {
                    System.Console.WriteLine("Starting to sleep...");
                    Thread.Sleep(1000);
                    /* Thread.Sleep will pause the current thread it is placed under for specific number of secconds.
                     * */
                }
                System.Console.WriteLine("Starting not sleep..." + _count++);
            }
        }

        private void ThreadFunctionJoin1(string word)
        {
            for (int index = 0; index < 10; index++)
            {
                System.Console.WriteLine("Join1: " + word);
                _count++;
            }
        }

        private void ThreadFunctionJoin2(string word)
        {
            for (int index = 0; index < 10; index++)
            {
                System.Console.WriteLine("Join2: " + word);
                _count++;
            }
        }

        private void ThreadFunctionJoin3(string word)
        {
            for (int index = 0; index < 10; index++)
            {
                System.Console.WriteLine("Join3: " + word);
                _count++;
            }
        }

        private void ThreadInception()
        {
            Thread thread1 = new Thread(x => ThreadFunctionJoin1("inception Joining 1"));
            thread1.Start();
            thread1.Join();

            /* These join will pause the sub-thread which this method is pegged to, and NOT main thread (main method).
             * This is because join looks at the closest parent thread, which in this case is the sub-thread and not the main thread.
             * */

            System.Console.WriteLine("We are joining to 2, thread inception....");

            Thread thread2 = new Thread(x => ThreadFunctionJoin1("inception Joining 2"));
            thread2.Start();
            thread2.Join();
            System.Console.WriteLine("We are joining to 3, thread inception....");

            Thread thread3 = new Thread(x => ThreadFunctionJoin1("inception Joining 3"));
            thread3.Start();
            thread3.Join();

            System.Console.WriteLine("Thread inception ending");
        }

        private void IncorrectJoinInception()
        {
            Thread thread1 = new Thread(x => ThreadFunctionJoin1("IncorrectJoinInception Joining 2"));
            thread1.Start();

            Thread thread2 = new Thread(x => ThreadFunctionJoin1("IncorrectJoinInception Joining 2"));
            thread2.Start();

            Thread thread3 = new Thread(x => ThreadFunctionJoin1("IncorrectJoinInception Joining 3"));
            thread3.Start();

            thread1.Join();
            System.Console.WriteLine("We are joining to 2, IncorrectJoinInception....");
            thread2.Join();
            System.Console.WriteLine("We are joining to 3, IncorrectJoinInception....");
            thread3.Join();

            /* Doing a join like this is useless, because all the threads have already been created and started, and we cannot pause the thread.
             * */
        }

        private void TSleeping(string name)
        {
            System.Console.WriteLine("We are going to sleep now inisde " + name);
            Thread.Sleep(10000);
            System.Console.WriteLine("We are out of sleep, inside " + name);
        }

        private void TSleeping2(string name)
        {
            while (true)
            {
                System.Console.WriteLine("Inside the TSleeping2 " + name);
                Thread.Sleep(1000);
            }
        }
    }
}
