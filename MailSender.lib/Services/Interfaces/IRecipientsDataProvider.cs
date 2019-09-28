using System.Collections.Generic;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsDataProvider
    {
        IEnumerable<Recipient> GetAll();

        int Create(Recipient recipient);

        void SaveChanges();
    }
}
