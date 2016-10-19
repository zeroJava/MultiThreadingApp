using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp.MultiThrStream
{
    public class MainClInt
    {
        private Thread _thread1;
        private Thread _thread2;
        private Thread _thread3;

        public MainClInt()
        {
            _thread1 = new Thread(ThreadOne);
            _thread2 = new Thread(ThreadTwo);
            _thread3 = new Thread(ThreadThree);
        }

        public void Exeute()
        {
            _thread1.Start();
            _thread2.Start();
            _thread3.Start();
        }

        private void ThreadOne()
        {
            while (true)
            {
                System.Console.WriteLine("Thread1");
                InfiteStuck infitestuck = new InfiteStuck();
                infitestuck.Stuck(new SubclassOne("thread1", 300, "cell duck"));
            }
        }

        private void ThreadTwo()
        {
            while (true)
            {
                System.Console.WriteLine("Thread2");
                InfiteStuck infitestuck = new InfiteStuck();
                infitestuck.Stuck(new SubclassTwo("thread2", 100, DateTime.Now, "robot"));
            }
        }

        private void ThreadThree()
        {
            while (true)
            {
                System.Console.WriteLine("Thread3");
                InfiteStuck infitestuck = new InfiteStuck();
                infitestuck.Stuck(new SubclassTwo("thread2", 200, DateTime.Now,  "drone"));
            }
        }
    }
}
