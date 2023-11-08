using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Services
{
    public class MessageServices
    {
        private UnitOfWork unitOfWork;
        public MessageServices(UnitOfWork unitOfWork)

        {
            this.unitOfWork = unitOfWork;
        }

        public void SendMessage(int authorId, int chatId, string text)
        {
            unit.CheckExistanceById();
            Message message= new Message{UserId= authorId, ChatId = chatId, Text = text, SentTime = DateTime.Now  };

        }
    }

}
