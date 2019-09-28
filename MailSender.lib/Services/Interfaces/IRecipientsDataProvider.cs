using System.Collections.Generic;
using MailSender.lib.Entityes;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsDataProvider
    {
        IEnumerable<Recipient> GetAll();

        Recipient GetById(int id);

        int Create(Recipient item);

        void Edit(int id, Recipient item);

        bool Remove(int id);

        void SaveChanges();
    }
}
