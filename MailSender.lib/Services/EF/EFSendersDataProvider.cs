using System;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class EFSendersDataProvider : EFDataProvider<Sender>, ISendersDataProvider
    {
        public EFSendersDataProvider(MailSenderDB db) : base(db) { }

        public override void Edit(int id, Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            SaveChanges();
        }
    }

    public class EFSendersDataProvider2 : EFDataProvider2<Sender>, ISendersDataProvider
    {
        public EFSendersDataProvider2(DataContextProvider db) : base(db) { }

        public override void Edit(int id, Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            using(var db = _db.CreateContext())
            {
                if(!db.Senders.Any(s => s.Id == id)) return;

                //var db_item = GetById(id);
                //db.Senders.Attach(db_item);
                var db_item = db.Senders
                   .FirstOrDefault(s => s.Id == id)
                    ?? throw new InvalidOperationException($"Объект id:{id} не получен из базы данных, хотя должен находиться в ней");

                db_item.Name = item.Name;
                db_item.Address = item.Address;
                db.SaveChanges();
            }
        }
    }
}