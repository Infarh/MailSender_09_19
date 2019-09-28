using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.Linq2SQL
{
    public class Linq2SQLRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly MailSenderDBDataContext _db;

        public Linq2SQLRecipientsDataProvider(MailSenderDBDataContext db) { _db = db; }

        public IEnumerable<Recipient> GetAll() => _db.Recipient.ToArray();

        public int Create(Recipient recipient)
        {
            if(recipient is null) throw new ArgumentNullException(nameof(recipient));
            
            _db.Recipient.InsertOnSubmit(recipient);
            SaveChanges();
            return recipient.Id;
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
