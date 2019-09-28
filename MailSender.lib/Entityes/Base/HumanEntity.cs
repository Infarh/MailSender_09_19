namespace MailSender.lib.Entityes.Base
{
    public abstract class HumanEntity : NamedEntity
    {
        public virtual string Address { get; set; }
    }
}