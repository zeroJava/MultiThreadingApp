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

        public void Execute()
        {
            //Thread thread1 = new Thread(x => ThreadFunctionSleep("Sleeping"));
            //thread1.Start();

            Thread thread2 = new Thread(x => ThreadFunctionJoin1("Joining 1"));
            thread2.Start();
            thread2.Join(5000);
            /* The join method in multithread force the main thread to pause, until the sub thread has finished executing.
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
            /* The value of count would either be zero or a low value, but not the expected value of 30.
             * This is because
             * */
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
    }
}
