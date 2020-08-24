namespace EasyLab.Core.Dto.Message{
    public abstract class BaseMessage{
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string  Name { get; private set; }
        public string Surname { get; private set; }

        public BaseMessage (string title, string content, string name, string surname){
            Title = title;
            Content = content;
            Name = name;
            Surname = surname;
        }


    }

}
