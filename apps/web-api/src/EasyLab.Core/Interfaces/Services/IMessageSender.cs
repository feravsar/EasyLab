using EasyLab.Core.Dto.Message;

namespace EasyLab.Core.Interfaces.Services
{
    public interface IMessageSender
    {
        void send(BaseMessage message);
    }

}