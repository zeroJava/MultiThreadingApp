using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp.SignalCs
{
    public class ThreasManualResetEvnt
    {
        private ManualResetEvent _mre1 = new ManualResetEvent(false);
        private ManualResetEvent _mre2 = new ManualResetEvent(false);

        private System.Timers.Timer _timer1;
        private System.Timers.Timer _timer2;

        /* Signal constructs is similar to normal blocking mechanism like sleep and join,
         * in thatis blocks a thread, but with the ability to manually unblock the thread 
         * any time we like.
         * 
         * With Sleep(1000) and Join(1000), we would have to wait for the blocking mechniasm to
         * reach the threshold for it to resume executing the thread.
         * 
         * With signal construct we can unblock the thread when ever we like, by executing the 
         * Set() method, which would force any thread blocked using the WaitOne(10000) method
         * to resume executing.
         * */

        /* Difference between AutoResetEvent and ManaulResetEvent
         * 
         * Difference between AutoResetEvent and ManaulResetEvent is that the WaitOne() in 
         * ManualResetEvent WaitOne() function will not pause the thread when used a after the Set() 
         * function; where as AutoresetEvent WaitOne() will always pause the thread, even
         * after the Set() function.
         * This is because, once the manaualResetEvent Set() function opens the gates (analogy)
         * it does not close itself automatically, so the next time WaitOne() is called, it's 
         * trying stop process going through the door, but the door isn't closed and the
         * process are going through anyway.
         * Inorder to close the "gate" and have the WaitOne() function functioning again, we 
         * have to use the Reset() function after the Set(), which resets "gate" back to
         * close.
         * AutoResetEvent Set() has the Reset() function built-in, so it automatically closes the gates,
         * and the WaitOne() function will always pause
         * */

        public ThreasManualResetEvnt()
        {
            _timer1 = new System.Timers.Timer(5000);
            _timer2 = new System.Timers.Timer(5000);
        }

        public void Execute()
        {
            _timer1.Elapsed += TimeOneElapsed;

            while (true)
            {
                Display("Execute", "Going to pause");
                _timer1.Start();
                _mre1.WaitOne(10000);
                Display("Execute", "Left waiting");

                /* WaitOne(10000) function in this case will only pause the thread once,
                 * and after we excute the Set() function, the WaitOne() will not pause
                 * the second time or anytime after that.
                 * This is because the Set() function open the gate (anology).
                 * But, if we do not invoke the Set() function, then WaitOne() will 
                 * allows pause the thread.
                 * */

                /* Invokig the WaitOne() on a object that has a gate (anology) that is
                 * open is useless, because it defeats the purpose of stopping something
                 * , in this case process, when there is nothing to stop it .i.e. a close
                 * gate. 
                 * */
            }
        }

        public void ExecuteTwo()
        {
            _timer2.Elapsed += TimeTwoElapsed;
            _timer2.Start();

            while (true)
            {
                Display("ExecuteTwo", "Going to pause");
                _timer2.Start();
                _mre2.WaitOne(10000);
                Display("ExecuteTwo", "Left waiting");

                /* WaitOne(10000) function in this case will always pause the thread,
                 * even after we excuted the Set() function. 
                 * This is because after we Execute the Set() function, we also execute
                 * the Reset() function. 
                 * */
            }
        }

        private void TimeOneElapsed(object sender, System.Timers.ElapsedEventArgs receiver)
        {
            Display("TimeOneElapsed", "Elapsed");
            _timer1.Stop();
            _mre1.Set();
        }

        private void TimeTwoElapsed(object sender, System.Timers.ElapsedEventArgs receiver)
        {
            Display("TimeTwoElapsed", "Elapsed");
            _timer2.Stop();
            _mre2.Set();
            _mre2.Reset();
        }

        private void Display(string location, string message)
        {
            System.Console.WriteLine("Location: " + location + " function. Message: " + message + ". Time: " + DateTime.Now);
        }
    }
}
