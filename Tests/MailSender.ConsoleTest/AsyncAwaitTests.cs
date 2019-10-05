using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    internal static class AsyncAwaitTests
    {
        public static void Start()
        {
            var messages = Enumerable.Range(1, 100).Select(i => $"Message {i}").ToArray();

            var processing_tasks = new List<Task>();
            foreach (var msg in messages)
            {
                processing_tasks.Add(Task.Run(() => MessageProcessor(msg, $"{msg}.txt")));
            }

            Console.WriteLine("Все задачи сформированы. Ждём их завершения");
            Task.WaitAll(processing_tasks.ToArray());

            Console.WriteLine("Все задачи завершились.");
        }

        private static int MessageProcessor(string msg, string FileName)
        {
            Console.WriteLine("Готовлюсь к записи сообщения {0} в файл {1}", msg, FileName);
            Thread.Sleep(250);

            System.IO.File.WriteAllText(FileName, msg);

            Console.WriteLine("Сообщение {0} записано в файл {1}", msg, FileName);
            return msg.Length;
        }

        public static async void StartAsync()
        {
            var messages = Enumerable.Range(1, 100).Select(i => $"Message {i}").ToArray();

            var processing_tasks = new List<Task>();
            foreach (var msg in messages)
            {
                //processing_tasks.Add(Task.Run(() => MessageProcessorAsync(msg, $"{msg}.txt")));
                //processing_tasks.Add(MessageProcessorAsync(msg, $"{msg}.txt"));
            }

            Console.WriteLine("Все задачи сформированы. Ждём их завершения");
            //Task.WaitAll(processing_tasks.ToArray());
            var awaiting_all_task = Task.WhenAll(processing_tasks);
            await awaiting_all_task;

            Console.WriteLine("Все задачи завершились.");
        }

        private static async Task<int> MessageProcessorAsync(string msg, string FileName)
        {
            Console.WriteLine("Готовлюсь к записи сообщения {0} в файл {1}", msg, FileName);
            Thread.Sleep(250);

            using(var writer = new StreamWriter(FileName))
                await writer.WriteAsync(msg).ConfigureAwait(false);

            Console.WriteLine("Сообщение {0} записано в файл {1}", msg, FileName);
            return msg.Length;
        }
    }
}
