using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadingApp.Basics
{
    class MultiThreadLocks
    {
        private int _number = 0;
        private readonly object _lock = new object();

        public void Execute()
        {
            Thread thread1 = new Thread(LoopOne);
            Thread thread2 = new Thread(LoopTwo);
            thread1.Start();
            thread2.Start();
        }

        public void LoopOne()
        {
            while(_number < 10)
            {
                lock(_lock)
                {
                    System.Console.WriteLine("Inside LoopOne");
                    _number++;

                    /* The lock() keyword is a multithreading blocking mechanism, which locks the share varaible, so only one thread can access it at one at a time.
                     * */
                }
            }
        }

        public void LoopTwo()
        {
            while (_number < 10)
            {
                lock (_lock)
                {
                    System.Console.WriteLine("Inside LoopTwo");
                    _number++;
                }
            }
        }
    }
}
