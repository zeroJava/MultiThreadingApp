using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.MultiThrStream
{
    public class InfiteStuck
    {
        private System.Timers.Timer _timer { get; set; }
        private bool _loopState;

        public InfiteStuck()
        {
            _timer = new System.Timers.Timer(20000);
            _timer.Elapsed += OnTimerElapsed; 
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs reciever)
        {
            System.Console.WriteLine("Time elasped");
            _loopState = false;
            _timer.Stop();
        }

        public void Stuck(Baseclass obj)
        {
            _loopState = true;
            _timer.Start();
            while (_loopState)
            {
                Persisitance.PersistObject(obj);
            }
        }
    }
}
