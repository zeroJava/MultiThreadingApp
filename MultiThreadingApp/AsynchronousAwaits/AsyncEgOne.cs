using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp.AsynchronousAwaits
{
    public class AsyncEgOne
    {
        /* Aysnchronous programming means that we have setion of the code that will not run synchronously with 
         * the whole code.
         * 
         * Normally when the code is executed synchronously, it means that every action (function) is executed one after
         * another in a sequential manner. The compiler will wait for the current action to finish inroder to move to the
         * next action. 
         * 
         * When code is executed asynchronously, it means that a section of the code (function) is still being executed, but the 
         * compiler has continued on, and started executng the next function. This is because we told the compiiler to continue
         * on with the execution.
         * 
         * <Anonolgy>
         * Image a river continously flowing downward as synchronous because we are going in one direction, which is down stream.
         * 
         * Now image adding a smaller stream to the current river, which open 1/4 of the river and closes at 3/4 of the river.
         * Well in this case the sub-river flowing is asynchronous, because sub-river has not stoped the flow of the main river
         * becauese it is continuously flowing, but also the sub-reiver also flows.
         * */
        public void Execute()
        {
            // sync
            /* 
             * */
            Display("Start synchronouslly");
            Action("ExeOne synchronouslly");
            Action("ExeTwo synchronouslly");
            Action("ExeThree synchronouslly");
            Action("ExeFour synchronouslly");

            // async
            Display("Start Asynchronouslly");
            Action("ExeOne Asynchronouslly");
            Action("ExeTwo Asynchronouslly");
            InnerExecute();
            Action("ExeThree Asynchronouslly");
            Action("ExeFour Asynchronouslly");
        }

        private async void InnerExecute()
        {
            Action("InnerExecuteOne");
            Action("InnerExecuteTwo");
            await OperaitionAsyncro();
            //OperaitionNotAsyncro();
            Action("InnerExecuteThree");
            Action("InnerExecuteFour");
        }

        private void Action(string word)
        {
            Display(word);
        }

        private Task OperaitionAsyncro()
        {
            return Task.Factory.StartNew(() =>
            {
                Display("Operation start");
                Thread.Sleep(10000);
                Display("Operation end");
            });
        }

        private void OperaitionNotAsyncro()
        {
            Display("Operation start");
            Thread.Sleep(4000);
            Display("Operation end");
        }

        private void Display(string word)
        {
            System.Console.WriteLine(word+": " + DateTime.Now);
        }

        // https://codewala.net/2015/07/29/concurrency-vs-multi-threading-vs-asynchronous-programming-explained/
    }
}
