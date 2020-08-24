namespace EasyLab.Core.Dto.Message
{
    public class EmailMessage : BaseMessage
    {
        public string Email { get; private set; }
        public EmailMessage(string email, string title, string content, string name, string surname) : base(title, content, name, surname)
        {
            Email = email;
        }

    }
}
