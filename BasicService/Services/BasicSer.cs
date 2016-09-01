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
using NLog;

namespace BasicService.Services
{
    partial class BasicSer : ServiceBase
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private readonly object _object = new object();
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public BasicSer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var thread1 = new Thread(x => Execute("Thread1"));
            var thread2 = new Thread(z => Execute("Thread2"));
            var thread3 = new Thread(z => Execute("Thread3"));
            var thread4 = new Thread(z => Execute("Thread4"));
            var thread5 = new Thread(z => Execute("Thread5"));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
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
                MultiThreadingApp.Entitys.RetrievingData retrieving = new MultiThreadingApp.Entitys.RetrievingData();
                while (true)
                {
                    if (_tokenSource.IsCancellationRequested)
                    {
                        break;
                    }

                    saving.Execute(source);
                    _logger.Info("Size: " );
                }
            }
            catch (Exception ex)
            {
                try
                {
                    lock (_object)
                    {
                        _logger.Error("We have encoutered an error " + ex.ToString());
                    }
                }
                catch (IOException ioex)
                {
                    lock (_object)
                    {
                        _logger.Error("We have encoutered an IOException " + ioex.ToString());
                    }
                }
                catch (Exception e)
                {
                    lock (_object)
                    {
                        _logger.Error("We have encoutered an Eception " + e.ToString());
                    }
                }
            }
        }
    }
}
