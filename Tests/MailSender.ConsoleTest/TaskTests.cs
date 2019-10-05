using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class TaskTests
    {
        public static void Start()
        {
            //var first_task = new Task(TaskMethod/*, TaskCreationOptions.LongRunning*/);
            //first_task.Start();
            ////first_task.Wait();

            var msg = "Hello World!";
            //var get_length_task = new Task<int>(() => GetStrLength(msg));
            //get_length_task.Start();
            //Console.WriteLine("Какие-то дополнительные действия в главном потоке после запуска задачи");

            //Console.ReadLine();

            //try
            //{
            //    //get_length_task.Wait();
            //    Console.WriteLine("str {0} - length:{1}", msg, get_length_task.Result);
            //}
            //catch (AggregateException error)
            //{
            //    Console.WriteLine("При выполнении задачи случилось страшное:");
            //    foreach (var inner_error in error.InnerExceptions)
            //        Console.WriteLine("\t{0}", inner_error.Message);
            //}

            var second_task = Task.Factory.StartNew(TaskMethod);

            Console.WriteLine();

            Console.WriteLine("Некие действия после запуска задачи");
            
            Console.WriteLine();

            second_task.Wait();
            Console.WriteLine("Мы дождались завершения запущенной нами задачи");

            var second_value_task = Task.Run(() => GetStrLength(msg)); // Рекомендуемый и чаще всего встречаемый

            //Console.WriteLine("str {0} - length:{1}", msg, second_value_task.Result);
            var second_value_task_continuation = second_value_task.ContinueWith(
                completed_task => Console.WriteLine("str {0} - length:{1}", msg, completed_task.Result),
                TaskContinuationOptions.OnlyOnRanToCompletion);

            var second_value_task_continuation_on_exception = second_value_task.ContinueWith(
                completed_task => Console.WriteLine("Exception {0}", completed_task.Exception),
                TaskContinuationOptions.OnlyOnFaulted);
            //second_value_task_continuation.ContinueWith()

        }

        private static void TaskMethod()
        {
            Console.WriteLine("ThID:{0} TaskID:{1} - started", 
                Thread.CurrentThread.ManagedThreadId,
                Task.CurrentId);

            Thread.Sleep(1000);

            Console.WriteLine("ThID:{0} TaskID:{1} - ended",
                Thread.CurrentThread.ManagedThreadId,
                Task.CurrentId);
        }

        private static int GetStrLength(string msg)
        {
            Console.WriteLine("ThID:{0} - str:{1} - started", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThID:{0} - str:{1} - completed", Thread.CurrentThread.ManagedThreadId, msg);

            //throw new InvalidOperationException("Страшная ошибка!");

            return msg.Length;
        }
    }
}
