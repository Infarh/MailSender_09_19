using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class SynchronizationTests
    {
        private static List<string> __Messages = new List<string>();

        public static void Start()
        {
            var threads = new Thread[10];



            for (var i = 0; i < threads.Length; i++)
            {
                var i0 = i;
                threads[i] = new Thread(() => Printer($"Message {i0}"));
            }

            Array.ForEach(threads, thread => thread.Start());
        }

        private static void Printer(string Message)
        {
            ThreadTests.CheckThread();

            for (var i = 0; i < 20; i++)
            {
                Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                Console.Write(" - msg({0}):", i);
                Console.WriteLine("\"{0}\"", Message);
                Thread.Sleep(100);

                __Messages.Add(Message);
            }

            Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
