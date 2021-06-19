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
            thread.ExecuteJoins();*/

            /*Basics.MultiThreadLocks locking = new Basics.MultiThreadLocks();
            locking.ExecuteJoins();*/

            /*Basics.MultiThreadSleep sleeping = new Basics.MultiThreadSleep();
            sleeping.Execute();*/

            /*ThreadPools.ThreadPoolExample pooling = new ThreadPools.ThreadPoolExample();
            pooling.ExecuteJoins();

            Entitys.SavingDatacs saving = new Entitys.SavingDatacs();
            saving.ExecuteJoins();*/

            /*Blockings.ThreadBlocks block = new Blockings.ThreadBlocks();
            block.ExecuteJoins();*/
            // block.ExecuteSleep();

            /*Lockings.ThreadLocks locking = new Lockings.ThreadLocks();
            locking.ExecuteJoins();*/

            /*Lockings.ThreadReadWriteLock readWritelock = new Lockings.ThreadReadWriteLock();
            readWritelock.ExecuteJoins();*/

            /*SignalCs.ThreasAutoResetEvnt autoResetEventTest = new SignalCs.ThreasAutoResetEvnt();
            // autoResetEvent.Execute();
            autoResetEvent.ExecuteTwo();*/

            /*SignalCs.ThreasManualResetEvnt manRestEventTest = new SignalCs.ThreasManualResetEvnt();
            //manRestEventTest.Execute();
            manRestEventTest.ExecuteTwo();*/

            /*SignalCs.ThreasCountdownEvnt _countEvent = new SignalCs.ThreasCountdownEvnt();
            _countEvent.Execute();*/

            /*LnumBasic.ExecuteFileNume exFile = new LnumBasic.ExecuteFileNume();
            exFile.Execute();*/

            /*MultiThrStream.MainClInt _main = new MultiThrStream.MainClInt();
            _main.Exeute();*/

            /*AsynchronousAwaits.AsyncEgOne _asyncstuff = new AsynchronousAwaits.AsyncEgOne();
            _asyncstuff.Execute();*/

            //Concurrencies.ConcurrenciesThreads _conThread = new Concurrencies.ConcurrenciesThreads();
            //_conThread.Execute();

            AsynchronousAwaits.AsyncSimpleEg simpleEg = new AsynchronousAwaits.AsyncSimpleEg();
            simpleEg.Run();

            Console.ReadKey();
        }
    }
}
