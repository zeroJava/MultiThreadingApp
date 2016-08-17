using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp.Basics
{
    class MultiThreadSleep
    {
        public void Execute()
        {
            for (int index = 0; index < 5; index++)
            {
                int temp = index;
                Thread thread = new Thread(x => Display(temp));
                thread.Start();
            }
        }

        private void Display(int word)
        {
            System.Console.WriteLine("Here in thread " + word + " before wait. time " + DateTime.Now);
            Thread.Sleep(5000);
            /* Sleep(5000) will pause the thread it resides in for a specific persiod of time.
             * In this case, we are pausing the thread for 5000 milliseconds
             * */
            System.Console.WriteLine("Here in thread " + word + " after wait. time " + DateTime.Now);
        }
    }
}
