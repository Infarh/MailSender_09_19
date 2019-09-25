using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.InMemory
{
    public class InMemoryRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly List<Recipient> _Recipients = new List<Recipient>();

        /// <inheritdoc />
        public IEnumerable<Recipient> GetAll() => _Recipients;

        /// <inheritdoc />
        public int Create(Recipient recipient)
        {
            if (_Recipients.Contains(recipient)) return recipient.Id;
            recipient.Id = _Recipients.Count == 0 ? 1 : _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(recipient);
            return recipient.Id;
        }

        /// <inheritdoc />
        public void SaveChanges() {  }
    }
}
