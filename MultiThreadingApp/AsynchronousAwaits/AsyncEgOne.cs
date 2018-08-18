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
        private bool _state = true;

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
         * <anonolgy>
         * Image a river continously flowing downward as synchronous because we are going in one direction, which is down stream.
         * 
         * Now image adding a smaller stream to the current river, which open 1/4 of the river and closes at 3/4 of the river.
         * Well in this case the sub-river flowing is asynchronous, because sub-river has not stoped the flow of the main river
         * becauese it is continuously flowing, but also the sub-reiver also flows.
         * 
         * </anonology>
         * */
        public void Execute()
        {
            // synchronous programming
            /* With code running synchronously, you will see the Display function being executed first,
             * then after that has finished, the first of the Action function is executed. 
             * And the compiler will do this continously in a squential manner until it reaches 
             * the end of the application.
             * */
            Display("Start synchronously");
            Action("ExeOne synchronously");
            Action("ExeTwo synchronously");
            Action("ExeThree synchronously");
            Action("ExeFour synchronously");

            // async
            /* With asynchrounous, Dsipaly, Action one and two function will execute in a squential manner,
             * but when we reach the InnerExecute function, that's when things start to get asynchrounous.
             * Because the InnerExecute method has been flagged with the async keyword, which means it contains
             * the await keyword.
             * So from the Display function uptil the await keyword inside the InnerExecute function, the 
             * compiler will execute the functions synchronousy in an sequential manner.
             * But when the await keyword and the function that is assiciated with it invoked, instead of waiting
             * for OperationAsyncro function inside aync function InnerExecute to finish like normally, the compiler 
             * moves to the next function, and starts executing the remainder of the functions.
             * After OperationAsyncro function has finished executing, the compiler will continue executing the remainder
             * functions inside the InnerExecute function.
             * When the compiler is running async, it is kind of running parallel with async method running parallel to 
             * the main method.
             * */
            Display("Start Asynchronously");
            Action("ExeOne Asynchronously");
            Action("ExeTwo Asynchronously");
            InnerExecuteAsync();
            InnerExecuteTwoAsync();
            InnerExecuteThreeAsync();
            Action("ExeThree Asynchronously");
            Action("ExeFour Asynchronously");
        }

        private async void InnerExecuteAsync() // using the async keyword, we are flugging it as a method that contained await, and thus working async
        {
            Action("InnerExecuteOne");
            Action("InnerExecuteTwo");
            await OperationAsyncro(); // await keyword is that makes it asynchronous
            /* When the function with the await keyword is executed, the compiler moves to the next 
             * fuction (Action(Three)) immediately before the function associated with the await keyword 
             * has finished executing.
             * 
             * Look at it this way, the await keyword creates a pocket dimension; this dimension is 
             * our OperationAsyncro().
             * This pocket dimension exist within the larger universe i.e. our application (main thread),
             * and it's running parallel to our main universe.
             * */
            //OperaitionNotAsyncro();
            Action("InnerExecuteThree");
            Action("InnerExecuteFour");
        }

        private async void InnerExecuteTwoAsync()
        {
            await OpperationAsyncroTwo();
        }

        private async void InnerExecuteThreeAsync()
        {
            await OpperationAsyncroThree();
        }

        private void Action(string word)
        {
            Display(word);
        }

        private Task OperationAsyncro()
        {
            return Task.Factory.StartNew(() =>
            {
                Display("Operation start");
                Thread.Sleep(4000);
                _state = false;
                Display("Operation end");
            });
        }

        private Task OpperationAsyncroTwo()
        {
            return Task.Factory.StartNew(() =>
            {
                while (_state)
                {
                    Display("Async looping two");
                }
            });
        }

        private Task OpperationAsyncroThree()
        {
            return Task.Factory.StartNew(() =>
            {
                while (_state)
                {
                    Display("Async looping three");
                }
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
