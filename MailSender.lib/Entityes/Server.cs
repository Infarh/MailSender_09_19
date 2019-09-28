using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class Server : NamedEntity
    {
        public string Host { get; set; }

        public int Port { get; set; } = 25;

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Description { get; set; }
    }
}