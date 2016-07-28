﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace MultiThreadingApp.Services
{
    partial class BasicService : ServiceBase
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public BasicService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var thread1 = new Thread(Execute);
            var thread2 = new Thread(Execute);
            thread1.Start();
            thread2.Start();
        }

        protected override void OnStop()
        {
            _tokenSource.Cancel();
        }

        private void Execute()
        {
            while (true)
            {
                if (_tokenSource.IsCancellationRequested)
                {
                    break;
                }

                using (var context = new ServiceDBContext())
                {
                    var item = new BasicServiceTable();
                    item.GUIDS = Guid.NewGuid();
                    item.DATE = DateTime.Now;
                    context.BasicServiceTables.Add(item);
                    context.SaveChanges();
                }
            }
        }
    }
}