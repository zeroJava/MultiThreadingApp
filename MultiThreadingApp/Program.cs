using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Basics.MultiThreadedOne thread = new Basics.MultiThreadedOne();
            thread.Execute();*/

            /*Basics.MultiThreadLocks locking = new Basics.MultiThreadLocks();
            locking.Execute();*/

            /*Basics.MultiThreadSleep sleeping = new Basics.MultiThreadSleep();
            sleeping.Execute();*/

            /*ThreadPools.ThreadPoolExample pooling = new ThreadPools.ThreadPoolExample();
            pooling.Execute();

            Entitys.SavingDatacs saving = new Entitys.SavingDatacs();
            saving.Execute();*/

            Blockings.ThreadBlocks block = new Blockings.ThreadBlocks();
            block.Execute();

            Console.ReadKey();
        }
    }
}
