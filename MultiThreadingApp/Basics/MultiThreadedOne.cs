using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp.Basics
{
    class MultiThreadedOne
    {
        private bool _state = false;

        public void Execute()
        {
            Thread thread1 = new Thread(ThreadOne); // The ThreadStart parameter inside the Thread constructor is a delegate
            Thread thread2 = new Thread(ThreadTwo);
            thread1.Start();
            thread2.Start();
            /* The Start() method is used to start a task (thread).
             * */

            Thread thread3 = new Thread(ThreadShare);
            Thread thread4 = new Thread(ThreadShare);
            thread3.Start();
            thread4.Start();
        }

        private void ThreadOne()
        {
            for (int index = 0; index < 5; index++)
            {
                System.Console.WriteLine("Running ThreadOne");
                /* For each thread, a new cycle is made and the delegate (method/task) have their own memory stack to hold their local variables. 
                 * */
            }
        }

        private void ThreadTwo()
        {
            for (int index = 0; index < 5; index++)
            {
                System.Console.WriteLine("Running ThreadTwo");
            }
        }

        private void ThreadShare()
        {
            if(!_state)
            {
                System.Console.WriteLine("The state is false");
                _state = true;
                /* Putting the '_state = true' after the WriteLine() can cause problems, as this is not thread safe, and there is chance that it will print the text twice.
                 * The problem is caused, because as so as the WriteLine() has finished executing, the second thread has already started executing, and thus we will
                 * see the text in the WriteLine() twice, as oppose to once.
                 * 
                 * Putting the '_state = true' before the WriteLine() will show the text once.
                 * */
            }
        }
    }
}
