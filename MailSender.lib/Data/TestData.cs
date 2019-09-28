using System.Collections.Generic;
using MailSender.lib.Entityes;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server { Id = 1, Name = "Yandex", Host = "smtp.yandex.ru", UserName = "UserName", Password = "Pass"},
            new Server { Id = 2, Name = "Mail.ru", Host = "smtp.mail.ru", UserName = "UserName", Password = "Pass"},
            new Server { Id = 3, Name = "Gmail.com", Host = "smtp.gmail.com", Port = 465, UserName = "UserName", Password = "Pass"},
        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender { Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Sender { Id = 2, Name = "Петров", Address = "petrov@mail.ru"},
            new Sender { Id = 3, Name = "Сидоров", Address = "sidorov@gmail.com"},
        };
    }
}
