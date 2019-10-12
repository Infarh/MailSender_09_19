using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.EF;

namespace MailSender.lib.Services.EF
{
    public class DataContextProvider
    {
        public string ConnectionString { get; set; } = "name=MailSenderDB";

        public MailSenderDB CreateContext() => new MailSenderDB(ConnectionString);
    }
}
