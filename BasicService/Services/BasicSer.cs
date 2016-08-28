using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using MultiThreadingApp;
using System.IO;

namespace BasicService.Services
{
    partial class BasicSer : ServiceBase
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public BasicSer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var thread1 = new Thread(x => Execute("Thread1"));
            var thread2 = new Thread(z => Execute("Thread2"));
            thread1.Start();
            thread2.Start();
        }

        protected override void OnStop()
        {
            _tokenSource.Cancel();
        }

        private void Execute(string source)
        {
            try
            {
                MultiThreadingApp.Entitys.SavingDatacs saving = new MultiThreadingApp.Entitys.SavingDatacs();
                while (true)
                {
                    if (_tokenSource.IsCancellationRequested)
                    {
                        break;
                    }

                    saving.Execute(source);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    using (var write = new StreamWriter(@"C:\Users\Abu\Documents\Programming\C#\MultiThreadingApp\Exception file.txt"))
                    {
                        write.WriteLine("Exception:\n" + ex.ToString());
                    }
                }
                catch (IOException ioex)
                {
                    Console.WriteLine("IOException Console");
                }
                catch (Exception e)
                {
                    Console.WriteLine("exception");
                }
            }
        }
    }
}
