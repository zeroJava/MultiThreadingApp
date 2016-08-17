using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadingApp.ThreadPools
{
    public class ThreadPoolExample
    {
        public void Execute()
        {
            NormalWayOfMultiThreading();
            ThreadingPoolMultiThreading();
        }

        private void NormalWayOfMultiThreading()
        {
            Thread thread1 = new Thread(x => Displaying("Non thread-pool way 1"));
            Thread thread2 = new Thread(x => Displaying("Non thread-pool way 2"));
            Thread thread3 = new Thread(x => Displaying("Non thread-pool way 3"));
            thread1.Start();
            thread2.Start();
            thread3.Start();

            /* Doing it the non thread-pooling way, we would have to make create a thread and then start the thread.
             * This is time consuming, But having thread already made would cut that problem.
             * */
        }

        private void ThreadingPoolMultiThreading()
        {
            ThreadPool.QueueUserWorkItem(x => Displaying("Threading pool execution 1"));
            ThreadPool.QueueUserWorkItem(x => Displaying("Threading pool execution 2"));
            ThreadPool.QueueUserWorkItem(x => Displaying("Threading pool execution 3"));

            /* As you have see above, the Threadpool has thrads already created, and waiting for us to add it to the queue, which will then automatically 
             * execute when we add it to the queue.
             * 
             * Threadpool save us processing, because it doesn't have to create another thread.
             * */
        }

        private void Displaying(string word)
        {
            System.Console.WriteLine("Hello using thread: " + word);
        }
    }
}
