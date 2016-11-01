using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp.SignalCs
{
    public class ThreasCountdownEvnt
    {
        private CountdownEvent _cde = new CountdownEvent(3);
        private CancellationTokenSource _cancelSource = new CancellationTokenSource();
        private System.Timers.Timer _timer = new System.Timers.Timer(10000);

        /* CountdownEvent allows us to pause (block) a thread for specfic time by using 
         * the Wait(100000) function, but also allow us to unblock the thread manually 
         * if we use the Signal() function a set number of times.
         * 
         * In-order to resume the thread and leave the Wait(), we have to invoke the
         * Signal() function a specific time, until the count we specified in the
         * constructor is set to 0.
         * Unlike Auto or ManualRestEvent, were the thread resume ASAP when we execute
         * the Set() function. With CountdownEvent, it will wait until all counts (virtual objects)
         * have invoked the Signal function.
         * 
         * e.g.
         * _cde = new CountdownEvent(3);
         * _cde.Signal(); - Will not resume the wait. Count now: 2
         * _cde.Signal(); - Will not resume the wait. Count now: 1
         * _cde.Signal(); - After this, thread resume processing. Count now: 0
         * */

        public ThreasCountdownEvnt()
        {
            _timer.Elapsed += OnTimerElapsed;
        }

        public void Execute()
        {
            _timer.Start();

            ThreadPool.QueueUserWorkItem(x => Fthread("Thread1", _cancelSource.Token));
            ThreadPool.QueueUserWorkItem(x => Fthread("Thread2", _cancelSource.Token));
            ThreadPool.QueueUserWorkItem(x => Fthread("Thread3", _cancelSource.Token));

            Display("Execute", "Going To Wait");
            _cde.Wait();
            /* This will pause the thread
             * */
            _cancelSource.Cancel();
        }

        private void Fthread(string name, CancellationToken cancellation)
        {
            while (true)
            {
                Display(name, "Running");

                if (cancellation.IsCancellationRequested)
                {
                    Display(name, "Ending thread");
                    _timer.Stop();
                    break;
                }
            }
        }

        private void OnTimerElapsed(object source, System.Timers.ElapsedEventArgs receiver)
        {
            Display("OnTimerElapsed", "Elapsed");
            _cde.Signal();
            /* This Signal() function has to be invoke a certain number of times
             * until the count hcomes down to 0, and then it will unblock the
             * wait.
             * */
            _timer.Stop();
            _timer.Start();
        }

        private void Display(string threadLocation, string action)
        {
            System.Console.WriteLine("Inside thread: " + threadLocation + ". Action: " + action);
        }
    }
}
