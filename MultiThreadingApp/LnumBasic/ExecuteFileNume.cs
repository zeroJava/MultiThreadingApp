using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp.LnumBasic
{
    public class ExecuteFileNume
    {
        private string _number;
        private MassiveNumberCreator _massiveNumber;
        private AutoResetEvent _arevent = new AutoResetEvent(false);

        public ExecuteFileNume()
        {
            Thread initialiseNumberThrd = new Thread(InitialiseNumber);
            initialiseNumberThrd.Start();
            initialiseNumberThrd.Join();

            _massiveNumber = new MassiveNumberCreator(_number);
        }

        public void Execute()
        {
            Thread calculate = new Thread(Calculate);
            calculate.Start();

            Thread saveDta = new Thread(Save);
            saveDta.Start();

            Thread sizel = new Thread(SizeL);
            sizel.Start();
        }

        private void InitialiseNumber()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["path"];

            if (!CreateNumber.TryGetPeristedNumber(path, out _number))
            {
                _number = "2";
            }

            //_arevent.WaitOne();
        }

        private void Calculate()
        {
            while (true)
            {
                System.Console.WriteLine("Calculating");

                _massiveNumber.Execute();
                GC.Collect();
            }
        }

        private void Save()
        {
            while (true)
            {
                System.Console.WriteLine("Saving");

                string path = System.Configuration.ConfigurationManager.AppSettings["path"];
                PersitNumber.Persist(path, _massiveNumber.GetMassiveNumber());
            }
        }

        private void SizeL()
        {
            while (true)
            {
                System.Console.WriteLine("Size of number " + _massiveNumber.GetMassiveNumber().Length);
            }
        }
    }
}
