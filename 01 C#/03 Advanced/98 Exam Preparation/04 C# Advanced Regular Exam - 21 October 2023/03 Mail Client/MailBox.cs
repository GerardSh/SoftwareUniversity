using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;

            Inbox = new List<Mail>();

            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }

        public List<Mail> Inbox { get; set; }

        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender) => Inbox.Remove(Inbox.FirstOrDefault(x => x.Sender == sender));

        public int ArchiveInboxMessages()
        {
            Archive.InsertRange(Archive.Count, Inbox);

            int mailCount = Inbox.Count;

            Inbox.Clear();

            return mailCount;
        }

        public string GetLongestMessage() => Inbox.OrderByDescending(x => x.Body.Length).FirstOrDefault().ToString();

        public string InboxView()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Inbox:");

            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}